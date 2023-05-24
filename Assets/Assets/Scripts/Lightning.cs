using System.Collections;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] private Light lights; // the light component to be used for the flash
    [SerializeField] private float flashDuration = 0.1f; // the duration of the flash
    [SerializeField] private float flashIntensity = 5f; // the intensity of the flash
    [SerializeField] private float minDelayBetweenFlashes = 0.5f; // the minimum delay between flashes
    [SerializeField] private float maxDelayBetweenFlashes = 5f; // the maximum delay between flashes

    private void Start()
    {
        StartCoroutine(FlashLight());
    }

    private IEnumerator FlashLight()
    {
        while (true)
        {
            // Wait for a random amount of time before the next flash
            yield return new WaitForSeconds(Random.Range(minDelayBetweenFlashes, maxDelayBetweenFlashes));

            // Turn on the light for the specified duration and intensity
            lights.intensity = flashIntensity;
            yield return new WaitForSeconds(flashDuration);
            lights.intensity = 0f;
        }
    }
}
