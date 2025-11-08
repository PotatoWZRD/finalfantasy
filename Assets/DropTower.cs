using UnityEngine;

public enum TypeOfTower
{
    Pencil,
    Calculator,
    Protractor
}

public class DropTower : MonoBehaviour
{

    public GameObject pencil;
    public TypeOfTower towerType;


    public float test;
    Vector3 mousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        towerType = TypeOfTower.Pencil;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        mouseWorldPosition.z = 0f;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(pencil, mouseWorldPosition, Quaternion.identity);
        }

    }

    //Time goes down. When it reaches zero, attack.
    /*
     
     
     */


}