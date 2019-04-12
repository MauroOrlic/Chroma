using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggernautBehaviour : MonoBehaviour
{
    public GameObject EnemySpawner;
    public float enemyMovementSpeed = 1;
    public ColorRGB[] JuggernautColors;
    public ColorRGB enemyColor;
    public int colorIndex;
    public int scoreValue;
    public int incorrectHits;

    private AudioSource[] audioSources;
    private AudioSource correct;
    private AudioSource incorrect;
    private AudioSource enemyDeath;
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1 * enemyMovementSpeed);
        enemyColor = JuggernautColors[colorIndex];
        gameObject.GetComponent<Renderer>().material.color = enemyColor.getColor();
        gameObject.transform.localScale = new Vector3(2f + colorIndex * 0.2f, 2f + colorIndex * 0.2f, 2f + colorIndex * 0.2f);

        incorrectHits = 0;
        audioSources = gameObject.GetComponents<AudioSource>();
        correct = audioSources[0];
        incorrect = audioSources[1];
        enemyDeath = audioSources[2];
    }
    public void Correct()
    {
        if (colorIndex == 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().increasePlayerLives(1);
            GameObject.Find("GameManager").GetComponent<GameManager>().increaseScore(scoreValue);
            EnemySpawner.GetComponent<EnemySpawner>().CorrectHit();
            Die();
        }
        else
        {
            EnemySpawner.GetComponent<EnemySpawner>().CorrectHit();
            correct.Play();
            colorIndex--;
            enemyColor = JuggernautColors[colorIndex];
            gameObject.GetComponent<Renderer>().material.color = enemyColor.getColor();
            gameObject.transform.localScale = new Vector3(2f + colorIndex * 0.2f, 2f + colorIndex * 0.2f, 2f + colorIndex * 0.2f);
        }
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
        EnemySpawner.GetComponent<EnemySpawner>().IncorrectHit();
        incorrect.Play();
    }
    void Die()
    {
        EnemySpawner.GetComponent<EnemySpawner>().bossActive = false;
        EnemySpawner.GetComponent<EnemySpawner>().spawnDelayTimer = 0f;
        EnemySpawner.GetComponent<EnemySpawner>().enemyCount--;
        gameObject.GetComponent<Rigidbody>().detectCollisions = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Renderer>().enabled = false;
        enemyDeath.Play();
        Destroy(gameObject, 5f);
    }

}
