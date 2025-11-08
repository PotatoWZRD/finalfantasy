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

    //math
    public int num1Min = 0;
    public int num1Max = 10;
    public int num2Min = 0;
    public int num2Max = 10;
    public bool addition, subtraction, multiplication;


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
            answer.ActivateInputField();
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
        int num1 = Random.Range(num1Min, num1Max);
        int num2 = Random.Range(num2Min, num2Max);
        int ans = 0;
        int operation = 0;


        if (addition && subtraction && multiplication)
        {
            operation = Random.Range(0, 3);

            switch (operation)
            {
                case 0:
                    question.text = num1 + " + " + num2 + " = ";
                    ans = num1 + num2;
                    break;
                case 1:
                    question.text = num1 + " - " + num2 + " = ";
                    ans = num1 - num2;
                    break;
                case 2:
                    question.text = num1 + " x " + num2 + " = ";
                    ans = num1 * num2;
                    break;
            }
        }
        else if (addition && subtraction)
        {
            operation = Random.Range(0, 2);

            switch (operation)
            {
                case 0:
                    question.text = num1 + " + " + num2 + " = ";
                    ans = num1 + num2;
                    break;
                case 1:
                    question.text = num1 + " - " + num2 + " = ";
                    ans = num1 - num2;
                    break;
            }
        }
        else if (addition && multiplication)
        {
            operation = Random.Range(0, 2);

            switch (operation)
            {
                case 0:
                    question.text = num1 + " + " + num2 + " = ";
                    ans = num1 + num2;
                    break;
                case 1:
                    question.text = num1 + " x " + num2 + " = ";
                    ans = num1 * num2;
                    break;
            }
        }
        else if (multiplication && subtraction)
        {
            operation = Random.Range(0, 2);

            switch (operation)
            {
                case 0:
                    question.text = num1 + " x " + num2 + " = ";
                    ans = num1 * num2;
                    break;
                case 1:
                    question.text = num1 + " - " + num2 + " = ";
                    ans = num1 - num2;
                    break;
            }
        }
        else if (subtraction)
        {
            question.text = num1 + " - " + num2 + " = ";
            ans = num1 - num2;
        }
        else if (multiplication)
        {
            question.text = num1 + " x " + num2 + " = ";
            ans = num1 * num2;
        }
        else
        {
            question.text = num1 + " + " + num2 + " = ";
            ans = num1 + num2;
        }

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
