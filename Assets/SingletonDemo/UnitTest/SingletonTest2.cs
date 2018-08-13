using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleTDD;

public class SingletonTest2 : SingletonTest {		
	void Start()
	{
		ShowScreenLog();
		ShowCounterInfo();
	}


	[Test]
	public void ToScene1()
	{
		SceneManager.LoadScene("SingletonTest");
	}
}
