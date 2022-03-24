using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class LightFlicker : MonoBehaviour
{
    private Light2D light2D;
    [SerializeField] private float minIntensity = 0.3f;
    [SerializeField] private float maxIntensity = 1.5f;
    [SerializeField] private float noiseSpeed = 0.15f;
    [SerializeField] private bool flickerON;
    private float randomTimerValue;
    [SerializeField] private float randomTimerValueMIN = 5f;
    [SerializeField] private float randomTimerValueMAX = 20f;
    [SerializeField] private float start_timer_value = 0.1f;

    IEnumerator Start()
    {
        light2D = GetComponent<Light2D>();
        yield return new WaitForSeconds(start_timer_value);
        while (true)
        {
            randomTimerValue = Random.Range(randomTimerValueMIN, randomTimerValueMAX);
            yield return new WaitForSeconds(randomTimerValue);
            if (!flickerON)
                flickerON = !flickerON;

        }
    }

    void Update()
    {
        if (flickerON)
            light2D.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PerlinNoise(10, Time.time / noiseSpeed));
    }
}