using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    private int maxValue = 3000;
    private float valorZoom = 0;
    public int canalSpotLight1 = 1;
    public int canalSpotLight2 = 2;
    public int canalWash1 = 4;
    public int canalWash2 = 5;
    public int canalWash3 = 6;
    private int canalDmx = 0;
    private DMX dmx;
    private bool flagCanal;
    private GameObject[] luces;
    private GameObject[] spotLight1;
    private GameObject[] spotLight2;
    private GameObject[] wash1;
    private GameObject[] wash2;
    private GameObject[] wash3;
    private Light foco;

    // Start is called before the first frame update
    void Start()
    {
        dmx = FindObjectOfType<DMX>();
        flagCanal = false;
        apagarLuces();
    }

    // Update is called once per frame
    void Update()
    {
        canalDmx = dmx.getCanalDMX();
        if (canalDmx == canalSpotLight1 || canalDmx == canalSpotLight2 || canalDmx == canalWash1 || canalDmx == canalWash2 || canalDmx == canalWash3)
        {
            zoom();
            flagCanal = true;
        }
        else
        {
            flagCanal = false;
        }
    }

    void zoom()
    {
        obtainLights();

        if (flagCanal == true && dmx.getValorDMX() > 0)
        {
            for (int i = 0; i < luces.Length; i++) luces[i].SetActive(true);
            valorZoom = dmx.getValorDMX();
        }
        else
        {
            for (int j = 0; j < luces.Length; j++) luces[j].SetActive(false);
            //dmx.setValorDMX((int)valorZoom);
        }

        // Tenemos que normalizar nuestros valores entre 0 y 255 (DMX)
        for (int j = 0; j < luces.Length; j++)
        {
            foco = luces[j].GetComponent<Light>();
            foco.range = maxValue * valorZoom / 255;
        }

    }

    void obtainLights()
    {
        if(canalDmx == canalSpotLight1) luces = spotLight1;
        if (canalDmx == canalSpotLight2) luces = spotLight2;
        if (canalDmx == canalWash1) luces = wash1;
        if (canalDmx == canalWash2) luces = wash2;
        if (canalDmx == canalWash3) luces = wash3;
    }

    void apagarLuces()
    {
        spotLight1 = GameObject.FindGameObjectsWithTag("SpotLight1");
        for (int i = 0; i < spotLight1.Length; i++) spotLight1[i].SetActive(false);
        spotLight2 = GameObject.FindGameObjectsWithTag("SpotLight2");
        for (int i = 0; i < spotLight2.Length; i++) spotLight2[i].SetActive(false);

        wash1 = GameObject.FindGameObjectsWithTag("Wash1");
        for (int i = 0; i < wash1.Length; i++) wash1[i].SetActive(false);
        wash2 = GameObject.FindGameObjectsWithTag("Wash2");
        for (int i = 0; i < wash2.Length; i++) wash2[i].SetActive(false);
        wash3 = GameObject.FindGameObjectsWithTag("Wash3");
        for (int i = 0; i < wash3.Length; i++) wash3[i].SetActive(false);
    }

}