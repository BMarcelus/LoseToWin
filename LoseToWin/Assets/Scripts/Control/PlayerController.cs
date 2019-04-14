using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameManager.player = gameObject;
    }

    void FixedUpdate()
    {
      if(GameManager.playerCanMove) {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        animator.SetFloat("Move", movement.magnitude);
        rb.velocity = movement * speed;
      } else {
        rb.velocity = Vector3.zero;
        animator.SetFloat("Move", 0);
      }
    }
}




