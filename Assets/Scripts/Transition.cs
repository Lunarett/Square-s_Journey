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
	[Space]
	[SerializeField] bool boopTransition;
	[SerializeField] Transform transitionPointIfBoopFailed;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.CompareTag("Player")) return;

		if(!boopTransition)
		{
			collision.gameObject.transform.position = transitionPoint.position;
			collision.gameObject.GetComponent<PlayerMovement>().CanMoveLeft = unlockLeft;
			collision.gameObject.GetComponent<PlayerMovement>().CanMoveRight = unlockRight;
			collision.gameObject.GetComponent<PlayerMovement>().CanJump = unlockJump;
			collision.gameObject.GetComponent<PlayerMovement>().CanMultiJump = unlockMultiJump;
			collision.gameObject.GetComponent<PlayerMovement>().CanFly = unlockFly;
		}
		else
		{
			if(collision.gameObject.GetComponent<PlayerMovement>().Boop)
			{
				collision.gameObject.transform.position = transitionPoint.position;
				collision.gameObject.GetComponent<PlayerMovement>().CanMoveLeft = unlockLeft;
				collision.gameObject.GetComponent<PlayerMovement>().CanMoveRight = unlockRight;
				collision.gameObject.GetComponent<PlayerMovement>().CanJump = unlockJump;
				collision.gameObject.GetComponent<PlayerMovement>().CanMultiJump = unlockMultiJump;
				collision.gameObject.GetComponent<PlayerMovement>().CanFly = unlockFly;
			}
			else
			{
				collision.gameObject.transform.position = transitionPointIfBoopFailed.position;
			}
		}
	}
}
