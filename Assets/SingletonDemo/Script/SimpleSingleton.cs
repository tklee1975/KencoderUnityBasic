using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSingleton {
	public int counter = 0;

	static readonly SimpleSingleton _instance = new SimpleSingleton();
    public static SimpleSingleton Instance
    {
        get
        {
            return _instance;
        }
    }

    private SimpleSingleton()
    {
		Debug.Log("SimpleSingleton: is constructed");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
