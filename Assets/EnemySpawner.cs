using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{

   
    StudentManager studentManager;
    public float timeTillNextSpawn;
    public float time;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        studentManager = GameObject.Find("StudentManager").GetComponent<StudentManager>();
        StartCoroutine(DifficultyScaling());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(studentManager.difficultyVal);
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        time += Time.deltaTime;
        if(time >= timeTillNextSpawn && studentManager.difficultyVal == 1)
        {
            Instantiate(enemy, this.transform);
            time = 0;
            
        }
        else if (time >= timeTillNextSpawn && studentManager.difficultyVal == 2)
        {
            Instantiate(enemy, this.transform);
            GameObject newEn = Instantiate(enemy, this.transform);
            newEn.GetComponent<EnemyMove>().startingPos = StartingPos.Two;
            time = 0;
        }
        else if (time >= timeTillNextSpawn && studentManager.difficultyVal == 3)
        {
            Instantiate(enemy2, this.transform);
            GameObject newEn = Instantiate(enemy, this.transform);
            newEn.GetComponent<EnemyMove>().startingPos = StartingPos.Two;
            GameObject newEn2 = Instantiate(enemy, this.transform);
            newEn.GetComponent<EnemyMove>().startingPos = StartingPos.Three;

            time = 0;
        }
        else if (time >= timeTillNextSpawn && studentManager.difficultyVal == 4)
        {
            Instantiate(enemy2, this.transform);
            GameObject newEn = Instantiate(enemy2, this.transform);
            newEn.GetComponent<EnemyMove>().startingPos = StartingPos.Two;
            GameObject newEn2 = Instantiate(enemy, this.transform);
            newEn.GetComponent<EnemyMove>().startingPos = StartingPos.Three;
            GameObject newEn3 = Instantiate(enemy, this.transform);
            newEn.GetComponent<EnemyMove>().startingPos = StartingPos.Four;
            time = 0;

        }
        else if (time >= timeTillNextSpawn && studentManager.difficultyVal == 5)
        {
            Instantiate(enemy2, this.transform);
            GameObject newEn = Instantiate(enemy2, this.transform);
            newEn.GetComponent<EnemyMove>().startingPos = StartingPos.Two;
            GameObject newEn2 = Instantiate(enemy, this.transform);
            newEn.GetComponent<EnemyMove>().startingPos = StartingPos.Three;
            GameObject newEn3 = Instantiate(enemy, this.transform);
            newEn.GetComponent<EnemyMove>().startingPos = StartingPos.Four;
            GameObject newEn4 = Instantiate(enemy3, this.transform);
            newEn.GetComponent<EnemyMove>().startingPos = StartingPos.Five;
            time = 0;

        }
        else if (time >= timeTillNextSpawn && studentManager.difficultyVal == 6)
        {
            Instantiate(enemy2, this.transform);
            GameObject newEn = Instantiate(enemy2, this.transform);
            newEn.GetComponent<EnemyMove>().startingPos = StartingPos.Two;
            GameObject newEn2 = Instantiate(enemy3, this.transform);
            newEn.GetComponent<EnemyMove>().startingPos = StartingPos.Three;
            GameObject newEn3 = Instantiate(enemy3, this.transform);
            newEn.GetComponent<EnemyMove>().startingPos = StartingPos.Four;
            time = 0;

        }
        else if (time >= timeTillNextSpawn && studentManager.difficultyVal == 7)
        {
            Instantiate(enemy3, this.transform);
            GameObject newEn = Instantiate(enemy3, this.transform);
            newEn.GetComponent<EnemyMove>().startingPos = StartingPos.Two;
            GameObject newEn2 = Instantiate(enemy3, this.transform);
            newEn.GetComponent<EnemyMove>().startingPos = StartingPos.Three;
            GameObject newEn3 = Instantiate(enemy3, this.transform);
            newEn.GetComponent<EnemyMove>().startingPos = StartingPos.Four;
            time = 0;
            GameObject newEn4 = Instantiate(enemy3, this.transform);
            newEn.GetComponent<EnemyMove>().startingPos = StartingPos.Five;
            time = 0;

        }

        switch (studentManager.difficultyVal)
        {
            case 1:
                timeTillNextSpawn = 10;
                break;
            case 2:
                timeTillNextSpawn = 8;
                break;
            case 3:
                timeTillNextSpawn = 5;
                break;
            case 4:
                timeTillNextSpawn = 5;
                break;
            case 5:
                timeTillNextSpawn = 5;
                break;
        }

    }

    IEnumerator DifficultyScaling()
    {
        
        yield return new WaitForSeconds(10f);
        studentManager.difficultyVal = 2;
        yield return new WaitForSeconds(10f);
        studentManager.difficultyVal = 3;
        yield return new WaitForSeconds(20f);
        studentManager.difficultyVal = 4;
        yield return new WaitForSeconds(20f);
        studentManager.difficultyVal = 5;
        yield return new WaitForSeconds(20f);
        studentManager.difficultyVal = 6;
        yield return new WaitForSeconds(20f);
        studentManager.difficultyVal = 7;



    }

}
