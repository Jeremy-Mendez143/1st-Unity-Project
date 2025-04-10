using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    AudioManager audioManager;

    public PlayerStats playerStats;

    public HealthBar healthBar;
    public LevelLoader levelLoader;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();

        levelLoader = FindObjectOfType<LevelLoader>();

        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void Start()
    {

        healthBar.SetMaxHealth(playerStats.maxHealth);
    }

    public void TakeDamage(float dmg)
    {
        if (playerStats != null)
        {
            playerStats.currentHealth -= dmg;

            //Play sound
            audioManager.PlaySFX(audioManager.playerDmg);

            healthBar.SetHealth(playerStats.currentHealth);

            if (playerStats.currentHealth <= 0)
            {
                Kill();
                levelLoader.ChangeScene();
            }
        }
        else
        {
            Debug.LogWarning("PlayerStats not assigned to PlayerHealth!");
        }
    }

    public void RestoreHealth(float amt)
    {
        if (playerStats != null)
        {
            if (playerStats.currentHealth < playerStats.maxHealth)
            {
                amt *= 1 + (playerStats.currentRecovery / 100);
                playerStats.currentHealth += amt;

                playerStats.currentHealth = Mathf.Min(playerStats.currentHealth, playerStats.maxHealth);

                healthBar.SetHealth(playerStats.currentHealth);
            }
        }
        else
        {
            Debug.LogWarning("PlayerStats not assigned to PlayerHealth!");
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
        Debug.Log("Player is dead");
    }

}
