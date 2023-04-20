using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private List<AudioClip> audioClips;

	[SerializeField] private int MinTimeTillSound;
	[SerializeField] private int MaxTimeTillSound;

	[SerializeField] private GameObject Hand;
	[SerializeField] private GameObject Light;
	[SerializeField] private StarGeneratorManager strGrMgr;

	private float distanceConstallation;
	private float soundVolume;
	private float soundTimeNextSound;

	private void Start()
	{
		soundTimeNextSound = Random.Range(MinTimeTillSound, MaxTimeTillSound);
		Hand = strGrMgr.StarSystemInScene;
	}


	private void Update()
	{
		distanceConstallation = Vector2.Distance(Light.transform.position, Hand.transform.position);

		soundVolume = 1 - (distanceConstallation / 150);
		audioSource.volume = soundVolume;

		PlayRandomSound();
	}

	private void PlayRandomSound()
	{
		soundTimeNextSound -= Time.deltaTime;

		if (soundTimeNextSound < 0)
		{
			soundTimeNextSound = Random.Range(MinTimeTillSound, MaxTimeTillSound);
			audioSource.clip = audioClips[Random.Range(0, audioClips.Count)];
			audioSource.Play();
		}
	}

}
