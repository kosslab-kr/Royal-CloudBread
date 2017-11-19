using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour {

    private float time;
    public Text timeText;

	// Use this for initialization
	void Start () {
        time = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        timeText.text = time.ToString("00.00");
        timeText.text = timeText.text.Replace('.', ':');
	}
}
