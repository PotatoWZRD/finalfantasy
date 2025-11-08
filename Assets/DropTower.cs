using UnityEngine;
using UnityEngine.EventSystems;

public enum TypeOfTower
{
    Pencil,
    Calculator,
    Protractor
}

public class DropTower : MonoBehaviour
{

    public GameObject pencil;
    public GameObject gpencil;
    public TypeOfTower towerType;

    public Color alpha;
    public float test;
    Vector3 mousePos;
    public BoxCollider2D boxCollider;
    private GameObject mouseCursor;
    private bool canPlace;
    public LayerMask layerToHit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        towerType = TypeOfTower.Pencil;

        mouseCursor = Instantiate(gpencil);
        mouseCursor.layer = LayerMask.NameToLayer("Ignore Raycast");
        //mouseCursor.GetComponentInChildren<SpriteRenderer>().color = alpha;
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        mouseWorldPosition.z = 0f;

        int mask = layerToHit & ~(1 << LayerMask.NameToLayer("Tower"));



        Collider2D hitGrass = Physics2D.OverlapPoint(mouseWorldPosition, LayerMask.GetMask("Grass"));
        Collider2D hitClass = Physics2D.OverlapPoint(mouseWorldPosition, LayerMask.GetMask("Class"));

        mouseCursor.transform.position = mouseWorldPosition;

        if (hitGrass != null && hitClass == null)
        {
            mouseCursor.SetActive(true);
            canPlace = true;
        }
        else
        {
            mouseCursor.SetActive(false);
            canPlace = false;
        }


        if (Input.GetMouseButtonDown(0) && canPlace)
        {
            
            GameObject newPencil = Instantiate(pencil, mouseWorldPosition, mouseCursor.transform.rotation);
            newPencil.GetComponent<PencilScript>().hasDropped = true;
            newPencil.layer = LayerMask.NameToLayer("Tower");
        }
        if (Input.GetMouseButtonDown(1)) 
        {
            mouseCursor.transform.Rotate(0, 0, 90);
        }
    }



    public void RayHit(RaycastHit2D hit)
    {
        if (hit.collider.CompareTag("Grass"))
        {
            mouseCursor.SetActive(true);
            canPlace = true;
            Debug.Log(hit.collider.name);
        }
        else
        {
            mouseCursor.SetActive(false);
            canPlace = false;
        }
    }


}