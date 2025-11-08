using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    GameObject target;
    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target!=null)
        {
            Debug.Log(target);
            transform.position = Vector2.MoveTowards(gameObject.transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    public void Target(GameObject enemy)
    {
        Debug.Log("Targeting");

        target = enemy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("ASD");
            collision.GetComponent<EnemyGeneral>().GetHit();
            Destroy(gameObject);
        }
    }
}
