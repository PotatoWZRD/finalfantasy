using TMPro;
using UnityEngine;
using System.Collections;

public class tutorialManager : MonoBehaviour
{
    [SerializeField] TMP_Text tutor;
    [SerializeField] TMP_InputField tutorAnswer;
    [SerializeField] GameObject cameraControl;
    int goal = 2;
    public float tTimer = 0;
    public bool answered = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraControl.GetComponent<CameraScroll>().minZoom = 2;
        cameraControl.GetComponent<CameraScroll>().maxZoom = 2;
        tTimer = 0;
        tutorAnswer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        tTimer += Time.deltaTime;

        if (tTimer <= 2 && !answered)
        {
            tutor.text = " ";
        }
        else if (tTimer > 2 && tTimer <= 6 && !answered)
        {
            tutor.text = "Ugh I'm stumped on this quiz!";
        }
        else if (tTimer > 6 && tTimer <= 8 && !answered)
        {
            tutor.text = "...";
        }
        else if (tTimer > 8 && tTimer <= 11 && !answered)
        {
            tutor.text = "Can you help me?";
        }
        else if (tTimer > 11 && tTimer <= 15 && !answered)
        {
            tutor.text = "Answer the students math questions when they need it!";
        }
        else if (tTimer > 15 && tTimer <= 19 && !answered)
        {
            tutor.text = "Wrong answers mean students are stumped longer!";
        }
        else if (tTimer > 19 && tTimer <= 24 && !answered)
        {
            tutor.text = "Use your A+ points to buy items to stop those demons.";
        }
        else if (tTimer > 24 && tTimer <= 25 && !answered)
        {
            tutor.text = "Oh yeah...";
        }
        else if (tTimer > 25 && tTimer <= 27 && !answered)
        {
            tutor.text = "There are demons who hate math outside.";
        }
        else if (tTimer > 27 && tTimer <= 29 && !answered)
        {
            tutor.text = "Press [SPACE] to open your menu.";
        }
        else if (tTimer > 29 && tTimer <= 32 && !answered)
        {
            tutor.text = "Select and close the menu to place your item.";
        }
        else if (tTimer > 32 && tTimer <= 35 && !answered)
        {
            tutor.text = "[LEFT CLICK] to place, [RIGHT CLICK] to rotate.";
        }
        else if (tTimer > 35 && tTimer <= 37 && !answered)
        {
            tutor.text = "Pencils hit in a straight line";
        }
        else if (tTimer > 37 && tTimer <= 38 && !answered)
        {
            tutor.text = "Rulers sweep!";
        }
        else if (tTimer > 38 && tTimer <= 40 && !answered)
        {
            tutor.text = "And Calcs target the closest enemy!";
        }
        else if (tTimer > 40 && tTimer <= 42 && !answered)
        {
            tutor.text = "...";
        }
        else if (tTimer > 42 && tTimer <= 44 && !answered)
        {
            tutor.text = "Calc is short for calculator!";
        }
        else if (tTimer > 44 && tTimer <= 46 && !answered)
        {
            tutor.text = "...";
        }
        else if (tTimer > 46 && tTimer <= 48 && !answered)
        {
            tutor.text = "Please protect the class!";
        }
        else if (tTimer > 48 && tTimer <= 50 && !answered)
        {
            tutor.text = "We need to pass this test!";
        }
        else if (tTimer > 50)
        {
            tutor.text = "";
            cameraControl.GetComponent<CameraScroll>().minZoom = 5;
            cameraControl.GetComponent<CameraScroll>().maxZoom = 15;
            Destroy(this.transform.parent);
        }
    }
}
