using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class ExecuteOrderTest : BaseTest {		

	public GameObject testObject;
	public GameObject bigObject;
	public GameObject monoAPrefab;
	public ScriptableObjA sObjectA;
	public ScriptableObjB sObjectB;	
	public MonoB monoB;

	#region Singleton Code 
	private static ExecuteOrderTest s_Instance = null;
    
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	protected override void DidAwake()
	{
		s_Instance = this;
	}

	public static void Log(string msg) {
		msg = msg.Replace("[", "<color=blue>");
		msg = msg.Replace("]", "</color>");

		if(s_Instance != null) {
			s_Instance.AppendLog(msg);
		} else {
			Debug.Log(msg);
		}
		//AppendLog(msg);
		//
	}

	#endregion

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		//s_Instance = this;
		ShowScreenLog();
	}

	[Test]
	public void ClearLog() {
		UpdateLog("");
	}

	[Test]
	public void UseSO_A() {
		sObjectA.Use();
	}

	[Test]
	public void CreateSO_A() {
		Log("Before scriptable object is created");
		ScriptableObjA objA = ScriptableObject.CreateInstance<ScriptableObjA>();
		Log("Scriptable object is just created");
	}

	[Test]
	public void CreateSO_B() {
		Log("Before CreateInstance");
		ScriptableObjB objB = ScriptableObject.CreateInstance<ScriptableObjB>();
		Log("After CreateInstance");
		objB.Use();
	}

	[Test]
	public void CreateMonoA()
	{
		
		Log("Before new object is created");
		GameObject newObject = new GameObject();
		Log("Before AddComponent");
		MonoA monoA = newObject.AddComponent<MonoA>();
		Log("MonoA component is just added");
		monoA.Hello();

	}

	[Test]
	public void AddComp1()
	{
		
		
		Log("Before AddComponent");
		MonoB monoB = testObject.AddComponent<MonoB>();
		Log("After AddComponent");
		monoB.Hello();

	}

	[Test]
	public void AddComp2()
	{
		//testObject.SetActive(false);
		
		Log("Before AddComponent");
		MonoB monoB = testObject.AddComponent<MonoB>();
		Log("After AddComponent");
		monoB.Hello();

		Log("SetActive(true)");
		testObject.SetActive(true);
	}

	[Test]
	public void InstantMonoA()
	{
		Log("Before instantiate");
		GameObject newObject = GameObject.Instantiate(monoAPrefab);
		Log("After instantiated");
		MonoA monoA = newObject.GetComponent<MonoA>();
		monoA.Hello();
		newObject.SetActive(true);
	}

	[Test]
	public void SetMonoBActive() {
		monoB.gameObject.SetActive(true);
	}

	[Test]
	public void SetMonoBInActive() {
		monoB.gameObject.SetActive(false);
	}

	[Test]
	public void SOSingletonOrder() {
		ManagerA.Instance.Setup();
	}

	[Test]
	public void test2()
	{
		Debug.Log("###### TEST 2 ######");
	}
}
