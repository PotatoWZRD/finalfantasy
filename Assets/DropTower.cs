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

    public float placementRadius = 0.5f; // Adjust as needed based on tower size
    public LayerMask towerLayer;         // Assign this in Inspector to your "Tower" layer

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
        mousePos = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        mouseWorldPosition.z = 0f;

        int mask = layerToHit & ~(1 << LayerMask.NameToLayer("Tower"));



        Collider2D hitGrass = Physics2D.OverlapPoint(mouseWorldPosition, LayerMask.GetMask("Grass"));
        Collider2D hitClass = Physics2D.OverlapPoint(mouseWorldPosition, LayerMask.GetMask("Class"));
        Collider2D hitTower = Physics2D.OverlapCircle(mouseWorldPosition, 0.4f, LayerMask.GetMask("Tower"));

        mouseCursor.transform.position = mouseWorldPosition;

        Physics2D.SyncTransforms();
        if (hitGrass != null && hitClass == null && hitTower == null)
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
            Collider2D towerHit = Physics2D.OverlapCircle(mouseWorldPosition, placementRadius, towerLayer);

            if (towerHit == null)
            {
                coinManager.coins -= PencilCost;
                PlaceTower(mouseWorldPosition);
            }
            
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

    public void PENCIL()
    {
            towerType = TypeOfTower.Pencil;
            Destroy(mouseCursor);
            mouseCursor = Instantiate(gPencil);
            mouseCursor.layer = LayerMask.NameToLayer("Ignore Raycast");



    }
    public void RULER()
    {
            towerType = TypeOfTower.Protractor;
            Destroy(mouseCursor);
            mouseCursor = Instantiate(gProt);
            mouseCursor.layer = LayerMask.NameToLayer("Ignore Raycast");

        

    }
    public void CALC()
    {
     
            towerType = TypeOfTower.Calculator;
            Destroy(mouseCursor);
            mouseCursor = Instantiate(gCalc);
            mouseCursor.layer = LayerMask.NameToLayer("Ignore Raycast");



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
            case TypeOfTower.Calculator:
                GameObject newCalculator = Instantiate(calculator, mouseWorldPos, mouseCursor.transform.rotation);
                newCalculator.GetComponent<CalcScript>().hasDropped = true;
                newCalculator.layer = LayerMask.NameToLayer("Tower");
                break;
        }

    }
}