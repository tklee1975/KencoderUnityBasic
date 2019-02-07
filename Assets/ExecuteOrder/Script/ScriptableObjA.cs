using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SObj_A", menuName = "ExecutionOrder/ScriptableObjA", order = 1)]
public class ScriptableObjA : ScriptableObject {
	public ScriptableObjA() {
		ExecuteOrderTest.Log("[ScriptableObjA] Construction");
	}

	// void Awake()
	// {
	// 	ExecuteOrderTest.Log("[ScriptableObjA] Awake");
	// }

	public void Use() {
		ExecuteOrderTest.Log("[ScriptableObjA] Use");
	}

	/// <summary>
	/// This function is called when the object becomes enabled and active.
	/// </summary>
	void OnEnable()
	{
		ExecuteOrderTest.Log("[ScriptableObjA] OnEnable");
	}
	
}
