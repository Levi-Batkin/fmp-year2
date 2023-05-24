using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTorch : MonoBehaviour
{
    private bool onToggle = false;
    void Start()
    {
        this.gameObject.GetComponent<Light>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f")) {
            if (onToggle == false) {
                onToggle = true;
                this.gameObject.GetComponent<Light>().enabled = true;
            }
            else
            {
                onToggle = false;
                this.gameObject.GetComponent<Light>().enabled = false;
            }
        }
    }
    
}
