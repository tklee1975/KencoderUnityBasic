using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SObj_B", menuName = "ExecutionOrder/ScriptableObjB", order = 1)]
public class ScriptableObjB : ScriptableObject {
	public ScriptableObjB() {
		ExecuteOrderTest.Log("[ScriptableObjB] Construction");
	}

	public void Use() {
		ExecuteOrderTest.Log("[ScriptableObjB] Use");
	}

	/// <summary>
	/// This function is called when the object becomes enabled and active.
	/// </summary>
	void OnEnable()
	{
		ExecuteOrderTest.Log("[ScriptableObjB] OnEnable");
	}
	
}
