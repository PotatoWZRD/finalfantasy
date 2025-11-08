using DG.Tweening;
using System.Collections;
using UnityEngine;

public class CalcScript : MonoBehaviour
{
    public TypeOfTower towerType;
    public float timeToTick;

    public float time;
    public bool hasDropped;
    public float offset;
    public float localTime;
    bool canAttack;
    public GameObject projectile;

    CircleCollider2D circleCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= timeToTick)
        {
            time = 0;
            StartCoroutine(CalcAttack());
        }



    }

    IEnumerator CalcAttack()
    {
        yield return new WaitForSeconds(time);
        canAttack = true;
        //Squash, shoot a bullet at a local enemy.
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && canAttack)
        {
            canAttack = false;
            GameObject newBullet = Instantiate(projectile, transform.position, transform.rotation);

            newBullet.GetComponent<ProjectileScript>().Target(collision.gameObject);
        }
    }

}
