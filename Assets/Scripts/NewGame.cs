using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartNewGame(){
        Debug.Log("Changing Scene...");
        SceneManager.LoadScene("Game");
    }
}
