using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Kencoder
{
	public class FileHelper 
	{
		public static string ReadFile(string path)		// e.g "Assets/UnitTest/_Resource/test.txt";
		{
			//Read the text from directly from the test.txt file
			try {
				StreamReader reader = new StreamReader(path); 
				string result = reader.ReadToEnd();
				reader.Close();
				return result;
			} 
			catch  (System.Exception e)
			{
				Debug.Log("FileHelper: exception=" + e);
				return null;
			}
		}

		// https://docs.unity3d.com/Manual/StreamingAssets.html
		// https://answers.unity.com/questions/1087159/reading-text-file-on-android.html
		// https://answers.unity.com/questions/1066673/open-a-file-by-path-from-assets-folder-in-android.html
		public static string ReadFileFromAsset(string path) {	// related path to Assets/
			TextAsset textAsset = Resources.Load<TextAsset>(path);
			if(textAsset == null) {
				Debug.Log("ReadFileFromAsset: textAsset is null. path=" + path);
				return "";
			}
			//Debug.Log(path + ">>\n" + textAsset);

			return textAsset.text;
		}

		public static void WriteFile(string path, string content)		// e.g "Assets/UnitTest/_Resource/test.txt";
		{
			StreamWriter writer = new StreamWriter(path); 
			writer.Write(content);

			writer.Close();
		}

		public static void RemoveFile(string path)		// Mainly used for reset setting
		{
			Debug.Log("FileHelper.RemoveFile: " + path + " is removed");
			File.Delete(path);
		}

	}
}