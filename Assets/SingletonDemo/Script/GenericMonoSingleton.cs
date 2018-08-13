using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This sample code is based on the Unity Sample Code 2DGameKit/PhysicHelper
public abstract class GenericMonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{   
    #region Singleton Logic
    private static T s_Instance;
    public static T Instance
    {
        get {
            if(s_Instance != null) {
                Debug.Log("DEBUG: GenericMonoSingleton [case1]: returning loaded singleton");
                return s_Instance;      // Early return the created instance 
            }

            T[] objectResult = FindObjectsOfType<T>();
            Debug.Log("DEBUG: GenericMonoSingleton FindObjectsOfType.count=" + objectResult.Length);


            // Find the active singleton already created
            // reference: https://docs.unity3d.com/ScriptReference/Object.FindObjectOfType.html
            s_Instance = FindObjectOfType<T>();       // note: this is use during the Awake() logic
            if(s_Instance != null) {
                Debug.Log("DEBUG: GenericMonoSingleton [case2]: Found the active object in memory");
                return s_Instance;
            }

            Create();     // create new game object 

            return s_Instance;
        }
    }

    

    public void UpdateSingletonName() {
        gameObject.name = GetSingletonName();
    }

    // 
    static void Create ()
    {
        Debug.Log("DEBUG: GenericMonoSingleton [case3]: Create new GameCounter Object");
        GameObject singletonObject = new GameObject("Singleton");
        s_Instance = singletonObject.AddComponent<T> ();       // note: this approach will not apply the setting from prefab
                                                                // this can be replace using prefab 
                                                                //  reference: 2DGameKit: Translator.cs 
                                                                //  using Prefab cannot work with this Generic Singleton
    }

    string InfoGameObject() {
        return GetGameObjectInfo(gameObject);
    }

    public static string GetGameObjectInfo(GameObject obj) {
        return "(" + obj.GetInstanceID() + ":" + obj.name +")";
    }

    #endregion

    #region Manadatory Implementation
    
    protected abstract string GetSingletonName();
    protected virtual bool ShouldDestroyOnLoad() {  
        return false;   // false=Keep object even loading a new scene
    }

    protected virtual void DidAwake() {
    
    }

    #endregion

    #region Initialization Logic

    void Awake() {
        Debug.Log("DEBUG: GenericMonoSingleton: Awake() begin. " + InfoGameObject());
        if (Instance != this)
        {
            Debug.Log("DEBUG: GenericMonoSingleton: will destroy the extra gameObject ");
            Destroy (gameObject);
            return;
        }

        // Start Initialization
        UpdateSingletonName();
        
        Debug.Log("DEBUG: GameCounter: Awake Logic");
        if(ShouldDestroyOnLoad() == false){
            DontDestroyOnLoad(gameObject);      // note: s_Instance become null when switch scene if not place this line of code
        }

        DidAwake();
    }

    #endregion

}