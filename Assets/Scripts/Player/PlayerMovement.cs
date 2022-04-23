using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] float speed;
	[SerializeField] float jumpForce;
	[SerializeField] GroundCheck groundCeck;
	[Space]
	public bool CanMoveLeft;
	public bool CanMoveRight;
	public bool CanJump;


	private Rigidbody2D rb;

	private void Update()
	{
		if(Input.GetKey(KeyCode.A) && CanMoveLeft)
		{
			MoveLeft();
		}

		if(Input.GetKey(KeyCode.D) && CanMoveRight)
		{
			MoveRight();
		}

		if(Input.GetKeyDown(KeyCode.Space) && CanJump)
		{
			Jump();
		}
	}

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	public void MoveLeft()
	{
		rb.velocity += new Vector2(-speed * Time.deltaTime, 0);
	}

	public void MoveRight()
	{
		rb.velocity += new Vector2(speed * Time.deltaTime, 0);
	}

	public void Jump()
	{
		if(groundCeck.isGrounded)
		{
			rb.velocity += new Vector2(0, rb.velocity.y + jumpForce);
		}
	}
}
