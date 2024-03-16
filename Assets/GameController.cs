using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using TMPro;
using System.Diagnostics.Contracts;

public class GameController : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject enemyObject;
    public GameObject UpgradeMenu;
    public GameObject GameFinishedScreen;
    public GameObject GameOverScreen;
    public TextMeshProUGUI pointsText;

    public AudioSource AudioSource;
    public AudioClip BGMuscic;

    public float points = 0;
    public int wave = 0;
    public int enemiesLeft = 0;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.PlayOneShot(BGMuscic);
        //playerObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = "Points: " + points;
    }

    public void NextWave()
    {
        wave += 1;
        StartCoroutine(SpawnEnemies(wave));
    }

    public void FinishGame()
    {
        UpgradeMenu.SetActive(false);
        playerObject.SetActive(false);
        GameFinishedScreen.SetActive(true);
    }

    public void EndGame()
    {
        GameObject[] AllEnemies = new GameObject[enemiesLeft];
        AllEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in AllEnemies) { Destroy(Enemy); }
        playerObject.SetActive(false);
        GameOverScreen.SetActive(true);
        wave = 0;
        enemiesLeft = 0;
        points = 0;
    }

    IEnumerator SpawnEnemies(int wave)
    {
        if (wave == 1)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject EnemySpawned = Instantiate(enemyObject, new Vector3(-7 + 3.5f * i, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "BasicEnemy";
                enemiesLeft++;
            }
            yield return new WaitForSeconds(10f);
            for (int i = 0; i < 5; i++)
            {
                GameObject EnemySpawned = Instantiate(enemyObject, new Vector3(-6 + 3.5f * i, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "BasicEnemy";
                enemiesLeft++;
            }
        }
        if (wave == 2)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject EnemySpawned = Instantiate(enemyObject, new Vector3(-7 + 3.5f * i, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "BasicEnemy";
                enemiesLeft++;
            }
            yield return new WaitForSeconds(10f);
            for (int i = 0; i < 3; i++)
            {
                GameObject EnemySpawned = Instantiate(enemyObject, new Vector3(-5 + 3.3f * i, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
                enemiesLeft++;
            }
            yield return new WaitForSeconds(10f);
            for (int i = 0; i < 5; i++)
            {
                GameObject EnemySpawned = Instantiate(enemyObject, new Vector3(-7 + 3.5f * i, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "BasicEnemy";
                enemiesLeft++;
            }
            yield return new WaitForSeconds(10f);
            for (int i = 0; i < 1; i++)
            {
                GameObject EnemySpawned = Instantiate(enemyObject, new Vector3(0, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
                enemiesLeft++;
            }
        }
        if (wave == 3)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject EnemySpawned = Instantiate(enemyObject, new Vector3(-7 + 3.5f * i, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
                enemiesLeft++;
            }
            for (int i = 0; i < 3; i++)
            {
                GameObject EnemySpawned = Instantiate(enemyObject, new Vector3(-5 + 3.3f * i, 4f, 0f), transform.rotation);
                EnemySpawned.GetComponent<EnemyController>().enemyType = "MovingEnemy";
                enemiesLeft++;
            }
            yield return new WaitForSeconds(10f);
        }
        if (wave == 4)
        {
            GameObject EnemySpawned;
            EnemySpawned = Instantiate(enemyObject, new Vector3(-7, 4f, 0f), transform.rotation);
            EnemySpawned.GetComponent<EnemyController>().enemyType = "BasicEnemy";
            enemiesLeft++;
            EnemySpawned = Instantiate(enemyObject, new Vector3(-3.5f, 4f, 0f), transform.rotation);
            EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
            enemiesLeft++;
            EnemySpawned = Instantiate(enemyObject, new Vector3(0, 4f, 0f), transform.rotation);
            EnemySpawned.GetComponent<EnemyController>().enemyType = "MovingEnemy";
            enemiesLeft++;
            EnemySpawned = Instantiate(enemyObject, new Vector3(3.5f, 4f, 0f), transform.rotation);
            EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
            enemiesLeft++;
            EnemySpawned = Instantiate(enemyObject, new Vector3(7, 4f, 0f), transform.rotation);
            EnemySpawned.GetComponent<EnemyController>().enemyType = "BasicEnemy";
            enemiesLeft++;
            yield return new WaitForSeconds(10f);
            EnemySpawned = Instantiate(enemyObject, new Vector3(-8, 4f, 0f), transform.rotation);
            EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
            enemiesLeft++;
            EnemySpawned = Instantiate(enemyObject, new Vector3(-4f, 4f, 0f), transform.rotation);
            EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
            enemiesLeft++;
            EnemySpawned = Instantiate(enemyObject, new Vector3(0, 4f, 0f), transform.rotation);
            EnemySpawned.GetComponent<EnemyController>().enemyType = "MovingEnemy";
            enemiesLeft++;
            EnemySpawned = Instantiate(enemyObject, new Vector3(4f, 4f, 0f), transform.rotation);
            EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
            enemiesLeft++;
            EnemySpawned = Instantiate(enemyObject, new Vector3(8, 4f, 0f), transform.rotation);
            EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
            enemiesLeft++;
            yield return new WaitForSeconds(10f);
            EnemySpawned = Instantiate(enemyObject, new Vector3(-7, 4f, 0f), transform.rotation);
            EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
            enemiesLeft++;
            EnemySpawned = Instantiate(enemyObject, new Vector3(-3.5f, 4f, 0f), transform.rotation);
            EnemySpawned.GetComponent<EnemyController>().enemyType = "MovingEnemy";
            enemiesLeft++;
            EnemySpawned = Instantiate(enemyObject, new Vector3(0, 4f, 0f), transform.rotation);
            EnemySpawned.GetComponent<EnemyController>().enemyType = "MovingEnemy";
            enemiesLeft++;
            EnemySpawned = Instantiate(enemyObject, new Vector3(3.5f, 4f, 0f), transform.rotation);
            EnemySpawned.GetComponent<EnemyController>().enemyType = "MovingEnemy";
            enemiesLeft++;
            EnemySpawned = Instantiate(enemyObject, new Vector3(7, 4f, 0f), transform.rotation);
            EnemySpawned.GetComponent<EnemyController>().enemyType = "ShieldedEnemy";
            enemiesLeft++;
        }

        //StartCoroutine(SpawnEnemies());
    }

    public void EnemyDied()
    {
        enemiesLeft--;
        if (enemiesLeft <= 0) { UpgradeMenu.SetActive(true); if (wave == 4) { FinishGame(); } }
    }
}
