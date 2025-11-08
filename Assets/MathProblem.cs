using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class MathProblem : MonoBehaviour
{

    [SerializeField] TMP_Text question;
    [SerializeField] TMP_InputField answer;
    public bool test = false;
    public bool run = false;
    public int curAns = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        curAns = MakeProblem();
    }

    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            curAns = MakeProblem();
            test = false;
        }

        if (run)
        {
            if (int.TryParse(answer.text, out int result) && curAns == result)
            {
                question.color = Color.green;
                Debug.Log("answer!");
            }
            else
            {
                question.color= Color.red;
                Debug.Log("KILL YOURSELF!");
            }
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
}
