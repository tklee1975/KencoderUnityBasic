using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SimpleTDD;

public class SingletonTest : BaseTest {		

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		ShowScreenLog();
		ShowCounterInfo();
		PrefabSingleton.Instance.UpdateUI();
	}

	public void ShowCounterInfo() {
		string info = "";

		info += "SimpleSingleton: counter=" + SimpleSingleton.Instance.counter + "\n";
		info += "SOSingleton: counter=" + SOSingleton.Instance.counter + "\n";
		info += "GameCounter: counter=" + GameCounter.Instance.counter + "\n";
		info += "MonoCounter: counter=" + MonoCounter.Instance.counter + "\n";
		info += "SOCounter: counter=" + SOCounter.Instance.counter + "\n";
		info += "PrefabSingleton: counter=" + PrefabSingleton.Instance.counter + "\n";

		UpdateLog(info);

	}

	[Test]
	public void AddCounter()
	{
		SimpleSingleton.Instance.counter++;
		SOSingleton.Instance.IncreaseCounter();
		SOCounter.Instance.IncreaseCounter();
		GameCounter.Instance.counter++;
		MonoCounter.Instance.counter++;
		
		PrefabSingleton.Instance.AddCounter();

		ShowCounterInfo();
	}

	[Test]
	public void ShowCounter()
	{
		ShowCounterInfo();
	}

	[Test]
	public virtual void ToScene2()
	{
		SceneManager.LoadScene("SingletonTest2");
	}
}
