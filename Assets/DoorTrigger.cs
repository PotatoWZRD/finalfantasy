using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    public HealthManager healthManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthManager = GameObject.Find("CoinManager").GetComponent<HealthManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if(collision.tag == "Enemy")
            {
                healthManager.OnHit(1f);

                Destroy(collision.gameObject);

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
