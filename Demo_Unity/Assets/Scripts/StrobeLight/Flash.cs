using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    private Light foco;
    public static float maxShutterFrequency = 5f;    //Hz
    private float timer = 1 / maxShutterFrequency;
    private float valorShutter = 0;
    public int canal = 2;
    private int canalDmx = 0;
    private DMX dmx;   
    private bool flagCanal;
    private GameObject[] strobeLight;
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
            flash();
            flagCanal = true;
        }
        else
        {
            flagCanal = false;
        }
    }

    void flash()
    {
        if (flagCanal == true)
        {
            valorShutter = dmx.getValorDMX();
        }
        else
        {
            dmx.setValorDMX((int)valorShutter);
        }
        timer -= Time.deltaTime;
        if ((timer < Time.deltaTime) & (valorShutter > 0))
        {
            timer = (1 / maxShutterFrequency) * valorShutter / 255;

            for (int j = 0; j < luces.Count; j++)
            {
                foco = luces[j].GetComponent<Light>();
                foco.enabled = !foco.enabled;
            }
            
        }
        else
        {
            for (int j = 0; j < luces.Count; j++)
            {
                foco = luces[j].GetComponent<Light>();
                foco.enabled = true;
            }
            
        }
    }

    void selectMovingHead()
    {
        luces.Clear();
        
        strobeLight = GameObject.FindGameObjectsWithTag("StrobeLight1");
        if (strobeLight.Length != 0)
        {
            for (int i = 0; i < strobeLight.Length; i++) luces.Add(strobeLight[i]);
        }
    }
}