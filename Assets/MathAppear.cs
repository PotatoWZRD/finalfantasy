using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MathAppear : MonoBehaviour
{
    public float startTimer = 10;
    public float currentTime = 0;
    public GameObject yippee;
    public GameObject barFill;

    [SerializeField] GameObject connectedMath;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        yippee.SetActive(false);
        connectedMath.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!connectedMath.activeSelf)
        {
            currentTime += Time.deltaTime;
        }
        if (currentTime > startTimer)
        {
            yippee.SetActive(true);
            barFill.transform.parent.gameObject.SetActive(false);
        }

        barFill.transform.localScale = new Vector2(barFill.transform.localScale.x, currentTime/startTimer);



        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
                return; // ignore UI clicks

            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mouseWorld.x, mouseWorld.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Clicked on " + hit.collider.name);

                if (hit.collider.gameObject == gameObject)
                {
                    HandleClick();
                }
            }
        }

    void HandleClick()
        {
            if (yippee.activeSelf)
            {
                yippee.SetActive(false);
                connectedMath.SetActive(true);
                connectedMath.GetComponentInChildren<MathProblem>().test = true;
                currentTime = 0;
            }
            else
            {
                Debug.Log("Chud alert");
            }
        }
    }

/*    private void OnMouseDown()
    {
        if (yippee != null && yippee.activeSelf)
        {
            yippee.SetActive(false);
            Debug.Log("clicked");

            if (connectedMath != null)
            {
                connectedMath.SetActive(true);
                var math = connectedMath.GetComponentInChildren<MathProblem>();
                if (math != null) math.test = true;
            }

            currentTime = 0;
        }
        else
        {
            Debug.Log("Chud alert");
        }
    }
*/
}
