using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kencoder;


public class GenericSOSingleton<T> : ScriptableObject where T : ScriptableObject {	
	protected static T sInstance = null;

	public static T Instance
	{
		get
		{
			if(sInstance != null) {
				return sInstance;
			}

			var singletonName = typeof(T).Name;

			var assets = Resources.LoadAll<T>("");
            if (assets.Length > 1) {
				Debug.LogError("Found multiples " + singletonName + " on the resources folder. It is a Singleton ScriptableObject, there should only be one.");
			} else if (assets.Length == 0)
            {
				Debug.Log("ScriptableSingleton: " + singletonName + " Case 1");
                sInstance = ScriptableObject.CreateInstance<T>();
				Debug.Log("ScriptableSingleton: " + singletonName + " Case 1 - DONE");
                //Debug.LogError("Could not find a " + singletonName + " on the resources folder. It was created at runtime, therefore it will not be visible on the assets folder and it will not persist.");
            } else {
				Debug.Log("ScriptableSingleton: Case 2");
				sInstance = assets[0];
			}
            // else _instance = assets[0];
			// if (sInstance == null) {
			// 	Debug.Log("CreateInstance:");
			// 	sInstance = ScriptableObject.CreateInstance<T>();
			// 	sInstance.hideFlags = HideFlags.HideAndDontSave;	// Not visible to the user and not save
			// 	Debug.Log("CreateInstance:  END");
			// }

			return sInstance;
		}
	}
}
