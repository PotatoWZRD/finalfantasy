using UnityEngine;
using UnityEngine.UI;

public class EnemyGeneral : MonoBehaviour
{
    public float currHealth;
    public float maxHealth;
    public GameObject enemy1;
    public Slider healthSlider;

    public bool isEnemy2;

    public void Start()
    {
        currHealth = maxHealth;
    }

    public void GetHit(float damage)
    {
        currHealth -= damage;

        if(currHealth <=0 )
        {
            Death();
        }

        healthSlider.value = currHealth/maxHealth;
    }

    public void Death()
    {
        if(isEnemy2)
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

    }

    
}
