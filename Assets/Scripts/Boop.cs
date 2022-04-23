using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boop : MonoBehaviour
{
	[SerializeField] Color color;
	[SerializeField] float duration;
	private Color initialColor;
	private bool inProgress;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") && !inProgress)
		{
			initialColor = collision.GetComponent<SpriteRenderer>().color;
			StartCoroutine(StartTimer(duration, collision.gameObject));
		}
	}

	IEnumerator StartTimer(float duration, GameObject go)
	{
		inProgress = true;
		go.GetComponent<PlayerMovement>().Boop = true;
		go.GetComponent<SpriteRenderer>().color = color;

		yield return new WaitForSeconds(duration);

		go.GetComponent<PlayerMovement>().Boop = false;
		go.GetComponent<SpriteRenderer>().color = initialColor;
		inProgress = false;
	}
}
