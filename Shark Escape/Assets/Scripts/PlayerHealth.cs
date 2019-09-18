using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthUI;
    [SerializeField] float maxHealth = 5;
    private float health;
    private Transform player;



    private void Awake()
    {
        health = maxHealth;
        healthUI.fillAmount = health / maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void ReplenishHealth()
    {
        health += maxHealth / 5;
        if (health > maxHealth)
            health = maxHealth;

        healthUI.fillAmount = health / maxHealth;
    }
    
    public void DamageHealth(int amount)
    {
        health -= amount;
        healthUI.fillAmount = health / maxHealth;

        if (health <= 0)
        {
            if (player.GetComponent<PlayerMovement>().Score > PlayerPrefs.GetFloat("HighScore"))
            {
                PlayerPrefs.SetFloat("HighScore", player.GetComponent<PlayerMovement>().Score);
            }
            Debug.Log("HighScore: " + PlayerPrefs.GetFloat("HighScore"));
            Destroy(player.gameObject);
            Time.timeScale = 0.5f;
            Debug.Log("GameOver!");
        }
    }

    public float GetHealth ()
    {
        return health;
    }
}
