using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Footsteps : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip footstep;
    IEnumerator PlayFootsteps() {
        while(true)
        {
            audioSource.PlayOneShot(footstep, 0.4f);
            yield return new WaitForSeconds(1f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayFootsteps());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
