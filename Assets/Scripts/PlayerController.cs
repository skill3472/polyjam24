using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public Transform[] raycastPositions;
    public float groundDetectionThreshold;

    // Start is called before the first frame update
    void Start()
    {
        if(rb==null)
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D) ){
            rb.velocity = new Vector2(speed, rb.velocity.y);
        } else if(Input.GetKey(KeyCode.A) ){
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        } else if(isGrounded()){
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        } else {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }
        if(Input.GetKeyDown(KeyCode.W) && isGrounded()){
            rb.AddForce(Vector2.up * jumpForce);
            Debug.Log(isGrounded());
        }
    }

    bool isGrounded()
    {
        RaycastHit2D[] hits = new RaycastHit2D[3];
        for(int i = 0; i < 3; i++)
        {
            hits[i] = Physics2D.Raycast(raycastPositions[i].position, -Vector2.up);
            if(Vector2.Distance(raycastPositions[i].position, hits[i].point) < groundDetectionThreshold)
                return true;
        }
        return false;
    }
}
