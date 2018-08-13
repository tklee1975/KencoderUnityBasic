using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This sample code is based on the Unity Sample Code 2DGameKit/PhysicHelper
public class MonoCounter : GenericMonoSingleton<MonoCounter>
{  
    #region Singleton Implementation
    protected override string GetSingletonName() {
        return "MonoCounter";
    }

    protected override bool ShouldDestroyOnLoad() {  
        return true;   // false=Keep object even loading a new scene
    }

    protected override void DidAwake() {
        Debug.Log("DEBUG: MonoCounter.DidAwake. default counter value=" + counter);
    }

    #endregion

    #region Main Logic 

    public int counter = 0;

    #endregion
}