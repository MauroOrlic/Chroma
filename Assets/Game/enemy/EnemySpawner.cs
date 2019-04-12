using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject enemy;
    [SerializeField] GameObject juggernaut;
    [SerializeField] GameObject splitter;
    private float[] spawnPoints;
    private int lastSpawnPoint;
    private float spawnPositionZ;

    private float initialSpawnDelay;
    private float minSpawnDelay;
    private float currentSpawnDelay;
    public float spawnDelayTimer;

    private float initialMovementSpeed;
    private float maxMovementSpeed;
    private float currentMovementSpeed;

    private float cubeMovementSpeedMultiplier;
    private float juggernautMovementSpeedMultiplier;
    private float splitterMovementSpeedMultiplier;

    private int initialColorComplexity;
    private int maxColorComplexity;
    private int currentColorComplexity;

    public int killStreak;

    public bool bossActive;
    private float juggernautSpawnChance = 0.05f;
    private float splitterSpawnChance = 0.35f;
    private float cubeSpawnChance = 0.60f;
    private int juggernautColorCount;

    public int enemyCount;

    void Start()
    {
        spawnPoints = new float[] { -7.5f, -5f, -2.5f, 0f, 2.5f, 5f, 7.5f };
        lastSpawnPoint = 4;
        spawnPositionZ = 41.75f;

        initialSpawnDelay = 10f;
        minSpawnDelay = 3f;
        currentSpawnDelay = initialSpawnDelay;
        spawnDelayTimer = 0f;

        initialMovementSpeed = 0.85f;
        maxMovementSpeed = 3f;
        currentMovementSpeed = initialMovementSpeed;

        cubeMovementSpeedMultiplier = 1f;
        juggernautMovementSpeedMultiplier = 0.6f;
        splitterMovementSpeedMultiplier = 0.85f;


        initialColorComplexity = 1;
        maxColorComplexity = 2000;
        currentColorComplexity = initialColorComplexity;

        killStreak = 0;

        bossActive = false;

        juggernautColorCount = 4;

        enemyCount = 0;

        InvokeRepeating("increaseMovementSpeed", 1500f, 10f);
        InvokeRepeating("decreaseSpawnDelay", 10f, 10f);
        InvokeRepeating("increaseColorComplexity", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        checkTimers();
    }
    void checkTimers()
    {
        checkSpawnTimer();
    }
    void checkSpawnTimer()
    {
        if (!bossActive)
        {
            if (spawnDelayTimer < 0 || enemyCount == 0)
            {
                spawnDelayTimer = currentSpawnDelay;
                spawnEnemy();
            }
            spawnDelayTimer -= Time.deltaTime;
        }

    }
    void spawnEnemy()
    {
        float roll = Random.Range(0f, 1f);
        if (roll < juggernautSpawnChance)
        {
            spawnJuggernaut();
            bossActive = true;
        }
        else if (roll < juggernautSpawnChance + splitterSpawnChance)
        {
            spawnSplitter();
        }
        else if (roll < juggernautSpawnChance + splitterSpawnChance + cubeSpawnChance)
        {
            spawnCube();
        }
    }
    void spawnCube()
    {
        GameObject enemyInstance = Instantiate(enemy, new Vector3(getSpawnPoint(), 0f, spawnPositionZ), enemy.transform.rotation) as GameObject;
        enemyInstance.GetComponent<EnemyBehaviour>().enemyMovementSpeed = currentMovementSpeed * cubeMovementSpeedMultiplier;
        enemyInstance.GetComponent<EnemyBehaviour>().enemyColor = generateColor();
        enemyInstance.GetComponent<EnemyBehaviour>().scoreValue = Mathf.CeilToInt((Mathf.CeilToInt(currentMovementSpeed) + Mathf.CeilToInt(initialSpawnDelay - currentSpawnDelay + 1)) + killStreak + currentColorComplexity / 10f);
        enemyInstance.GetComponent<EnemyBehaviour>().EnemySpawner = gameObject;

        enemyCount++;
    }
    void spawnJuggernaut()
    {
        GameObject bossInstance;
        bossInstance = Instantiate(juggernaut, new Vector3(getSpawnPoint(), 0f, spawnPositionZ + 1f), enemy.transform.rotation) as GameObject;
        bossInstance.GetComponent<JuggernautBehaviour>().enemyMovementSpeed = currentMovementSpeed * juggernautMovementSpeedMultiplier;
        bossInstance.GetComponent<JuggernautBehaviour>().JuggernautColors = new ColorRGB[juggernautColorCount];
        for (int i = 0; i < juggernautColorCount; i++)
        {
            bossInstance.GetComponent<JuggernautBehaviour>().JuggernautColors[i] = generateColor();
        }
        bossInstance.GetComponent<JuggernautBehaviour>().colorIndex = juggernautColorCount - 1;
        bossInstance.GetComponent<JuggernautBehaviour>().scoreValue = Mathf.CeilToInt((Mathf.CeilToInt(currentMovementSpeed) + Mathf.CeilToInt(initialSpawnDelay - currentSpawnDelay + 1)) + killStreak + currentColorComplexity / 10f) * (juggernautColorCount + 2);
        bossInstance.GetComponent<JuggernautBehaviour>().EnemySpawner = gameObject;
        enemyCount++;
    }
    void spawnSplitter()
    {
        GameObject bossInstance;
        bossInstance = Instantiate(splitter, new Vector3(getSpawnPoint(), 0f, spawnPositionZ), enemy.transform.rotation) as GameObject;
        bossInstance.GetComponent<SplitterBehaviour>().enemyMovementSpeed = currentMovementSpeed * splitterMovementSpeedMultiplier;
        bossInstance.GetComponent<SplitterBehaviour>().splitterColor = generateColor();
        bossInstance.GetComponent<SplitterBehaviour>().scoreValue = Mathf.CeilToInt((Mathf.CeilToInt(currentMovementSpeed) + Mathf.CeilToInt(initialSpawnDelay - currentSpawnDelay + 1)) + killStreak + currentColorComplexity / 10f);
        bossInstance.GetComponent<SplitterBehaviour>().EnemySpawner = gameObject;
        enemyCount++;
    }
    float getSpawnPoint()
    {
        int nextSpawnPoint = Random.Range(0, spawnPoints.Length);

        if (nextSpawnPoint == lastSpawnPoint)
        {
            if (nextSpawnPoint == 0)
            {
                nextSpawnPoint = 1;
            }
            else
            {
                nextSpawnPoint--;
            }
        }
        lastSpawnPoint = nextSpawnPoint;
        return spawnPoints[nextSpawnPoint];
    }
    ColorRGB generateColor()
    {
        float[] color = new float[3];
        int generatorColorComplexity = currentColorComplexity + Random.Range(0, Mathf.CeilToInt(currentColorComplexity / 2f));
        if (generatorColorComplexity < 180)
        {//1. difficulty
            color[0] = 0;
            color[1] = 0;
            color[2] = 0;
            color[Random.Range(0, 3)] = Random.Range(1, 4) * 85f;
        }
        else if (generatorColorComplexity < 360)
        {//2. difficulty

            float randomColor = Random.Range(1, 4) * 85f;
            color[0] = randomColor;
            color[1] = randomColor;
            color[2] = randomColor;
            color[Random.Range(0, 3)] = 0;
        }
        else if (generatorColorComplexity < 720)
        {//3. difficulty
            color[0] = Random.Range(0, 4) * 85f;
            color[1] = Random.Range(0, 4) * 85f;
            color[2] = Random.Range(0, 4) * 85f;
            color[Random.Range(0, 3)] = 0;
        }
        else if (generatorColorComplexity < 1440)
        {//4. difficulty
            float randomColor = Random.Range(0, 4) * 85f;
            color[0] = randomColor;
            color[1] = randomColor;
            color[2] = randomColor;
            color[Random.Range(0, 3)] = Random.Range(0, 4) * 85f;
        }
        else
        {//5. difficulty
            color[0] = Random.Range(0, 4) * 85f;
            color[1] = Random.Range(0, 4) * 85f;
            color[2] = Random.Range(0, 4) * 85f;
        }

        return new ColorRGB(color[0], color[1], color[2]);
    }
    void increaseMovementSpeed()
    {
        currentMovementSpeed = Mathf.Min(maxMovementSpeed, currentMovementSpeed + 0.01f);
    }
    void decreaseSpawnDelay()
    {
        currentSpawnDelay = Mathf.Max(minSpawnDelay, currentSpawnDelay * 0.995f);
    }
    void increaseColorComplexity()
    {
        currentColorComplexity = Mathf.Min(maxColorComplexity, currentColorComplexity + 1);
    }

    public void CorrectHit()
    {
        currentColorComplexity += killStreak;
        killStreak = Mathf.Min(50, killStreak + 1);
    }
    public void IncorrectHit()
    {
        killStreak /= 2;
    }
}
