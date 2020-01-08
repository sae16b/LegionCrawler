using UnityEngine;

public class Player : MonoBehaviour
{
	public PlayerHealth playerHealth;
	public PlayerMovement playerMovement;
	public PlayerAnimation playerAnimation;

	public string playerName;
	public bool isDead;

	void Start()
	{
		playerHealth = GetComponent<PlayerHealth>();
		playerMovement = GetComponent<PlayerMovement>();
		playerAnimation = GetComponent<PlayerAnimation>();

		playerHealth.OnDamageTaken += OnDamageTaken;
		playerHealth.OnHealthAdded += OnHealthAdded;
		playerHealth.OnDeath += OnDeath;
		playerHealth.AllowDamage = true;

		Spawn();
	}

	/* Update function is being used here to test out damage,
	 * it repeatedly does 5 damage to the player every half a second */

	public float period = 0.0f;
	private void Update()
	{
		if (period > .5f)
		{
			// playerHealth.TakeDamage(5);
			period = 0;
		}
		period += Time.deltaTime;
	}

	void Spawn()
	{
		playerHealth.Current = playerHealth.Max;
		isDead = false;
		playerMovement.canMove = true;
	}

	private void OnDamageTaken(int amt)
	{
		if (!isDead)
		{
			Debug.Log($"{playerName} took {amt} damage!");
			playerHealth.AllowDamage = false;
			playerAnimation.PlayDamageAnim(() =>
			{
				playerHealth.AllowDamage = true;
			});
		}
	}

	private void OnHealthAdded(int amt)
	{
		if (!isDead)
		{
			Debug.Log($"{playerName} health increased by {amt}!");
		}
	}

	private void OnDeath()
	{
		if (!isDead)
		{
			Debug.Log($"{playerName} has passed on :(");
			playerMovement.canMove = false;
			isDead = true;
		}
	}
}
