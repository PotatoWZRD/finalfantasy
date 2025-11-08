using UnityEngine;

public class MathAppear : MonoBehaviour
{
    public float startTimer = 10;
    public float currentTime = 0;
    public GameObject yippee;

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
        }

    }

    private void OnMouseDown()
    {
        if (yippee.activeSelf)
        {
            yippee.SetActive(false);
            Debug.Log("clicked");
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
