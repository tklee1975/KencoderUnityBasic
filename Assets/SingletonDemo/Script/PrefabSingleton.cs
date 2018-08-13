using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// This sample code is based on the Unity Sample Code 2DGameKit/Translator
public class PrefabSingleton : MonoBehaviour
{   
    #region Singleton Logic
    private static PrefabSingleton s_Instance;
    public static PrefabSingleton Instance
    {
        get {
            if(s_Instance != null) {
                Debug.Log("DEBUG: PrefabSingleton [case1]: returning loaded singleton");
                return s_Instance;      // Early return the created instance 
            }

			// Find the active singleton already created
            // reference: https://docs.unity3d.com/ScriptReference/Object.FindObjectOfType.html
            s_Instance = FindObjectOfType<PrefabSingleton>();       // note: this is use during the Awake() logic
            if(s_Instance != null) {
                Debug.Log("DEBUG: PrefabSingleton [case2]: Found the active object in memory");
                return s_Instance;
            }

            CreateDefault();     // create new game object 

			return s_Instance;
        }
    }

     // 
    static void CreateDefault ()
    {
		PrefabSingleton prefab = Resources.Load<PrefabSingleton>("Prefab/PrefabSingleton");
		s_Instance = Instantiate(prefab);		// No need to care about the position, rotation, ...
		s_Instance.gameObject.name = "PrefabSingleton";
    }

    string InfoGameObject() {
        return GetGameObjectInfo(gameObject);
    }

    public static string GetGameObjectInfo(GameObject obj) {
        return "(" + obj.GetInstanceID() + ":" + obj.name +")";
    }

    #endregion

    #region Initialization Logic

    void Awake() {
        Debug.Log("DEBUG: PrefabSingleton: Awake() begin. " + InfoGameObject());
        if (Instance != this)
        {
            Debug.Log("DEBUG: PrefabSingleton: will destroy the extra gameObject " + InfoGameObject());
            Destroy (gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);      // note: s_Instance become null when switch scene if not place this line of code
    }

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		Debug.Log("DEBUG: PrefabSingleton: Start() begin. " + InfoGameObject());
	}

    #endregion

	#region Singleton Logic 

	// Data 
	public int counter = 0;
	public Sprite[] spriteArray;

	// UI Component 
	public Text counterText = null;
	public Image counterImage = null;

	public void AddCounter() {
		counter++;

		UpdateUI();
	}

	void SetupCounterText() {
		GameObject obj = GameObject.Find("CounterText");
		if(obj == null) {
			return;
		}
		counterText = obj.GetComponent<Text>();
	}

	void SetupCounterImage() {
		GameObject obj = GameObject.Find("CounterImage");
		if(obj == null) {
			return;
		}
		counterImage = obj.GetComponent<Image>();
	}

	public void UpdateUI() {
		// Update the Text 
		if(counterText == null) {
			SetupCounterText();
		}
		if(counterText != null) {
			counterText.text = "COUNTER: " + counter;
		}

		// Update the Image
		if(counterImage == null) {
			SetupCounterImage();
		}
		if(counterImage != null) {
			int index = counter % spriteArray.Length;
			Sprite selectedSprite = spriteArray[index];
			counterImage.sprite = selectedSprite;
		}
	}

	#endregion
}