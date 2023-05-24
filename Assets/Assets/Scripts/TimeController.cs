using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    public TextMeshProUGUI timeobj;
    // Start is called before the first frame update
    private float timeElapsed, daysElapsed;  // time elapsed since the start of the game

    void Start()
    {
        timeElapsed = 0f;
        daysElapsed = 1f;
    }

    void Update()
    {
        // increment time elapsed by 1 second
        timeElapsed += Time.deltaTime;

        // calculate the number of minutes and hours elapsed
        int minutes = Mathf.FloorToInt(timeElapsed / 60f);

        // calculate the remaining seconds
        int seconds = Mathf.FloorToInt(timeElapsed - (minutes * 60f));
        if (minutes == 24)
        {
            minutes = 0;
            daysElapsed++; 
        }
        // update the Text component with the time elapsed

        timeobj.text = string.Format("Day {0:0}: {1:00}:{2:00}", daysElapsed, minutes % 60, seconds % 60);
    }
}
