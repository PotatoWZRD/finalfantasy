using UnityEngine;
using DG.Tweening;
using System.Collections;

public class PencilScript : MonoBehaviour
{

    public TypeOfTower towerType;
    public float timeToTick;
    
    public float time;
    public bool hasDropped;
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
            //StartCoroutine(PencilAttack());
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("AA");
            transform.position += transform.up  * timeToTick;

        }


    }

    /*IEnumerator PencilAttack()
    {
        Vector2 position = transform.position;
        transform.DOMove(transform.up * 2, 1f);
        yield return new WaitForSeconds(2f);
        transform.DOMove(-transform.up * 2, 1f);
    }*/


}
