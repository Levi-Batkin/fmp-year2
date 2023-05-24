using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSFX : MonoBehaviour
{
    public AudioSource audioSource;
    public Dictionary<Button, AudioClip> buttonSounds = new Dictionary<Button, AudioClip>();

    public Button button1, button2, button3, button4;

    public AudioClip soundEffect;
    void Start()
    {
        // Add each button and its corresponding sound effect to the dictionary
        buttonSounds.Add(button1, soundEffect);
        buttonSounds.Add(button2, soundEffect);
        buttonSounds.Add(button3, soundEffect);
        buttonSounds.Add(button4, soundEffect);

        // Attach the PlaySound() method to each button's onClick event
        foreach (Button button in buttonSounds.Keys)
        {
            button.onClick.AddListener(() => PlaySound(button));
        }
    }

    void PlaySound(Button button)
    {
        // Play the sound effect corresponding to the button
        audioSource.PlayOneShot(buttonSounds[button]);
    }
}
