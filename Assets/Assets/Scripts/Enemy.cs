using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
public class Enemy : MonoBehaviour
{
    public Transform target; // Reference to the player character

    private NavMeshAgent agent;
    public GameObject ghostObj;
    public GameObject health1, health2, health3;
    public GameObject enemy1, enemy2, enemy3;
    public bool canFade3, canFade2, canFade1 = true;
    private Color colourFade;
    public bool canAttack = false;

    public GameObject safetext;
    IEnumerator YouAreSafe() {
        canAttack = false;
        safetext.GetComponent<TextMeshProUGUI>().text = "You are now safe for 5 seconds.";
        yield return new WaitForSeconds(1);
        safetext.GetComponent<TextMeshProUGUI>().text = "You are now safe for 4 seconds.";
        yield return new WaitForSeconds(1);
        safetext.GetComponent<TextMeshProUGUI>().text = "You are now safe for 3 seconds.";
        yield return new WaitForSeconds(1);
        safetext.GetComponent<TextMeshProUGUI>().text = "You are now safe for 2 seconds.";
        yield return new WaitForSeconds(1);
        safetext.GetComponent<TextMeshProUGUI>().text = "You are now safe for 1 seconds.";
        yield return new WaitForSeconds(1);
        safetext.GetComponent<TextMeshProUGUI>().text = "You are now vulnerable.";
        canAttack = true;
        yield return new WaitForSeconds(3);
        safetext.GetComponent<TextMeshProUGUI>().text = "";
        this.GetComponent<CapsuleCollider>().enabled=true;
    }
    IEnumerator FlickerEnemy() {
        while(true){
            ghostObj.SetActive(true);
            yield return new WaitForSeconds(2f);
            ghostObj.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator FadeOut1() {
        colourFade = health1.GetComponent<CanvasRenderer>().GetColor();
        colourFade.a = 255;
        while (colourFade.a > 0) {
            colourFade.a--;
        }
        yield return null;
    }
    IEnumerator FadeOut2() {
        colourFade = health2.GetComponent<CanvasRenderer>().GetColor();
        colourFade.a = 255;
        while (colourFade.a > 0) {
            colourFade.a--;
        }
        yield return null;
    }
    IEnumerator FadeOut3() {
        colourFade = health3.GetComponent<CanvasRenderer>().GetColor();
        colourFade.a = 255;
        while (colourFade.a > 0) {
            colourFade.a--;
        }
        health3.SetActive(false);
        yield return null;
    }
    private void Start()
    {
        //safetxt = safetext.GetComponent<TMP_Text>();
        agent = transform.GetComponent<NavMeshAgent>();
        StartCoroutine(FlickerEnemy());
    }
    private void Update()
    {
        if (canAttack) {
            enemy1.SetActive(true);
            enemy2.SetActive(true);
            enemy3.SetActive(true);
            if (target != null)
            {
                agent.SetDestination(target.position);
            }
        }
    }
    
    void OnCollisionEnter(Collision collision) {
        if (canAttack)
        {
            if (collision.gameObject.tag == "Player") {
                this.GetComponent<CapsuleCollider>().enabled=false;
                canAttack=false;
                StartCoroutine(YouAreSafe());
                if(health3.activeSelf) {
                    if (canFade3)
                    {
                        StartCoroutine(FadeOut3());
                        canFade3 = false;
                        health3.SetActive(false);
                    }
                }
                else if(health2.activeSelf) {
                    if (canFade2)
                    {
                        StartCoroutine(FadeOut2());
                        canFade2 = false;
                        health2.SetActive(false);
                    }
                }
                else if(health1.activeSelf) {
                    if (canFade1)
                    {
                        StartCoroutine(FadeOut1());
                        canFade1 = false;
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                }
            }
        }
    }
}
