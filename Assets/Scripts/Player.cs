using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 1f;
    public float jumpForce = 10f;
    bool isJumping = false;
    float moveHorizontal = 0f;
    float moveVertical = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if(moveHorizontal > 0 || moveHorizontal < 0)
        {
            Debug.Log($"Move detected: {moveHorizontal}");
            rb.AddForce(new Vector2(moveSpeed * moveHorizontal, 0f), ForceMode2D.Impulse);
        }

        if(!isJumping && moveVertical > 0)
        {
            Debug.Log($"Jump detected: {moveVertical}");
            rb.AddForce(new Vector2(0f, jumpForce * moveVertical), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            Debug.Log("Platform detected.");
            isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }
}
