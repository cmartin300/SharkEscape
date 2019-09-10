using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float minXPosition;
    [SerializeField] private float maxXPosition;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float direction = Input.GetAxisRaw("Horizontal");

        if (direction < 0)
            anim.SetBool("SwimmingRight", false);
        if (direction > 0)
            anim.SetBool("SwimmingRight", true);

        if (Mathf.Abs(direction) > 0)
        {
            if (transform.position.x >= minXPosition && transform.position.x <= maxXPosition)
                transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            else if (transform.position.x > maxXPosition)
                transform.position = new Vector2(maxXPosition, transform.position.y);
            else if (transform.position.x < minXPosition)
                transform.position = new Vector2(minXPosition, transform.position.y);
        }
    }
}
