using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SafeTimer : MonoBehaviour
{
    public TextMeshProUGUI safetext;
    // Start is called before the first frame update
    private float timeElapsed;  // time elapsed since the start of the game
    public Enemy enemyScript1, enemyscript2, enemyscript3;
    public bool canChangeText = true;
    public bool canChangeAttackState = true;
    void Start()
    {
        timeElapsed = 20f;
    }

    void Update()
    {
        // increment time elapsed by 1 second
        timeElapsed -= Time.deltaTime;

        if(timeElapsed <= 0) {
            if (canChangeAttackState == true) {
                canChangeAttackState = false;
                enemyScript1.canAttack = true;
                enemyscript2.canAttack = true;
                enemyscript3.canAttack = true;
                if (canChangeText) {
                    safetext.text = "";
                    canChangeText = false;
                }
            }
        }
        else{
            safetext.text = string.Format("{0:0} seconds until you're vulnerable.", timeElapsed);
        }
    }
}
