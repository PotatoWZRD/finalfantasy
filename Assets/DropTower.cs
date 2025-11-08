using System.Collections;
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
    public GameObject protractor;
    public GameObject calculator;
    public GameObject gPencil;
    public GameObject gProt;
    public GameObject gCalc;
    public TypeOfTower towerType;

    public Color alpha;
    public float test;

    public int PencilCost;

    Vector3 mousePos;
    public BoxCollider2D boxCollider;
    private GameObject mouseCursor;
    private bool canPlace;
    public LayerMask layerToHit;
    public CoinManager coinManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        towerType = TypeOfTower.Pencil;

        mouseCursor = Instantiate(gPencil);
        mouseCursor.layer = LayerMask.NameToLayer("Ignore Raycast");
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
        //mouseCursor.GetComponentInChildren<SpriteRenderer>().color = alpha;
    }

    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ChangeTypeOfTower();

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


        if (Input.GetMouseButtonDown(0) && canPlace && coinManager.coins >= PencilCost)
        {
            coinManager.coins -= PencilCost;

            PlaceTower(mouseWorldPosition);



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

    public void ChangeTypeOfTower()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            towerType = TypeOfTower.Pencil;
            Destroy(mouseCursor);
            mouseCursor = Instantiate(gPencil);
            mouseCursor.layer = LayerMask.NameToLayer("Ignore Raycast");

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            towerType = TypeOfTower.Protractor;
            Destroy(mouseCursor);
            mouseCursor = Instantiate(gProt);
            mouseCursor.layer = LayerMask.NameToLayer("Ignore Raycast");

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            towerType = TypeOfTower.Calculator;
            Destroy(mouseCursor);
            mouseCursor = Instantiate(gCalc);
            mouseCursor.layer = LayerMask.NameToLayer("Ignore Raycast");

        }


    }

    public void PlaceTower(Vector3 mouseWorldPos)
    {
        switch (towerType)
        {
            case TypeOfTower.Pencil:
                GameObject newPencil = Instantiate(pencil, mouseWorldPos, mouseCursor.transform.rotation);
                newPencil.GetComponent<PencilScript>().hasDropped = true;
                newPencil.layer = LayerMask.NameToLayer("Tower");
                break;
            case TypeOfTower.Protractor:
                GameObject newProtractor = Instantiate(protractor, mouseWorldPos, mouseCursor.transform.rotation);
                newProtractor.GetComponent<ProtracScript>().hasDropped = true;
                newProtractor.layer = LayerMask.NameToLayer("Tower");
                break;
        }

    }
}