﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResetData : MonoBehaviour {
	SoundManager soundManager;

	void Start(){
		soundManager = FindObjectOfType<SoundManager> ();
		CharacterHolder.Instance.GetPickedCharacter ();
	}

	public void Reset(){
		PlayerPrefs.DeleteAll ();
		LoadingSreen.Show ();

		SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().buildIndex);

		SoundManager.PlaySfx (soundManager.soundClick);
	}

	public void UnlockAll(){
		PlayerPrefs.SetInt (GlobalValue.WorldReached, int.MaxValue);
		for (int i = 1; i < 100; i++) {
			PlayerPrefs.SetInt (i.ToString (), 10000);		//world i, unlock 10000 levels
		}

		LoadingSreen.Show ();
		SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().buildIndex);

		SoundManager.PlaySfx (soundManager.soundClick);
	}
}
