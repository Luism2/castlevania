using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour{
    
  public float jumpForce = 3.0f;
  public float runningSpeed = 0.5f;
    Rigidbody2D rigidBody;
    Animator animator;

    private const string STATE_ALIVE = "isAlive";
    private const string STATE_ON_THE_GROUND = "isOnTheGround";

    public LayerMask groundMask;
    // Start is called before the first frame update
    void Awake(){
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start(){
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND,true);
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)  || Input.GetMouseButtonDown(0)){
            jump();
        }
        
        animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());

        Debug.DrawRay(this.transform.position, Vector2.down*1.5f, Color.red);
    }
    void FixedUpdate(){
        if (rigidBody.velocity.x < runningSpeed){
            rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
        }
    }
    void jump(){
        rigidBody.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
    }
    bool IsTouchingTheGround(){
        if(Physics2D.Raycast(this.transform.position, Vector2.down, 0.7f, groundMask)){

            return true;
        } else{
            return false; 
        }
    }
}