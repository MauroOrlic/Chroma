using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public RGBMeterBehaviour RGBMeterBehaviour;
    [SerializeField] float bulletVelocity = 10f;
    [SerializeField] float timeToLive = 4f;
    [SerializeField] int incorrectHitsForHint = 2;
    // Use this for initialization
    public ColorRGB bulletColor;
    void Start()
    {
        //RGBMeterBehaviour = GameObject.Find("RGBMeter").GetComponent<RGBMeterBehaviour>();
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, bulletVelocity);
        gameObject.GetComponent<Renderer>().material.color = bulletColor.getColor();
        DestroyObject(gameObject, timeToLive);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "enemy(Clone)")
        {
            ColorRGB enemyColor = other.GetComponent<EnemyBehaviour>().enemyColor;
            if (bulletColor == enemyColor)
            {
                other.GetComponent<EnemyBehaviour>().Correct();
                RGBMeterBehaviour.ClearAllHints();
            }
            else
            {
                other.GetComponent<EnemyBehaviour>().Incorrect();
                if (other.GetComponent<EnemyBehaviour>().incorrectHits > incorrectHitsForHint)
                {
                    RGBMeterBehaviour.UpdateAllHints(bulletColor.r - enemyColor.r, bulletColor.g - enemyColor.g, bulletColor.b - enemyColor.b);
                }
            }

            Hit();
        }
        else if (other.gameObject.name == "juggernaut(Clone)")
        {
            ColorRGB enemyColor = other.GetComponent<JuggernautBehaviour>().enemyColor;
            if (bulletColor == enemyColor)
            {
                other.GetComponent<JuggernautBehaviour>().Correct();
                RGBMeterBehaviour.ClearAllHints();
            }
            else
            {
                other.GetComponent<JuggernautBehaviour>().Incorrect();
                if (other.GetComponent<JuggernautBehaviour>().incorrectHits > incorrectHitsForHint)
                {
                    RGBMeterBehaviour.UpdateAllHints(bulletColor.r - enemyColor.r, bulletColor.g - enemyColor.g, bulletColor.b - enemyColor.b);
                }
            }
            Hit();
        }
        else if (other.gameObject.name == "splitter(Clone)")
        {
            if (bulletColor.isElementary())
            {
                ColorRGB enemyColor = other.GetComponent<SplitterBehaviour>().splitterColor;

                if (enemyColor == bulletColor)
                {
                    other.GetComponent<SplitterBehaviour>().Die();
                    RGBMeterBehaviour.ClearAllHints();
                }
                else if (enemyColor.r != 0 && bulletColor.r != 0)
                {
                    if (bulletColor.r == enemyColor.r)
                    {
                        other.GetComponent<SplitterBehaviour>().splitterColor.r = 0;
                        other.GetComponent<SplitterBehaviour>().Correct();
                        RGBMeterBehaviour.ClearAllHints();
                    }
                    else
                    {
                        other.GetComponent<SplitterBehaviour>().Incorrect();
                        if (other.GetComponent<SplitterBehaviour>().incorrectHits > incorrectHitsForHint)
                        {
                            RGBMeterBehaviour.UpdateAllHints(bulletColor.r - enemyColor.r, 0, 0);
                        }
                    }
                }
                else if (enemyColor.g != 0 && bulletColor.g != 0)
                {
                    if (bulletColor.g == enemyColor.g)
                    {
                        other.GetComponent<SplitterBehaviour>().splitterColor.g = 0;
                        other.GetComponent<SplitterBehaviour>().Correct();
                        RGBMeterBehaviour.ClearAllHints();
                    }
                    else
                    {
                        other.GetComponent<SplitterBehaviour>().Incorrect();
                        if (other.GetComponent<SplitterBehaviour>().incorrectHits > incorrectHitsForHint)
                        {
                            RGBMeterBehaviour.UpdateAllHints(0, bulletColor.g - enemyColor.g, 0);
                        }
                    }
                }
                else if (enemyColor.b != 0 && bulletColor.b != 0)
                {
                    if (bulletColor.b == enemyColor.b)
                    {
                        other.GetComponent<SplitterBehaviour>().splitterColor.b = 0;
                        other.GetComponent<SplitterBehaviour>().Correct();
                        RGBMeterBehaviour.ClearAllHints();
                    }
                    else
                    {
                        other.GetComponent<SplitterBehaviour>().Incorrect();
                        if (other.GetComponent<SplitterBehaviour>().incorrectHits > incorrectHitsForHint)
                        {
                            RGBMeterBehaviour.UpdateAllHints(0, 0, bulletColor.b - enemyColor.b);
                        }
                    }
                }
                else
                {
                    other.GetComponent<SplitterBehaviour>().Incorrect();
                    if (other.GetComponent<SplitterBehaviour>().incorrectHits > incorrectHitsForHint)
                    {
                        RGBMeterBehaviour.UpdateAllHints(bulletColor.r - enemyColor.r, bulletColor.g - enemyColor.g, bulletColor.b - enemyColor.b);
                    }
                }

                other.GetComponent<SplitterBehaviour>().UpdateColor();
            }
            else
            {
                other.GetComponent<SplitterBehaviour>().Incorrect();
            }

            Hit();
        }
    }
    void Hit()
    {
        gameObject.GetComponent<Rigidbody>().detectCollisions = false;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        DestroyObject(gameObject, 2f);
    }
}
