using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EscapeController : MonoBehaviour
{
    System.Random random = new System.Random();
    int choice;
    public GameObject button1, button2, button3, button4, button5, button6, button7, button8;
    // Start is called before the first frame update
    void Start()
    {
        choice = random.Next(1, 9);
        if(choice == 1) {
            button1.SetActive(true);
        }
        else if(choice == 2) {
            button2.SetActive(true);
        }
        else if(choice == 3) {
            button3.SetActive(true);
        }
        else if(choice == 4) {
            button4.SetActive(true);
        }
        else if(choice == 5) {
            button5.SetActive(true);
        }
        else if(choice == 6) {
            button6.SetActive(true);
        }
        else if(choice == 7) {
            button7.SetActive(true);
        }
        else if(choice == 8) {
            button8.SetActive(true);
        }
        else
        {
            button8.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
