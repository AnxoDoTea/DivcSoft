using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strobe : MonoBehaviour
{
    private int maxValue = 50;
    private float valorZoom = 0;
    public int canalStrobe1 = 15;
    private int canalDmx = 0;
    private DMX dmx;
    private bool flagCanal;
    private GameObject[] luces;
    private GameObject[] strobeLight1;

    private Light foco;

    // Start is called before the first frame update
    void Start()
    {
        dmx = FindObjectOfType<DMX>();
        flagCanal = false;
        strobeLight1 = GameObject.FindGameObjectsWithTag("StrobeLight1");
    }

    // Update is called once per frame
    void Update()
    {
        canalDmx = dmx.getCanalDMX();
        if (canalDmx == canalStrobe1)
        {
            blackout();
            flagCanal = true;
        }
        else
        {
            flagCanal = false;
        }
    }

    void blackout()
    {
        luces = strobeLight1;

        if (flagCanal == true && dmx.getValorDMX() > 0)
        {
            for (int i = 0; i < luces.Length; i++) luces[i].SetActive(true);
            valorZoom = dmx.getValorDMX();

            // Tenemos que normalizar nuestros valores entre 0 y 255 (DMX)
            for (int j = 0; j < luces.Length; j++)
            {
                foco = luces[j].GetComponent<Light>();
                foco.intensity = maxValue * valorZoom / 255;
            }
        }
        else if (flagCanal == true && dmx.getValorDMX() <= 0)
        {
            for (int j = 0; j < luces.Length; j++)
            {
                foco = luces[j].GetComponent<Light>();
                foco.intensity = 1;
            }
        }
        else
        {
            dmx.setValorDMX((int)valorZoom);
        }
    }

}