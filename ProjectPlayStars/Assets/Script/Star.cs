using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Star : MonoBehaviour
{
	private Light2D StarObject;

	private void Start()
	{
		StarObject = gameObject.GetComponent<Light2D>();
		StarObject.enabled = false;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Flash"))
		{
			StarObject.enabled = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Flash"))
		{
			StarObject.enabled = false;
		}
	}



	[ContextMenu("ParentPos")]
	public void SetPositioinToParent()
	{
		gameObject.transform.position = gameObject.transform.parent.position;
	}
}
