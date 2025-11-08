using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ProtracScript : MonoBehaviour
{
    public TypeOfTower towerType;
    public float timeToTick;

    public float time;
    public bool hasDropped;
    public float offset;
    public float localTime;
    public float damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= timeToTick )
        {
            time = 0;
            StartCoroutine(ProtracAttack());
        }



    }

    IEnumerator ProtracAttack()
    {
        Vector2 position = transform.position;
        transform.transform.DORotate(new Vector3(0, 0, -180), localTime, RotateMode.LocalAxisAdd);
        yield return new WaitForSeconds(localTime * 2);
        transform.transform.DORotate(new Vector3(0, 0, 180), localTime, RotateMode.LocalAxisAdd);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("ASD");
            collision.GetComponent<EnemyGeneral>().GetHit(damage);
        }
    }
}
