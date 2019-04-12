using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTrackerBehaviour : MonoBehaviour
{

    public Text LifeDisplayValue;
    void Start()
    {
        LifeDisplayValue = GameObject.Find("LifeDisplayValue").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }
	public void UpdateLifeDisplayValue(int newLifeValue)
	{
		LifeDisplayValue.text = newLifeValue.ToString("D2");
	}
}
