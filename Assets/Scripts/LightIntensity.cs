using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;



public class LightIntensity : MonoBehaviour
{
    /*[SerializeField] private Light2D light2D;
    [SerializeField] private float duration = 1f;*/
    public float constantIntens;
    public float inten;
    private float TimeDown = 1f;
    void Update()
    {
        /*// argument for cosine
        var phi = Time.time / duration * 2 * Mathf.PI;
        // get cosine and transform from -1..1 to 0..1 range
        var amplitude = Mathf.Cos(phi) * 0.5 + 0.5;
        // set light color
        light2D.intensity = (float)amplitude;*/

        if (GetComponent<Light2D>().intensity != constantIntens) GetComponent<Light2D>().intensity = constantIntens;

        if (TimeDown > 0) TimeDown -= Time.deltaTime;

        if (TimeDown < 0) TimeDown = 0;

        if (TimeDown == 0)
        {
            inten = Random.Range(0.2f, 4.0f);
            GetComponent<Light2D>().intensity = inten;
            TimeDown = Random.Range(0.2f, 0.6f);
        }
    }
}
