using UnityEngine;
using UnityEngine.UI;

public class EnemyGeneral : MonoBehaviour
{
    public float currHealth;
    public float maxHealth;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public Slider healthSlider;

    public bool isEnemy2;
    public bool isEnemy3;
    public bool isEnemy4;
    audioManager audio;
    public void Start()
    {
        audio = GameObject.Find("AudioManager").GetComponent<audioManager>();

        currHealth = maxHealth;
    }

    public void GetHit(float damage)
    {
        currHealth -= damage;
        audio.PlaySfx(audio.enemyHit);
        if (currHealth <=0 )
        {
            Death();
        }

        healthSlider.value = currHealth/maxHealth;
    }

    public void Death()
    {
        if (isEnemy4)
        {
            Death4();
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
        if (isEnemy3)
        {
            Death3();
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
        if (isEnemy2)
        {
            Death2();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject);

        }

    }

    public void Death2()
    {
        GameObject newEnemy1 = Instantiate(enemy1, this.transform.position, Quaternion.identity);
        newEnemy1.GetComponent<EnemyMove>().waypointIndex= this.GetComponent<EnemyMove>().waypointIndex;
        newEnemy1.GetComponent<EnemyMove>().startingPos = StartingPos.Zero;

    }
    public void Death3()
    {
        GameObject newEnemy2 = Instantiate(enemy2, this.transform.position, Quaternion.identity);
        newEnemy2.GetComponent<EnemyMove>().waypointIndex = this.GetComponent<EnemyMove>().waypointIndex;
        newEnemy2.GetComponent<EnemyMove>().startingPos = StartingPos.Zero;

    }
    public void Death4()
    {
        GameObject newEnemy3 = Instantiate(enemy3, this.transform.position, Quaternion.identity);
        newEnemy3.GetComponent<EnemyMove>().waypointIndex = this.GetComponent<EnemyMove>().waypointIndex;
        newEnemy3.GetComponent<EnemyMove>().startingPos = StartingPos.Zero;

    }

}
