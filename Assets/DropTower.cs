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

    public Color alpha;
    public float test;
    Vector3 mousePos;

    private GameObject mouseCursor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        towerType = TypeOfTower.Pencil;

        mouseCursor = Instantiate(pencil);
        mouseCursor.GetComponentInChildren<SpriteRenderer>().color = alpha;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        mouseWorldPosition.z = 0f;

        mouseCursor.transform.position = mouseWorldPosition;
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(pencil, mouseWorldPosition, mouseCursor.transform.rotation);
        }
        if (Input.GetMouseButtonDown(1)) 
        {
            mouseCursor.transform.Rotate(0, 0, 90);
        }
    }

    //Time goes down. When it reaches zero, attack.
    /*
     
     
     */


}