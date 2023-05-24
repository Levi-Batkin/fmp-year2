using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Interactions : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask door, button;
    public AudioSource audioSource, musicSource ;
    public AudioClip doorCreak, doorClose, escapeMusic;
    public GameObject interactionHint, movementHint, escapeDoorHint;
    public bool canShowDoorHint = true;
    public bool canPressButton = true;
    public Transform doorA, doorB;
    IEnumerator HintShow() {
        canShowDoorHint = false;
        yield return new WaitForSeconds(3);
        interactionHint.SetActive(false);
    }
    IEnumerator DoorClose() {
        yield return new WaitForSeconds(0.4f);
        audioSource.PlayOneShot(doorClose, 0.4f);
    }
    IEnumerator EscapeRoomMsg() {
        escapeDoorHint.SetActive(true);
        yield return new WaitForSeconds(5);
        escapeDoorHint.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 2f, door))
            {
                Animator animator = hit.collider.gameObject.GetComponent<Animator>();
                if (hit.collider.gameObject.tag == "door")
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).IsName("closed"))
                    {
                        animator.SetTrigger("isOpening");
                        audioSource.PlayOneShot(doorCreak, 0.4f);
                    }
                    else if (animator.GetCurrentAnimatorStateInfo(0).IsName("open"))
                    {
                        animator.SetTrigger("isClosing");
                        StartCoroutine(DoorClose());
                    }   
                }

            }
        }
        if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 2f, door))
        {
            if (canShowDoorHint == true)
            {
                if (!movementHint.activeSelf)
                {
                    if (hit.collider.gameObject.tag == "door") {
                        interactionHint.SetActive(true);
                        StartCoroutine(HintShow());
                    }
                }
            }
        }
        else if (Input.GetKeyDown("e"))
        {
            if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 2f, button))
            {
                if (canPressButton == true)
                {
                    if (hit.collider.gameObject.tag == "button") {
                        canPressButton = false;
                        StartCoroutine(EscapeRoomMsg());
                        doorA.Rotate(0f, 0f, -75f);
                        doorB.Rotate(0f, 0f, 75f);
                        musicSource.Play();
                }
            }
        }
    }
    }
}
