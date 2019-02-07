using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerB : GenericSOSingleton<ManagerB> {
	public ManagerB() {
		ExecuteOrderTest.Log("[ManagerB] Construction. " + GetInstanceID());
	}

	public int count = -1;

	/// <summary>
	/// This function is called when the object becomes enabled and active.
	/// </summary>
	void OnEnable()
	{
		ExecuteOrderTest.Log("[ManagerB] OnEnable");
		Debug.Log("ManagerB. this=" + GetInstanceID() + " sInstance=" + 
				(ManagerB.sInstance  == null ? "null" : "" + ManagerB.sInstance.GetInstanceID()));
		count = 1;
		//Debug.Log("Check ManagerA. " + ManagerA.Instance.count);	// ken: this cause forever loop
	}
	
}
