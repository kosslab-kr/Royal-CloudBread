using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioClip soundMagicAttack;
    AudioSource myAudio;

    public static SoundManager instance;
	// Use this for initialization
    void Awake() //start보다 먼져
    {
        if (SoundManager.instance == null)
            SoundManager.instance = this;
    }

	void Start () {
        myAudio = GetComponent<AudioSource>();
	}
	public void MagicAttack()
    {
        myAudio.PlayOneShot(soundMagicAttack);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
