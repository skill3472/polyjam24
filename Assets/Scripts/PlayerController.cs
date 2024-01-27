using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator pa;
    public float speed;
    public float jumpForce;
    public Transform[] raycastPositions;
    public float groundDetectionThreshold;
    private GameManager gm;
    private int firstSceneNumer = 1;

    // Start is called before the first frame update
    void Start()
    {
        if(rb==null)
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }
        if(gm==null)
        {
            gm = GameObject.Find("_GM").GetComponent<GameManager>();
        }
        if(pa==null)
        {
            pa = gameObject.GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D) ){
            rb.velocity = new Vector2(speed, rb.velocity.y);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            if(isGrounded()) {
                pa.SetBool("isWalking", true);
                pa.SetBool("isJumping", false);
            } else {
                    pa.SetBool("isJumping", true);
                    pa.SetBool("isWalking", false);
                }
        } else if(Input.GetKey(KeyCode.A) ){
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            if(isGrounded()) {
                    pa.SetBool("isWalking", true);
                    pa.SetBool("isJumping", false);
            } else {
                pa.SetBool("isJumping", true);
                pa.SetBool("isWalking", false);
            }
        } else if(isGrounded()){
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
            pa.SetBool("isJumping", false);
            pa.SetBool("isWalking", false);
        } else {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            pa.SetBool("isJumping", true);
            pa.SetBool("isJumping", false);
        }
        if(Input.GetKeyDown(KeyCode.W) && isGrounded()){
            rb.AddForce(Vector2.up * jumpForce);
            pa.SetBool("isJumping", true);
        }

        if(!isGrounded())
            pa.SetBool("isJumping", true);
    }

    bool isGrounded()
    {
        RaycastHit2D[] hits = new RaycastHit2D[3];
        for(int i = 0; i < 3; i++)
        {
            hits[i] = Physics2D.Raycast(raycastPositions[i].position, -Vector2.up);
            if(Vector2.Distance(raycastPositions[i].position, hits[i].point) < groundDetectionThreshold)
            {
                if(hits[i].collider.gameObject.CompareTag("Enemy"))
                {
                   hits[i].collider.gameObject.GetComponent<EnemyDeath>().Die();
                   rb.AddForce(Vector2.up * (jumpForce/1.5f));
                }
                return true;
            }
        }
        return false;
    }

    public void Die(){
        if(gm.difficulty == 0) { // Easy
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else if(gm.difficulty == 1) { // Normal
            SceneManager.LoadScene(firstSceneNumer);
        }
    }
}
