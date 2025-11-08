using UnityEngine;
using DG.Tweening;
using System.Collections;

public class PencilScript : MonoBehaviour
{

    public TypeOfTower towerType;
    public float timeToTick;
    
    public float time;
    public bool hasDropped;
    public float offset;
    public float localTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= timeToTick && hasDropped) 
        {
            time = 0;
            StartCoroutine(PencilAttack());
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("AA");
            transform.position += transform.up  * timeToTick;

        }


    }

    IEnumerator PencilAttack()
    {
        Vector2 position = transform.position;
        transform.DOLocalMove(transform.position + transform.up* offset, localTime);
        yield return new WaitForSeconds(localTime*2);
        transform.DOLocalMove(transform.position - transform.up* offset, localTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Debug.Log("ASD");
            collision.GetComponent<EnemyGeneral>().GetHit();
        }
    }

}
