using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check if the other game object has the ICollectible iterface
        if (collision.gameObject.TryGetComponent(out ICollectible collectible))
        {
            //If it does, call the collect method
            collectible.Collect();

            audioManager.PlaySFX(audioManager.itemPickUp);

        }
        else if (collision.CompareTag("Chest"))
        {
            Destroy(collision.gameObject);
        }
    }

}