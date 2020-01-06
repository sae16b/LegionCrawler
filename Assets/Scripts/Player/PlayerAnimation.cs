using System;
using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
	public SpriteRenderer playerSprite;

	void Start()
	{
		playerSprite = GetComponent<SpriteRenderer>();
	}

	public bool playingDamageAnimation = false;
	public void PlayDamageAnim(Action callback)
	{
		StartCoroutine(_playDamageAnim(callback));
	}

	IEnumerator _playDamageAnim(Action callback)
	{
		playingDamageAnimation = true;
		for (int i = 0; i < 5; ++i)
		{
			yield return new WaitForSeconds(.1f);
			playerSprite.enabled = false;
			yield return new WaitForSeconds(.1f);
			playerSprite.enabled = true;
		}
		playingDamageAnimation = false;
		callback();
	}
}
