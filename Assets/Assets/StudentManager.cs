using UnityEngine;
using System.Collections.Generic;

public class StudentManager : MonoBehaviour
{
    [SerializeField] List<GameObject> students = new List<GameObject>();
    public int difficultyVal = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < students.Count; i++)
        {
            students[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(difficultyVal <= 7)
        {
            for (int i = 0; i < difficultyVal; i++)
            {
                if (students[i] != null)
                {
                    students[i].SetActive(true);
                }


            }
        }

    }
}
