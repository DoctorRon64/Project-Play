using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Star : MonoBehaviour
{
	private Light2D StarObject;
	private Light2D StarImageObject;

	private void Start()
	{
		StarObject = gameObject.GetComponent<Light2D>();
		StarImageObject = GetComponentInChildren<SpriteRenderer>().GetComponent<Light2D>();
		StarObject.enabled = false;
		StarImageObject.enabled = false;
    }

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Flash"))
		{
			StarObject.enabled = true;
            StarImageObject.enabled = true;

        }
    }

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Flash"))
		{
			StarObject.enabled = false;
            StarImageObject.enabled = false;

        }
    }

	[ContextMenu("ParentPos")]
	public void SetPositioinToParent()
	{
		gameObject.transform.position = gameObject.transform.parent.position;
	}


}
