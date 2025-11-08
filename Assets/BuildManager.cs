using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] GameObject buildMenu;
    [SerializeField] GameObject towerBlock;
    public bool isActive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buildMenu.SetActive(isActive);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isActive) 
            {
                buildMenu.SetActive(true);
                isActive = true;
            }
            else
            {
                buildMenu.SetActive(false);
                isActive = false;
            }
        }

        if (isActive) 
        {
            towerBlock.GetComponent<DropTower>().enabled = false;
        }
        else
        {
            towerBlock.GetComponent<DropTower>().enabled = true;
        }
    }

}
