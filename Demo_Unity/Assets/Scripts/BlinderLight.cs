using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinderLight : MonoBehaviour
{
    public bool isFlickering = false;
    public float timeDelay;
    public int canalNormal = 1;
    public int canalFlickering = 2;
    public int canalRandomFlickering = 3;
    private float valor = 0;
    private int maxValue = 200; 
    private int canalDmx = 0;
    private DMX dmx;
    private bool flagCanal;

    // Start is called before the first frame update
    void Start()
    {
        dmx = FindObjectOfType<DMX>();
        flagCanal = false;
    }

    // Update is called once per frame
    void Update()
    {
        canalDmx = dmx.getCanalDMX();
        if (canalDmx == canalNormal && isFlickering == false)
        {
            blinderLight();
            flagCanal = true;
        }
        else if (canalDmx == canalFlickering && isFlickering == false)
        {
            StartCoroutine(flickeringLight());
            flagCanal = true;
        }
        else if(canalDmx == canalRandomFlickering && isFlickering == false)
        {
            StartCoroutine(flickeringLightRandom());
            flagCanal = true;
        }
        else
        {
            flagCanal = false;
        }
    }


    void blinderLight()
    {
        if (flagCanal == true)
        {
            valor = dmx.getValorDMX();
        }
        else
        {
            dmx.setValorDMX((int)valor);
        }

        this.gameObject.GetComponent<Light>().enabled = true;
        this.gameObject.GetComponent<Light>().spotAngle = maxValue * valor / 255; ;
    }



    IEnumerator flickeringLight()
    {

        if (flagCanal == true)
        {
            valor = dmx.getValorDMX();
        }
        else
        {
            dmx.setValorDMX((int)valor);
        }

        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = 0.5f;
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        this.gameObject.GetComponent<Light>().spotAngle = maxValue * valor / 255;
        timeDelay = 0.5f;
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }


    IEnumerator flickeringLightRandom()
    {

        if (flagCanal == true)
        {
            valor = dmx.getValorDMX();
        }
        else
        {
            dmx.setValorDMX((int)valor);
        }

        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.5f, 2f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        this.gameObject.GetComponent<Light>().spotAngle = Random.Range(20, 90);
        timeDelay = Random.Range(0.2f, 2f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;

    }
}
