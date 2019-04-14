using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    private Vector3 dash = Vector3.zero;
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
        rb.velocity = movement * speed + dash;
        dash = Vector3.Lerp(dash,Vector3.zero,0.1f);
        if(Input.GetButtonDown("Fire3")) {
          dash = movement * speed*3;
        }
      } else {
        rb.velocity = Vector3.zero;
        animator.SetFloat("Move", 0);
      }
    }
}




