using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Use this for initialization
    float playerY;
    float playerZ;
    private float playerShipDistanceToScreen;
	public bool isEnabled;
	Vector3 mousePosition;
    void Start()
    {
		isEnabled = true;
        playerY = 0f;
        playerZ = 16.5f;
        playerShipDistanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        transform.position = new Vector3(0f, playerY, playerZ);
    }

    void Update()
    {
        if (isEnabled)
        {
            mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerShipDistanceToScreen);
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(mousePosition).x, playerY, playerZ);
        }
    }
}
