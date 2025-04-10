using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    PlayerStats playerStats;

    Transform player;
    private void Start()
    {
        //Get the position of the player
        player = FindObjectOfType<PlayerStats>().transform;

        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void Update()
    {
        MoveToPlayer();
    }

    public void MoveToPlayer()
    {
        //Move towards the player's position if they are alive

        if(playerStats.currentHealth > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyData.moveSpeed * Time.deltaTime);

        }


    }
}
