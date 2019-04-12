using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitterBehaviour : MonoBehaviour
{

    // Use this for initialization
    public GameObject EnemySpawner;
    public float enemyMovementSpeed;
    public ColorRGB splitterColor;
    public int scoreValue;
    public int incorrectHits;

    private AudioSource[] audioSources;
    private AudioSource correct;
    private AudioSource incorrect;
    private AudioSource enemyDeath;
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1 * enemyMovementSpeed);
        gameObject.transform.eulerAngles = new Vector3(90f, 116.5f, 0f);
        UpdateColor();

        incorrectHits = 0;
        audioSources = gameObject.GetComponents<AudioSource>();
        correct = audioSources[0];
        incorrect = audioSources[1];
        enemyDeath = audioSources[2];
    }
    public void Correct()
    {
        EnemySpawner.GetComponent<EnemySpawner>().CorrectHit();
        correct.Play();
    }
    public void Attack()
    {
        EnemySpawner.GetComponent<EnemySpawner>().enemyCount--;
        GameObject.Find("GameManager").GetComponent<GameManager>().increasePlayerLives(-1);
        gameObject.GetComponent<Rigidbody>().detectCollisions = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Renderer>().enabled = false;
        incorrect.Play();
        DestroyObject(gameObject, 4f);
    }

    public void Incorrect()
    {
        incorrectHits++;
        if (incorrectHits > 2)
        {
            scoreValue /= 2;
            scoreValue++;
        }
        EnemySpawner.GetComponent<EnemySpawner>().IncorrectHit();
        incorrect.Play();
    }
    public void UpdateColor()
    {
        gameObject.GetComponent<Renderer>().material.color = splitterColor.getColor();
    }
    public void Die()
    {
        EnemySpawner.GetComponent<EnemySpawner>().enemyCount--;
        GameObject.Find("GameManager").GetComponent<GameManager>().increaseScore(scoreValue);
        gameObject.GetComponent<Rigidbody>().detectCollisions = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Renderer>().enabled = false;
        enemyDeath.Play();
        DestroyObject(gameObject, 4f);
    }
}
