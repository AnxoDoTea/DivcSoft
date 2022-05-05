using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wash : MonoBehaviour
{
    private Light foco;
    private int maxValue = 200;
    private float valorWash = 0;
    public int canal = 16;
    private int canalDmx = 0;
    private DMX dmx;
    private bool flagCanal;
    private GameObject[] wash;
    private List<GameObject> luces = new List<GameObject>();

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
        if (canalDmx == canal)
        {
            selectMovingHead();
            doWash();
            flagCanal = true;
        }
        else
        {
            flagCanal = false;
        } 
    }

    void doWash()
    {
        if (flagCanal==true)
        {
            valorWash = dmx.getValorDMX();
        }
        else
        {
            dmx.setValorDMX((int)valorWash);
        }
        // Tenemos que normalizar nuestros valores entre 0 y 255 (DMX)
        for (int j = 0; j < luces.Count; j++)
        {
            foco = luces[j].GetComponent<Light>();
            foco.spotAngle = maxValue * valorWash / 255;
        }
    }

    void selectMovingHead()
    {
        luces.Clear();

        wash = GameObject.FindGameObjectsWithTag("Wash1");
        if (wash.Length != 0)
        {
            for (int i = 0; i < wash.Length; i++) luces.Add(wash[i]);
        }

        wash = GameObject.FindGameObjectsWithTag("Wash2");
        if (wash.Length != 0)
        {
            for (int i = 0; i < wash.Length; i++) luces.Add(wash[i]);
        }

        wash = GameObject.FindGameObjectsWithTag("Wash3");
        if (wash.Length != 0)
        {
            for (int i = 0; i < wash.Length; i++) luces.Add(wash[i]);
        }

    }

}