using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoA : MonoBehaviour {
	private int mUpdateCount = 0;
	private int mFixedUpdateCount = 0;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		ExecuteOrderTest.Log("[MonoA] awake");
	}

	// Use this for initialization
	void Start () {
		ExecuteOrderTest.Log("[MonoA] Start");
	}

	public void Hello() {
		ExecuteOrderTest.Log("[MonoA] Hello");
	}

	string CountToStr(int count){
		if(1 == count) { return "First"; }
		else if(2 == count) { return "Second"; }
		else { return ""; }
	}
	
	// Update is called once per frame
	void Update () {
		mUpdateCount++;

		if(mUpdateCount >= 1 && mUpdateCount <= 2) {
			ExecuteOrderTest.Log("[MonoA] " + CountToStr(mUpdateCount) + " Update");
		}
	}

	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		mFixedUpdateCount++;

		if(mFixedUpdateCount >= 1 && mFixedUpdateCount <= 2) {
			ExecuteOrderTest.Log("[MonoA] " + CountToStr(mFixedUpdateCount) + " FixedUpdate");
		}
	}
}
