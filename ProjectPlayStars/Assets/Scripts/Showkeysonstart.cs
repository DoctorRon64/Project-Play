using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showkeysonstart : MonoBehaviour
{
    [SerializeField] private GameObject ShowkeysObj;
    [SerializeField] private Animator Anim;
    [SerializeField] private bool KillObject = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
		{
            Anim.Play("TutorialText");
		}

        if (KillObject)
		{
            Destroy(gameObject);
		}
    }
}
