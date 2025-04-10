using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 5f;
    public float smoothing;

    public PlayerStats playerStats;

    public Transform target;

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerStats.currentHealth > 0)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);

                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }

      

    }

}
