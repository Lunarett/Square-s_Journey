using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
	[SerializeField] LayerMask mask;
	[HideInInspector] public bool isGrounded;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		int otherMask = 1 << collision.gameObject.layer;
		isGrounded = mask == otherMask;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		isGrounded = false;
	}
}
