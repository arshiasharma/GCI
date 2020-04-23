using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
	public float timeStart = 5;
	public Text textBox;
	public Text endText;
	public GameObject track;

	// Use this for initialization
	void Start()
	{
		textBox.text = timeStart.ToString();
		endText.text = "";
	}

	// Update is called once per frame
	void Update()
	{

        if(timeStart > 0)
        {
			timeStart -= Time.deltaTime;
			textBox.text = Mathf.Round(timeStart).ToString();
		}
		

        else
        {
			endText.text = "Simulation Over";
			timeStart = 0;
			Time.timeScale = 0;
			track.GetComponent<trackController>().track = true;
        }
	}

    
}
