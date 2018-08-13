using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kencoder;


public class SOSingleton : ScriptableObject {

	public string kFilePath = "/SOSingleton.sav";		// remember to add "/" at the beginning

	public int counter = 0;

	#region Singleton Code
	protected static SOSingleton sInstance = null;

	public static SOSingleton Instance
	{
		get
		{
			if (sInstance == null) {
				sInstance = ScriptableObject.CreateInstance<SOSingleton>();
				sInstance.hideFlags = HideFlags.HideAndDontSave;	// Not visible to the user and not save
			}

			return sInstance;
		}
	}

	public SOSingleton ()
	{
		// ken: cannot load data from persistence path at Constructor, so move to OnEnable
		// else will see => get_persistentDataPath is not allowed to be called from a ScriptableObject constructor 
		//				    (or instance field initializer), call it in OnEnable instead. ...
		// LoadCounter();		// uncomment to test the above error
	}

	void OnEnable() {
		LoadCounter();
	}

	void SaveCounter() {
		string path = Application.persistentDataPath + kFilePath;
		
		FileHelper.WriteFile(path, counter.ToString());
	}

	void LoadCounter() {
		string path = Application.persistentDataPath + kFilePath;
		
		string counterValue = FileHelper.ReadFile(path);

		//Debug.Log("  LoadCounter: value=[" + counterValue + "] path=" + path); 

		if(counterValue == null || counterValue == "") {
			counter = 1;
		} else {
			counter = int.Parse(counterValue);
		}
	}

	#endregion

	#region API 
	public void IncreaseCounter() {
		counter++;
		SaveCounter();
	}


	#endregion
}
