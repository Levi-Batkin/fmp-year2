using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Storyline : MonoBehaviour
{
    public GameObject splash1, splash2, splash3, splash4;
    // Start is called before the first frame update
    IEnumerator Slides() {
        yield return new WaitForSeconds(5f);
        splash1.SetActive(false);
        splash2.SetActive(true);
        yield return new WaitForSeconds(5f);
        splash2.SetActive(false);
        splash3.SetActive(true);
        yield return new WaitForSeconds(5f);
        splash3.SetActive(false);
        splash4.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("mansion");
    }
    void Start()
    {
        splash1.SetActive(true);
        splash2.SetActive(false);
        splash3.SetActive(false);
        splash4.SetActive(false);
        StartCoroutine(Slides());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
