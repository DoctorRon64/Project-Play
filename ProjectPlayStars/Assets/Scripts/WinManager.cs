using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
	[SerializeField] private StarGeneratorData strData;
	[SerializeField] private GameObject feedbackImage;
	[SerializeField] private SpriteRenderer feedbackRndr;
	[SerializeField] private MiniMapMaker MiMaMa;
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();

	private void Start()
	{
        feedbackRndr.enabled = false;
        feedbackRndr.enabled = false;
        feedbackRndr.enabled = false;
    }

	public void CheckIfWon()
    {
        int counter = 0;

        foreach (GameObject realProbe in strData.RealProbesList)
        {
            if (realProbe.GetComponent<RealProbes>().Captured)
            {
                counter++;
            }
            else
            {
                return;
            }
        }

        if (counter == strData.RealProbesList.Count)
        {
            Won();
        }
    }

    public void MiniMapUpdate(GameObject target)
	{
        for (int i = 0; i < strData.RealProbesList.Count; i++)
		{
            if (strData.RealProbesList[i] == target)
			{
                MiMaMa.realProbes[i].SetActive(false);
            }
		}
	}

    public void Feedback(int feedbackIndex)
	{
        feedbackRndr.sprite = sprites[feedbackIndex];
        feedbackImage.GetComponent<Animator>().Play("feedback");
        Debug.Log(feedbackIndex);
    }

    private void Won()
    {
        Debug.Log("game won");
    }

    
}
