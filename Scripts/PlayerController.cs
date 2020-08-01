using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    bool invState = false;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject inventoryState;
    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||  Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1){
            animator.SetFloat("EndHorizontal", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("EndVertical", Input.GetAxisRaw("Vertical"));
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
        if (Input.GetKeyUp(KeyCode.Tab)){
            if (invState == false){
                inventoryState.SetActive(true);
                invState = true;
            }
            else{
                inventoryState.SetActive(false);
                invState = false;
            }
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
