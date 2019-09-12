using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    [SerializeField] private GameObject deadBody;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(deadBody, player.position, Quaternion.identity);
            Destroy(player.gameObject);
            Time.timeScale = 0.5f;
            Debug.Log("GameOver!");
        }   
    }
}
