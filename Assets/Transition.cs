using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
	[SerializeField] Transform transitionPoint;
	[SerializeField] bool unlockLeft;
	[SerializeField] bool unlockRight;
	[SerializeField] bool unlockJump;
	[SerializeField] bool unlockMultiJump;
	[SerializeField] bool unlockFly;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.CompareTag("Player")) return;

		collision.gameObject.transform.position = transitionPoint.position;

		collision.gameObject.GetComponent<PlayerMovement>().CanMoveLeft = unlockLeft;
		collision.gameObject.GetComponent<PlayerMovement>().CanMoveRight = unlockRight;
		collision.gameObject.GetComponent<PlayerMovement>().CanJump = unlockJump;
		collision.gameObject.GetComponent<PlayerMovement>().CanMultiJump = unlockMultiJump;
		collision.gameObject.GetComponent<PlayerMovement>().CanFly = unlockFly;
	}
}
