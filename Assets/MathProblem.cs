using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class MathProblem : MonoBehaviour
{

    [SerializeField] TMP_Text question;
    [SerializeField] TMP_InputField answer;
    public bool test = false;
    public bool run = false;
    public int curAns = 0;

    [SerializeField] GameObject coins;
    [SerializeField] GameObject bar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curAns = MakeProblem();
    }

    // Update is called once per frame
    void Update()
    {

        //makes problem
        if (test)
        {
            question.text = "";
            answer.text = "";
            curAns = MakeProblem();
            test = false;
        }

        //checks answer
        if (run)
        {
            if (int.TryParse(answer.text, out int result) && curAns == result)
            {
                question.color = Color.green;
                Debug.Log("answer!");
                StartCoroutine(WaitMath());
                coins.GetComponent<CoinManager>().coins++;
            }
            else
            {
                question.color= Color.red;
                Debug.Log("KILL YOURSELF!");
                StartCoroutine(WaitMath());
            }
            run = false;
        }
    }

    int MakeProblem()
    {
        int num1 = Random.Range(1, 5);
        int num2 = Random.Range(1, 5);
        int ans = num1 + num2;

        question.text = num1 + " + " + num2 + " = ";
        return ans;
    }

    public void onEnterInput()
    {
        run = true;
    }

    IEnumerator WaitMath()
    {
        yield return new WaitForSeconds(2);
        question.color = Color.black;
        question.transform.parent.gameObject.SetActive(false);
        bar.SetActive(true);
    }
}
