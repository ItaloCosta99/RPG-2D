using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    public Player player;
    public Animator playerAnimator;
    float input_x = 0;
    float input_y = 0;
    bool isWalking = false;

    Rigidbody2D rb2d;
    Vector2 moviment = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        isWalking = false;
        rb2d = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        input_x = Input.GetAxisRaw("Horizontal");
        input_y = Input.GetAxisRaw("Vertical");
        isWalking = (input_x != 0 || input_y != 0);
        moviment = new Vector2(input_x, input_y);
        
        if(isWalking)
        {
            playerAnimator.SetFloat("input_x", input_x);
            playerAnimator.SetFloat("input_y", input_y);
        }

        playerAnimator.SetBool("isWalking", isWalking);

        // if (Input.GetButtonDown("Fire1"))
        //    playerAnimator.SetTrigger("attack");
    }
    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + moviment * player.entity.speed * Time.fixedDeltaTime); ;
    }
}
