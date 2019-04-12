using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float enemyMovementSpeed = 1;
    public ColorRGB enemyColor;
    public int scoreValue;
    public int incorrectHits;
    public GameObject EnemySpawner;
    private AudioSource[] audioSources;
    private AudioSource correct;
    private AudioSource incorrect;
    private AudioSource enemyDeath;
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1 * enemyMovementSpeed);
        gameObject.GetComponent<Renderer>().material.color = enemyColor.getColor();
        incorrectHits = 0;
        audioSources = gameObject.GetComponents<AudioSource>();
        correct = audioSources[0];
        incorrect = audioSources[1];
        enemyDeath = audioSources[2];
    }
    public void Correct()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().increaseScore(scoreValue);
        EnemySpawner.GetComponent<EnemySpawner>().CorrectHit();
        enemyDeath.Play();
        Die();
    }
    public void Attack()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().increasePlayerLives(-1);
        incorrect.Play();
        Die();        
    }
    public void Incorrect()
    {
        incorrectHits++;
        if (incorrectHits > 2)
        {
            scoreValue /= 2;
            scoreValue++;
        }
        incorrect.Play();
        EnemySpawner.GetComponent<EnemySpawner>().IncorrectHit();
    }
    void Die(){
        EnemySpawner.GetComponent<EnemySpawner>().enemyCount--;
        gameObject.GetComponent<Rigidbody>().detectCollisions = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Renderer>().enabled = false;
        DestroyObject(gameObject, 4f);
    }
}
