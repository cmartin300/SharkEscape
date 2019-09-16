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
        health = maxHealth;
        healthUI.fillAmount = health / maxHealth;
    }
    
    public void DamageHealth(int amount)
    {
        health -= amount;
        healthUI.fillAmount = health / maxHealth;

        if (health <= 0)
        {
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
