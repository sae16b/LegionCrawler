using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
	public event Action<int> OnDamageTaken;
	public event Action<int> OnHealthAdded;
	public event Action OnDeath;

	public bool AllowDamage = true;

	[SerializeField]
	private int _current;
	public int Current
	{
		get { return _current; }
		set
		{
			_current = Mathf.Clamp(value, 0, Max);
			if (_current == 0)
			{
				OnDeath();
			}
		}
	}

	public int Max;

	public static float PercentHealth(Health health)
	{
		return (float)health.Current / health.Max;
	}

	public void TakeDamage(int amt)
	{
		if (AllowDamage)
		{
			Current -= amt;
			OnDamageTaken(amt);
		}
	}

	public void AddHealth(int amt)
	{
		Current += amt;
		OnHealthAdded(amt);
	}
}
