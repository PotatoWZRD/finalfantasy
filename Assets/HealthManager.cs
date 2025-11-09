using TMPro;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float CurrHealth;
    public float MaxHealth;
    public TextMeshProUGUI healthText;


    public void Start()
    {
        CurrHealth = MaxHealth;
    }

    private void Update()
    {
        HealthUpdate();
    }

    public void OnHit(float damage)
    {
        CurrHealth -= damage;

        if(CurrHealth <=0)
        {
            //LOSE STATE;
        }
    }

    public void HealthUpdate()
    {
        healthText.text = CurrHealth.ToString();

    }


}
