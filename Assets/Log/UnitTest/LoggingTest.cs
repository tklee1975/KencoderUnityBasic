using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleTDD;

// References:
//	https://docs.unity3d.com/Manual/Console.html
//	https://docs.unity3d.com/ScriptReference/MonoBehaviour-print.html
//	https://docs.unity3d.com/Manual/LogFiles.html
public class LoggingTest : BaseTest {		
	[Test]
	public void DebugLog()
	{
		Debug.Log("DEBUG: Message From Debug.Log");
	}

	[Test]
	public void WarningLog()
	{
		//Debug.LogWarning("WARN: Message From Warning");
		Debug.LogWarning("Message From Warning");
	}

	[Test]
	public void ErrorLog()
	{
		//Debug.LogError("ERROR: Message From ErrorLog");
		Debug.LogError("Message From ErrorLog");
	}

	[Test]
	public void MonoPrint()
	{
		// Reference:
		//		https://docs.unity3d.com/ScriptReference/MonoBehaviour-print.html
		//		Note: Same as Debug.Log 
		MonoBehaviour.print("Message From MonoBehaviour.print");
	}


	[Test]
	public void LogException()
	{
		// Reference:
		//		https://docs.unity3d.com/ScriptReference/Debug.LogException.html
		string testStr = null;

		try {
			Debug.Log("Length of testStr=" + testStr.Length);
		} catch(System.Exception e) {
			Debug.LogException(e, this);	// Print as Error LogLevel
		}
		
	}

	
	[Test]
	public void LogAssertion()
	{
		// Reference:
		//		https://docs.unity3d.com/ScriptReference/Debug.LogException.html
		int testDeg = 45;
		
		float expected = 1.0f;	// Tan 45;
		float result = Mathf.Tan(Mathf.Deg2Rad * testDeg);
		float wrongResult = Mathf.Tan(testDeg);

		// Debug.Log("Correct Result:");
		// if(result == expected) {
		// 	Debug.Log("correct");
		// } else {
		// 	Debug.LogAssertion("result not match", this);			
		// }
		
		//Debug.Log("Wrong Result:");
		if(wrongResult == expected) {
			Debug.Log("correct");
		} else {
			Debug.LogAssertion("result not match", null);
		}
	}

	[Test]
	public void Log7Lines()
	{
		string logOutput = "";
		for(int i=1; i<=7; i++) {
			logOutput += "logging line-" + i + "\n";
		}

		Debug.Log("DEBUG:\n" + logOutput);
		
	}
}
