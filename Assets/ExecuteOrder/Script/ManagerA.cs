using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerA : GenericSOSingleton<ManagerA> {
	public ManagerA() {
		ExecuteOrderTest.Log("[ManagerA] Construction: " + GetInstanceID());
	}

	public int count = 1;

	/// <summary>
	/// This function is called when the object becomes enabled and active.
	/// </summary>
	void OnEnable()
	{
		ExecuteOrderTest.Log("[ManagerA] OnEnable");
		count = ManagerB.Instance.count;
		Debug.Log("[ManagerA] managerB.count=" + ManagerB.Instance.count);
	}
	
	public void Setup() {

	}
}
