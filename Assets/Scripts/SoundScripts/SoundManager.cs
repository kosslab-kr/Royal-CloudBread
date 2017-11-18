using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioClip soundMagicAttack;

	static AudioSource myAudio;
    public static SoundManager instance = null;

	// Use this for initialization
    void Awake() //start보다 먼져
    {
        if (SoundManager.instance == null)
            SoundManager.instance = this;
		myAudio = gameObject.GetComponent<AudioSource>();
    }

	void Start () {
        myAudio = GetComponent<AudioSource>();
	}
	public void MagicAttack()
    {
        myAudio.PlayOneShot(soundMagicAttack);
    }
}
