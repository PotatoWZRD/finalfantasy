using UnityEngine;
using UnityEngine.UI;

public class EnemyGeneral : MonoBehaviour
{
    public float currHealth;
    public float maxHealth;

    public Slider healthSlider;

    public void Start()
    {
        currHealth = maxHealth;
    }

    public void GetHit()
    {
        currHealth--;
        healthSlider.value = currHealth/maxHealth;
    }


    
}
