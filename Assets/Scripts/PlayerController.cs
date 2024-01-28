using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public Rigidbody2D rb;
	private Animator animator;
	public float speed;
	public float jumpForce;
	public Transform[] raycastPositions;
	public float groundDetectionThreshold;
	private GameManager gm;
	private AudioManager am;
	private int firstSceneNumer = 1;
	public PlayerProgress playerProgress;

	void Awake() => animator = GetComponent<Animator>();

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
		if(animator==null)
		{
			animator = gameObject.GetComponent<Animator>();
		}
		am = FindObjectOfType<AudioManager>();

		playerProgress.lastSceneName = SceneManager.GetActiveScene().name;
	}

	void Update()
	{
		if(Input.GetKey(KeyCode.D) ){
			rb.velocity = new Vector2(speed, rb.velocity.y);
			gameObject.GetComponent<SpriteRenderer>().flipX = false;
			if(isGrounded()) {
				if(!animator.GetBool("isWalking") && am != null)
						am.Play("Footstep");
				animator.SetBool("isWalking", true);
				animator.SetBool("isJumping", false);
			} else {
					animator.SetBool("isJumping", true);
					animator.SetBool("isWalking", false);
				}
		} else if(Input.GetKey(KeyCode.A) ){
			rb.velocity = new Vector2(-speed, rb.velocity.y);
			gameObject.GetComponent<SpriteRenderer>().flipX = true;
			if(isGrounded()) {
					if(!animator.GetBool("isWalking") && am != null)
						am.Play("Footstep");
					animator.SetBool("isWalking", true);
					animator.SetBool("isJumping", false);
			} else {
				animator.SetBool("isJumping", true);
				animator.SetBool("isWalking", false);
			}
		} else if(isGrounded()){
			rb.velocity = new Vector2(0.0f, rb.velocity.y);
			//animator.SetBool("isJumping", false);
			//animator.SetBool("isWalking", false);
			SetAnimationsToIdle();
		} else {
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
			animator.SetBool("isJumping", true);
			animator.SetBool("isJumping", false);
		}
		if(Input.GetKeyDown(KeyCode.W) && isGrounded()){
			Jump();
		}

		if(!isGrounded())
			animator.SetBool("isJumping", true);
	}

	public void Jump()
	{
		rb.AddForce(Vector2.up*jumpForce);
		animator.SetBool("isJumping", true);
		am.Play("RobotJump");
	}

	public void JumpWithDoubledForce()
	{
		rb.AddForce(2*jumpForce*Vector2.up);
		animator.SetBool("isJumping", true);
		am.Play("RobotJump");
	}

	public void SetAnimationsToIdle()
	{
		animator.SetBool("isJumping", false);
		animator.SetBool("isWalking", false);
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
		am.Play("GameOver");
		if(gm.difficulty == 0) { // Easy
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		} else if(gm.difficulty == 1) { // Normal
			SceneManager.LoadScene(firstSceneNumer);
		}
	}
}