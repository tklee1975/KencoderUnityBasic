using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kencoder;

// This sample code is based on the Unity Sample Code 2DGameKit/PhysicHelper
public class SOCounter : GenericSOSingleton<SOCounter>
{  
    public string kFilePath = "/SOCounter.sav";

    #region Start up logic
   
    void OnEnable() {
		LoadCounter();
	}

    #endregion

    #region Save / Load

	void SaveCounter() {
		string path = Application.persistentDataPath + kFilePath;
		
		FileHelper.WriteFile(path, counter.ToString());
	}

	void LoadCounter() {
		string path = Application.persistentDataPath + kFilePath;
		
		string counterValue = FileHelper.ReadFile(path);

		//Debug.Log("  LoadCounter: value=[" + counterValue + "] path=" + path); 

		if(counterValue == null || counterValue == "") {
			counter = 99;
		} else {
			counter = int.Parse(counterValue);
		}
	}

	#endregion

	#region API 
    public int counter = 10;

	public void IncreaseCounter() {
		counter++;
		SaveCounter();
	}


	#endregion
}