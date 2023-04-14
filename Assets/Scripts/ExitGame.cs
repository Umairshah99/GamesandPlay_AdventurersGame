using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Application;

public class ExitGame : MonoBehaviour
{

    public void Exit()
    {
        Debug.Log("Exiting...");
        Application.Quit();

    // #if UNITY_STANDALONE
    //     Application.Quit();
    // #endif
    // #if UNITY_EDITOR
    //     UnityEditor.EditorApplication.isPlaying = false;
    // #endif

    }
}
