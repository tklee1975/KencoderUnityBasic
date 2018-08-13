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
			if (sInstance == null) {
				sInstance = ScriptableObject.CreateInstance<T>();
				sInstance.hideFlags = HideFlags.HideAndDontSave;	// Not visible to the user and not save
			}

			return sInstance;
		}
	}
}
