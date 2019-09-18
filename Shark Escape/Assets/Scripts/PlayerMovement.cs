using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public GameObject bubblePrefab;
    public TextMeshProUGUI scoreText;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float minXPosition;
    [SerializeField] private float maxXPosition;
    
    
    private float score;
    public float Score { get => score; }

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        score = 0;
        scoreText.text = (score.ToString() + " m");

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
            var bubbles = Instantiate(bubblePrefab, transform.position - Vector3.up * .25f, Quaternion.identity);
            Destroy(bubbles, .3f);
            anim.SetBool("isSwimming", true);
            
            score++;
            scoreText.text = (Score.ToString() + " m");

            if (transform.position.x >= minXPosition && transform.position.x <= maxXPosition)
                transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            else if (transform.position.x > maxXPosition)
                transform.position = new Vector2(maxXPosition, transform.position.y);
            else if (transform.position.x < minXPosition)
                transform.position = new Vector2(minXPosition, transform.position.y);
        } else
        {
            anim.SetBool("isSwimming", false);
        }
    }

}
