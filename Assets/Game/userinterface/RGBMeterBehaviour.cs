using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RGBMeterBehaviour : MonoBehaviour
{

    // Use this for initialization
    public Image currentRed;
    public Image currentGreen;
    public Image currentBlue;
    public Image lastRed;
    public Image lastGreen;
    public Image lastBlue;

    public GameObject redPlus;
    public GameObject redMinus;
    public GameObject greenPlus;
    public GameObject greenMinus;
    public GameObject bluePlus;
    public GameObject blueMinus;
    GameObject player;

    private float maximumColorValue = 255f;
    void Start()
    {
        player = GameObject.Find("playerShip");

        currentRed = GameObject.Find("RBar").GetComponent<Image>();
        currentGreen = GameObject.Find("GBar").GetComponent<Image>();
        currentBlue = GameObject.Find("BBar").GetComponent<Image>();

        lastRed = GameObject.Find("LastRBar").GetComponent<Image>();
        lastGreen = GameObject.Find("LastGBar").GetComponent<Image>();
        lastBlue = GameObject.Find("LastBBar").GetComponent<Image>();

        redPlus = GameObject.Find("RedPlus");
        redMinus = GameObject.Find("RedMinus");
        greenPlus = GameObject.Find("GreenPlus");
        greenMinus = GameObject.Find("GreenMinus");
        bluePlus = GameObject.Find("BluePlus");
        blueMinus = GameObject.Find("BlueMinus");

        ClearAllHints();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateCurrentColor()
    {
        currentRed.rectTransform.localScale = new Vector3(1, player.GetComponent<PlayerController>().playerColor.r / maximumColorValue, 1);
        currentGreen.rectTransform.localScale = new Vector3(1, player.GetComponent<PlayerController>().playerColor.g / maximumColorValue, 1);
        currentBlue.rectTransform.localScale = new Vector3(1, player.GetComponent<PlayerController>().playerColor.b / maximumColorValue, 1);
    }
    public void UpdateLastColor()
    {
        lastRed.rectTransform.localScale = currentRed.rectTransform.localScale;
        lastGreen.rectTransform.localScale = currentGreen.rectTransform.localScale;
        lastBlue.rectTransform.localScale = currentBlue.rectTransform.localScale;
    }
    public void UpdateAllHints(float redColorDifference, float greenColorDifference, float blueColorDifference)
    {
        UpdateRedHint(redColorDifference);
        UpdateGreenHint(greenColorDifference);
        UpdateBlueHint(blueColorDifference);
    }

    public void ClearAllHints()
    {
        redPlus.SetActive(false);
        redMinus.SetActive(false);
        greenPlus.SetActive(false);
        greenMinus.SetActive(false);
        bluePlus.SetActive(false);
        blueMinus.SetActive(false);
    }
    public void UpdateRedHint(float colorDifference)
    {
        if (colorDifference < 0)
        {
            redPlus.SetActive(true);
            redMinus.SetActive(false);
        }
        else if (colorDifference > 0)
        {
            redPlus.SetActive(false);
            redMinus.SetActive(true);
        }
        else if (colorDifference == 0)
        {
            redPlus.SetActive(false);
            redMinus.SetActive(false);
        }
    }

    public void UpdateGreenHint(float colorDifference)
    {
        if (colorDifference < 0)
        {
            greenPlus.SetActive(true);
            greenMinus.SetActive(false);
        }
        else if (colorDifference > 0)
        {
            greenPlus.SetActive(false);
            greenMinus.SetActive(true);
        }
        else if (colorDifference == 0)
        {
            greenPlus.SetActive(false);
            greenMinus.SetActive(false);
        }
    }

    public void UpdateBlueHint(float colorDifference)
    {
        if (colorDifference < 0)
        {
            bluePlus.SetActive(true);
            blueMinus.SetActive(false);
        }
        else if (colorDifference > 0)
        {
            bluePlus.SetActive(false);
            blueMinus.SetActive(true);
        }
        else if (colorDifference == 0)
        {
            bluePlus.SetActive(false);
            blueMinus.SetActive(false);
        }
    }
}
