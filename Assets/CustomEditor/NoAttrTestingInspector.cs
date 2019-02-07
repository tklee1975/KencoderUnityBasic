using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NoAttrTestingInspector : MonoBehaviour {
	public struct Tuple {
		public string key;
		public string value;
	}

	public enum Type {
		TypeA,
		TypeB,
		TypeC,
	}

	public string message1 = "Hello";
	public string message2 = "line1/nline2/line3";
	public string message3 = "Hello";

	public bool boolValue;
	public int intValue;
	public float floatValue;
	
	protected float myValue1;
	private float myValue2;	
	public float myValue3;
	private float myValue4;
	
	public Color color;
	public Color opaqueColor;
	public Color hdrColor;

	public GameObject testObject;
	public Type testType;
	public Tuple tuple;
	

	// Public Variable 
	public string secretKey = "<please define>";
	public string secretID = "<please define>";

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
