using UnityEngine;

public class DinoNug : MonoBehaviour, ICollectible
{
    public int healthToRestore;

    public void Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();

        player.RestoreHealth(healthToRestore);

        Destroy(gameObject);
    }
}
