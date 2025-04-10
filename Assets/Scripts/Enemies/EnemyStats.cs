using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    AudioManager audioManager;
    public EnemyScriptableObject enemyData;
    EnemySpawner es;

    //Current Stats
    public float currentMoveSpeed;
    public float currentHealth;
    public float currentDamage;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        es = FindObjectOfType<EnemySpawner>();
        currentMoveSpeed = enemyData.moveSpeed;
        currentHealth = enemyData.maxHealth;
        currentDamage = enemyData.attack;
    }

    public void TakeDamage(float dmg)
    {
        Debug.Log("Enemy Took " + dmg + " dmg");
        currentHealth -= dmg;

        audioManager.PlaySFX(audioManager.enemyDmg);

        //Enemy dies
        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Gets PlayerHealth component from collision collider
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();

            ph.TakeDamage(currentDamage);
        }
    }

    private void OnDestroy()
    {

        if(gameObject != null)
        {
            //When an enemy is killed, go to the EnemySpawner script and decrement total enemies alive
            es.OnEnemyKilled();
        }

   
    }

}
