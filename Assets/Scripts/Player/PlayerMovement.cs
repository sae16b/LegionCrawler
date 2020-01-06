using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public bool canMove = false;

	public float moveSpeed = 5f;

	public Camera playerCam;
	public int cameraHeight;

	public Rigidbody2D rb;
	public Animator animator;

	Vector2 movement;
	Vector3 cameraPos;

	void Update()
	{
		if (canMove)
		{
			movement.x = Input.GetAxisRaw("Horizontal");
			movement.y = Input.GetAxisRaw("Vertical");
		}
		else
		{
			movement.x = 0;
			movement.y = 0;
		}
		movement.Normalize();

		animator.SetFloat("Horizontal", movement.x);
		animator.SetFloat("Vertical", movement.y);
		animator.SetFloat("Speed", movement.sqrMagnitude);
	}

	void FixedUpdate()
	{
		if (canMove)
		{
			rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
			cameraPos = new Vector3(transform.position.x, transform.position.y, -cameraHeight);
			playerCam.transform.position = cameraPos;
		}
	}
}
