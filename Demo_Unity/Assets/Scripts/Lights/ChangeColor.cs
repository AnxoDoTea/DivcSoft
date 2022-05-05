using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{ 
    private Light foco;
    public static float maxRandomFrequency = 5f;
    private float timer = 1 / maxRandomFrequency;
    private float frecuencia = 0;
    public int canalRojo = 17, canalVerde = 18, canalAzul = 19, canalAleatorio = 20;
    private int canalDMX = 0;
    private DMX dmx;
    static private Color32 color;
    //static private Random rnd = new Random();
    private byte rojo = 255, verde = 255, azul = 255;
    private bool flagCanalRojo, flagCanalVerde, flagCanalAzul, flagCanalAleatorio;
    private GameObject[] wash;
    private List<GameObject> luces = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        dmx = FindObjectOfType<DMX>();
        flagCanalRojo = flagCanalAzul = flagCanalVerde = flagCanalAleatorio = false;
    }

    // Update is called once per frame
    void Update()
    {
        canalDMX = dmx.getCanalDMX();

        if (canalDMX == canalRojo)
        {
            selectMovingHead();
            flagCanalRojo = true;
            colorRojo();
        }
        else
        {
            flagCanalRojo = false;
        }

        if (canalDMX == canalVerde)
        {
            selectMovingHead();
            flagCanalVerde = true;
            colorVerde();
        }
        else
        {
            flagCanalVerde = false;
        }

        if (canalDMX == canalAzul)
        {
            selectMovingHead();
            flagCanalAzul = true;
            colorAzul();
        }
        else
        {
            flagCanalAzul = false;
        }

        if (canalDMX == canalAleatorio)
        {
            selectMovingHead();
            flagCanalAleatorio = true;
            colorAleatorio();
        }
        else
        {
            flagCanalAleatorio = false;
        }

        for (int j = 0; j < luces.Count; j++)
        {
            foco = luces[j].GetComponent<Light>();
            foco.color = new Color32(rojo, verde, azul, 255);
        }

    }

    void colorRojo()
    {
        if (flagCanalRojo == true)
        {
            rojo = (byte)dmx.getValorDMX();
        }
        else
        {
            dmx.setValorDMX((int)rojo);
        }        
    }

    void colorVerde()
    {
        if (flagCanalVerde == true)
        {
            verde = (byte)dmx.getValorDMX();
        }
        else
        {
            dmx.setValorDMX((int)verde);
        }
    }

    void colorAzul()
    {
        if (flagCanalAzul == true)
        {
            azul = (byte)dmx.getValorDMX();
        }
        else
        {
            dmx.setValorDMX((int)azul);
        }
    }

    void colorAleatorio()   //Aplicar timer como en shutter
    {
        if (flagCanalAleatorio == true)
        {
            frecuencia = (byte)dmx.getValorDMX();
        }
        else
        {
            dmx.setValorDMX((int)azul);
        }
        timer -= Time.deltaTime;
        if ((timer < Time.deltaTime) & (frecuencia > 0))
        {
            timer = (1 / maxRandomFrequency) * frecuencia / 255;
            rojo = (byte)Random.Range(0, 256);
            verde = (byte)Random.Range(0, 256);
            azul = (byte)Random.Range(0, 256);
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