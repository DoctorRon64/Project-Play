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
    [SerializeField] private GameObject Telescoop;
    [SerializeField] private GameObject Compass;
    private float AngleCurrentAmount;
    private float AngleAmount;
    private float ZoomInOrOut;
    [SerializeField] private float ZoomMax;
    [SerializeField] private float ZoomMin;
    [SerializeField] private float AngleSpeed;

    [SerializeField] private Transform Library;
    [SerializeField] private Camera cam;

    [SerializeField] private Text AngleText;
    [SerializeField] private Text ZoomText;

    public int ClickAmount;

    void Start()
    {
        ClickAmount = 3;
        ZoomInOrOut = ZoomMax;
    }

    // Update is called once per frame
    void Update()
    {
        TurnScopeAngler();
        ZoomInScroller();
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
        Anglertext *= 360;
        AngleText.text = Anglertext.ToString("F1") + "°";
        AngleAmount = Telescoop.GetComponent<Transform>().rotation.z;
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

        ZoomText.text = ZoomInOrOut.ToString("F3");
    }
}