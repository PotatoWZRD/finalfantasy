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

    public GameObject projectile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
        Instantiate(projectile, this.transform);

        yield return new WaitForSeconds(time);
        //Squash, shoot a bullet at a local enemy.
    }
    
}
