using UnityEngine;

public class MathAppear : MonoBehaviour
{
    [SerializeField] GameObject connectedMath;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        connectedMath.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("clicked");
        connectedMath.SetActive(true);
        connectedMath.GetComponentInChildren<MathProblem>().test = true;
    }
}
