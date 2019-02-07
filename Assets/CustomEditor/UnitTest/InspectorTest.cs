using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

public class InspectorTest : BaseTest {		
	public TestingInspector testingInspector;
	[Test]
	public void ShowColorValue()
	{
		Debug.Log("Color: " + testingInspector.color);
		Debug.Log("Opaque Color: " + testingInspector.opaqueColor);
		Debug.Log("HDR Color: " + testingInspector.hdrColor);
	}

	[Test]
	public void test2()
	{
		Debug.Log("###### TEST 2 ######");
	}
}
