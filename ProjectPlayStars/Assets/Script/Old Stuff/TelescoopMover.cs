using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class TelescoopMover : MonoBehaviour
{
    public GameObject Telescoop;
    private GameObject Compass;
    private float AngleCurrentAmount;
    private float AngleAmount;
    private float ZoomInOrOut;
    public float ZoomMax;
    public float ZoomMin;
    public float AngleSpeed;

    public bool Winning = false;
    public Transform Library;
    public StarSpawner StarSpawner;
    public ClickToWIN ClickToWIN;
    public GameObject Cellestial;
    public Camera cam;

    public Sprite[] ConstellationIconImg = new Sprite[12];
    public Image ConstellationIcon;
    public GameObject Icon;

    public TMP_Text AngleText;
    public TMP_Text ZoomText;
    
    public int ClickAmount;

    void Start()
    {
        ClickAmount = 3;
        ZoomInOrOut = ZoomMax;
        Telescoop = GameObject.Find("Library");
        Compass = GameObject.Find("Compass");
        Color color = new Color(1, 1, 1, 0);
        ConstellationIcon.GetComponent<Image>().color = color;

        Cellestial = Library.GetChild(0).gameObject;
        ClickToWIN = Cellestial.GetComponent<ClickToWIN>();
        Icon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
	{
        PlayerWinning();

        if (!Winning)
		{
            TurnScopeAngler();
            ZoomInScroller();
        }
    }

    void TurnScopeAngler()
	{
		if (Input.GetKey(KeyCode.D))
		{
			AngleCurrentAmount = AngleSpeed;
		}

		else if (Input.GetKey(KeyCode.A))
		{
			AngleCurrentAmount = -AngleSpeed;
		}

		else
		{
			AngleCurrentAmount = 0;
		}

        if (Input.GetKey(KeyCode.Escape))
		{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (Input.GetKey(KeyCode.R))
		{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

		Telescoop.GetComponent<Transform>().rotation *= Quaternion.Euler(0, 0, AngleCurrentAmount);
        Compass.GetComponent<Transform>().rotation *= Quaternion.Euler(0, 0, AngleCurrentAmount);

        float Anglertext = Telescoop.GetComponent<Transform>().rotation.z;
        AngleText.text = Anglertext.ToString("F3") + "°";
        AngleAmount = Telescoop.GetComponent<Transform>().rotation.z;
        //change the amount that needs to be rounded
        AngleAmount = Mathf.Round(AngleAmount * 100f) / 100f;
    }

    void ZoomInScroller()
	{
        if (ZoomInOrOut > ZoomMax)
		{
            if (Input.GetAxis("Mouse ScrollWheel") < 0f) // forward
            {
                ZoomInOrOut -= 0.0005f;
            }
        }

        if (ZoomInOrOut < ZoomMin)
		{
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                ZoomInOrOut += 0.0005f;
            }
        }
        //Telescoop.GetComponent<Transform>().localScale = new Vector2(ZoomInOrOut, ZoomInOrOut);

        ZoomText.text = ZoomInOrOut.ToString("F3");
    }
    
    void PlayerWinning()
    {
        if (ClickAmount > 0)
		{
            if (ClickToWIN.isWinning == 1)
            {
                Winning = true;
                Color color = new Color(1, 1, 1, 1);
                ConstellationIcon.GetComponent<Image>().color = color;
                ConstellationIcon.GetComponent<Image>().sprite = ConstellationIconImg[StarSpawner.pickstarconstellation];
                UnityEngine.Color colouers = new UnityEngine.Color(1, 1, 1, 0.9f);
                StarSpawner.RevealConstellation.GetComponent<SpriteRenderer>().color = colouers;
                Icon.SetActive(true);
            }
        } 
    }

    /*void ClickWrong()
    {
        if (Input.GetButtonDown(0))
        {
            ClickAmount -= 1;
        }
    }*/
}
