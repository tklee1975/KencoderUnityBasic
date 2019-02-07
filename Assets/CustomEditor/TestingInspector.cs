using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[HelpURL("https://docs.google.com/document/d/1au7PqXEdbFQov6PbvfsEwWsagb4J2h2KNt1ShCVk2N4/edit?usp=sharing")]
public class TestingInspector : MonoBehaviour {
	[System.Serializable] 
	public struct Tuple {
		public string key;
		public string value;
	}

	public enum Type {
		TypeA,
		TypeB,
		TypeC,
	}

	[Header("Section 1: Text")]
	public string message1 = "Hello";
	[Multiline(2)]
	public string message2 = "line1/nline2/line3";
	[TextArea]
	public string message3 = "Hello";

	[Header("Section 2: Value")]
	public bool boolValue;
	[Range(1,10)] public int intValue;
	[Range(0,1.0f)] public float floatValue;
	[Space]
	[Tooltip("These variables are used to XXXX")]
	[SerializeField] protected float myValue1;
	[SerializeField] private float myValue2;	
	public float myValue3;
	[SerializeField, HideInInspector] private float myValue4;
	
	[Header("Section 3: Color")]
	public Color color;
	[ColorUsage(false)]
	public Color opaqueColor;
	[ColorUsage(true, true)]
	public Color hdrColor;

	[Header("Section 4: GameObject, Enum, Struct")]
	public GameObject testObject;
	public Type testType;
	public Tuple tuple;
	

	// Public Variable 
	[HideInInspector] public string secretKey = "<please define>";
	[HideInInspector] public string secretID = "<please define>";

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
