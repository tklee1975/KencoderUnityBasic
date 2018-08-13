using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This sample code is based on the Unity Sample Code 2DGameKit/PhysicHelper
public class GameCounter : MonoBehaviour
{   
    #region Singleton Logic
    private static GameCounter s_Instance;
    public static GameCounter Instance
    {
        get {
            if(s_Instance != null) {
                Debug.Log("DEBUG: GameCounter [case1]: returning loaded singleton");
                return s_Instance;      // Early return the created instance 
            }

            // Find the active singleton already created
            // reference: https://docs.unity3d.com/ScriptReference/Object.FindObjectOfType.html
            s_Instance = FindObjectOfType<GameCounter>();       // note: this is use during the Awake() logic
            if(s_Instance != null) {
                Debug.Log("DEBUG: GameCounter [case2]: Found the active object in memory");
                return s_Instance;
            }

            Create();     // create new game object 

            return s_Instance;
        }
    }

    // 
    static void Create ()
    {
        Debug.Log("DEBUG: GameCounter [case3]: Create new GameCounter Object");
        GameObject gameCounterObject = new GameObject("GameCounter");
        s_Instance = gameCounterObject.AddComponent<GameCounter> ();
    }

    string InfoGameObject() {
        return GetGameObjectInfo(gameObject);
    }

    public static string GetGameObjectInfo(GameObject obj) {
        return "(" + obj.GetInstanceID() + ":" + obj.name +")";
    }

    void Awake() {
        Debug.Log("DEBUG: GameCounter: Awake() begin. " + InfoGameObject());
        if (Instance != this)
        {
            Debug.Log("DEBUG: GameCounter: will destroy the extra gameObject ");
            Destroy (gameObject);
            return;
        }
        
        Debug.Log("DEBUG: GameCounter: Awake Logic");
        DontDestroyOnLoad(gameObject);      // note: s_Instance become null when switch scene if not place this line of code
        counter = 10;
    }

     void Start() {
        Debug.Log("DEBUG: GameCounter: Start() begin. " + InfoGameObject());
    }



    #endregion

    #region Core Logic  
    public int counter = 0;

    #endregion
}