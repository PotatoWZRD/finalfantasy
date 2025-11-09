using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float lime;
    public float timeremaining;
    public TextMeshProUGUI Ttext;
    public void Update()
    {
        timeremaining -= Time.deltaTime;


        int minutes = Mathf.FloorToInt(timeremaining / 60);
        int seconds = Mathf.FloorToInt(timeremaining % 60);
        Ttext.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if(timeremaining <= 0)
        {
            SceneManager.LoadScene("WinScrenen");
        }

    }
}
