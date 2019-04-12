using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    GameObject Manager;
    GameObject RGBMeter;
    public KeyCode Fire;
    public KeyCode Clear;
    public KeyCode AddRed;
    public KeyCode AddBlue;
    public KeyCode AddGreen;
    public KeyCode SubtractColor;
    ColorRGB playerColor;
	public bool isEnabled;
    void Start()
    {
		isEnabled = true;
        Manager = GameObject.Find("Manager");
        RGBMeter = GameObject.Find("RGBMeter");

        Fire = Manager.GetComponent<Manager>().Fire;
        Clear = Manager.GetComponent<Manager>().Clear;
        AddRed = Manager.GetComponent<Manager>().AddRed;
        AddGreen = Manager.GetComponent<Manager>().AddGreen;
        AddBlue = Manager.GetComponent<Manager>().AddBlue;
        SubtractColor = Manager.GetComponent<Manager>().SubtractColor;

        playerColor = new ColorRGB(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled)
        {
            if (Input.GetKeyDown(Fire))
            {
                FireBullet();
                UpdateLastColor();
                playerColor = new ColorRGB(0, 0, 0);
                UpdateCurrentColor();
            }

            if (Input.GetKeyDown(Clear))
            {
                playerColor = new ColorRGB(0, 0, 0);
                UpdateCurrentColor();
            }

            if (Input.GetKeyDown(AddRed))
            {
                if (Input.GetKey(SubtractColor))
                {
                    playerColor -= new ColorRGB(85, 0, 0);
                }
                else
                {
                    playerColor += new ColorRGB(85, 0, 0);
                }
                UpdateCurrentColor();
            }

            if (Input.GetKeyDown(AddGreen))
            {
                if (Input.GetKey(SubtractColor))
                {
                    playerColor -= new ColorRGB(0, 85, 0);
                }
                else
                {
                    playerColor += new ColorRGB(0, 85, 0);
                }
                UpdateCurrentColor();
            }

            if (Input.GetKeyDown(AddBlue))
            {
                if (Input.GetKey(SubtractColor))
                {
                    playerColor -= new ColorRGB(0, 0, 85);
                }
                else
                {
                    playerColor += new ColorRGB(0, 0, 85);
                }
                UpdateCurrentColor();
            }
        }
    }

    private void UpdateCurrentColor()
    {
        gameObject.GetComponent<PlayerController>().playerColor = playerColor;
        gameObject.GetComponent<PlayerController>().UpdatePlayerColor();
        RGBMeter.GetComponent<RGBMeterBehaviour>().UpdateCurrentColor();
    }

    private void FireBullet()
    {
        gameObject.GetComponent<PlayerController>().FireBullet();
    }
    private void UpdateLastColor()
    {
        RGBMeter.GetComponent<RGBMeterBehaviour>().UpdateLastColor();
    }
}
