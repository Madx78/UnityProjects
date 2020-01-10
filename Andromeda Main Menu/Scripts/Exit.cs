using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
  
    // Update is called once per frame
    void Update()
    {
        ExitOnEscape();
    }

     public void ExitOnEscape()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Debug.Log(" Player has quit");
            Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
        }
    }

     public void ExitOnClick()
    {
        Debug.Log(" Player has quit");
        Application.Quit(); // Quitter l'application (fonctionne après le build) 
        //UnityEditor.EditorApplication.isPlaying = false; // quitter le mode lecture Unity
    }
}
