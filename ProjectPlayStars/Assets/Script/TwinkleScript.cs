using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TwinkleScript : MonoBehaviour
{
	private Animator anim;

	private void Awake()
	{
		anim = GetComponent<Animator>();
		int AnimatorState = Random.Range(0, 4);
		anim.SetInteger("State", AnimatorState);
	}
}
