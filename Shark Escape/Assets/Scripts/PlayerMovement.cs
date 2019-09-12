using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float minXPosition;
    [SerializeField] private float maxXPosition;
    [SerializeField] private float maxEnergy;
    private float energy;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        energy = maxEnergy;
    }

    void Update()
    {
        float direction = Input.GetAxisRaw("Horizontal");

        if (direction < 0)
            anim.SetBool("SwimmingRight", false);
        if (direction > 0)
            anim.SetBool("SwimmingRight", true);

        if (Mathf.Abs(direction) > 0 && energy > 0)
        {
            energy -= Time.deltaTime;
            Debug.Log($"<b><color=green>Energy</color>:</b> {energy}");

            if (transform.position.x >= minXPosition && transform.position.x <= maxXPosition)
                transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            else if (transform.position.x > maxXPosition)
                transform.position = new Vector2(maxXPosition, transform.position.y);
            else if (transform.position.x < minXPosition)
                transform.position = new Vector2(minXPosition, transform.position.y);
        }
    }

    public void ReplenishEnergy()
    {
        energy = maxEnergy;
        Debug.Log("Energy Replenished");
        Debug.Log($"<b><color=green>Energy</color>:</b> {energy}");
    }
}
