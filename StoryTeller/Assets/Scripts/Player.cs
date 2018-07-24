using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	//Physics
	[Range(2,10)]
	public float walkSpeed = 5f;
	[Range(2,3)]
	public float jumpForce = 2.12f;


	private Rigidbody2D rb2D;
	private Animator animator;

	private bool isGrounded;
	private float xDir;
	//end physics

	//audio
	private AudioSource audio;
	private bool isPlaying = false;




	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		audio = GetComponent<AudioSource>();

	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag == "Ground"){
			isGrounded = true;
			Debug.Log("is grounded");
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		if(collider.gameObject.tag == "Ground"){
			isGrounded = false;
		}
	}

	void OnCollisionEnter2D(Collision2D collider){
		if(collider.gameObject.tag == "Ground"){
			Debug.Log("ground collision");
		}else{
			Debug.Log("unknown collision");
		}
	}
	
	void Jump(){
		rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		animator.Play("Jump");
	}

	void SetAnimator(float xDir){
		if(xDir > 0){
			animator.Play("WalkRight");
		}
		if(xDir < 0){
			animator.Play("WalkLeft");
		}
	}
	// Update is called once per frame
	void Update () {


		xDir = CrossPlatformInputManager.GetAxis("Horizontal");

		if(xDir != 0 && isGrounded){
			Debug.Log("horizontal");
			if(!isPlaying){
				audio.Play();
				isPlaying = true;
			}
			Vector3 move = new Vector3 (xDir * walkSpeed, rb2D.velocity.y, 0f);
			rb2D.velocity = move;
			SetAnimator(xDir);
		}else{
			audio.Stop();
			isPlaying = false;
		}

		if(isGrounded && Input.GetKey("space")){
			Jump();
		}

		if(isGrounded && xDir == 0)
			animator.Play("Idle");
		
	}
}
