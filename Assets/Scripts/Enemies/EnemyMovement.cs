using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public Rigidbody2D rb;
	public Animator animator;
	public Transform target;
	public Vector2 movement;
	public bool isRunning;
	public float speed;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		movement = target.position - transform.position;

		movement.Normalize();

		animator.SetFloat("Horizontal", movement.x);
		animator.SetFloat("Vertical", movement.y);
		animator.SetBool("Running", isRunning);
	}

	void FixedUpdate()
	{
		if (isRunning)
		{
			rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
		}
	}
}
