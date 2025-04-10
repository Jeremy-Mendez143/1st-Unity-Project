using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void ChangeScene()
    {
        //If Player is dead load the title screen
      
         SceneManager.LoadScene("Title");
        
    }
}
