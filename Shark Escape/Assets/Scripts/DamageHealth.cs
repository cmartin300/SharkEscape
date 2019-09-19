using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHealth : MonoBehaviour
{
    [SerializeField] int damage = 1;
    private PlayerHealth player;

    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        }
        Destroy(gameObject, 6f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.DamageHealth(damage);
            Destroy(gameObject);
        }
    }
}
