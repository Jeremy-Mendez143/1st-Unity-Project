using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public static CharacterSelector instance;
    public PlayerScriptableObject characterData;

    private void Awake()
    {
       if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("Multiple Singleton detected.");
            Destroy(gameObject);
        }
    }


    public static PlayerScriptableObject GetData()
    {
        return instance.characterData;
    }

    public void SelectCharacter(PlayerScriptableObject character)
    {
        characterData = character;
    }

    public void DestroySingleton()
    {
        instance = null;
        Destroy(gameObject);
    }

}
