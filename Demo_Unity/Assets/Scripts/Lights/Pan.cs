using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour    //Movimiento lateral (panoramico)
{
    private Transform pivote;
    private static float maxPan = 540;    //Grados
    private float valorPan = 0;
    public int canalSpotLight = 7;
    public int canalBeam = 8;
    public int canalWash = 9;
    private int canalDmx = 0;
    private DMX dmx;
    float x = 0f, y = 0f, z = 0f;     
    private bool flagCanal;
    private GameObject[] luces;
    private List<GameObject> pivotes = new List<GameObject>();
    private ParticleSystem beamLight;

    // Start is called before the first frame update
    void Start()
    {
        dmx = FindObjectOfType<DMX>();
        Vector3 angles = transform.eulerAngles;
        x = angles.x;
        y = angles.y;
        z = angles.z;
        flagCanal = false;
    }

    // Update is called once per frame
    void Update()
    {
        canalDmx = dmx.getCanalDMX();
        if (canalDmx == canalSpotLight || canalDmx == canalBeam || canalDmx == canalWash)
        {
            selectMovingHead();
            pan();
            flagCanal = true;
        }
        else
        {
            flagCanal = false;
        }
    }

    void pan()  //Centraremos en 128
    {
        if (flagCanal == true)
        {
            valorPan = dmx.getValorDMX();
        }
        else
        {
            dmx.setValorDMX((int)valorPan);
        }          
        for(int i = 0; i < pivotes.Count; i++) pivotes[i].transform.rotation = Quaternion.Euler(x, y + maxPan * (valorPan-128) / 255, z);
    }

    void selectMovingHead()
    {
        pivotes.Clear();
        if(canalDmx == canalSpotLight)
        {
            luces = GameObject.FindGameObjectsWithTag("SpotLight1");
            if(luces.Length != 0)
            {
                luces = GameObject.FindGameObjectsWithTag("PanSpot1");
                for (int i = 0; i < luces.Length; i++) pivotes.Add(luces[i]);

            }

            luces = GameObject.FindGameObjectsWithTag("SpotLight2");
            if (luces.Length != 0)
            {
                luces = GameObject.FindGameObjectsWithTag("PanSpot2");
                for (int i = 0; i < luces.Length; i++) pivotes.Add(luces[i]);
            }
        }
        else if(canalDmx == canalBeam)
        {
            luces = GameObject.FindGameObjectsWithTag("Beam");
            beamLight = luces[0].GetComponent<ParticleSystem>();
            if (beamLight.isPlaying)
            {
                luces = GameObject.FindGameObjectsWithTag("PanBeam");
                for (int i = 0; i < luces.Length; i++) pivotes.Add(luces[i]);
            }
        }
        else if(canalDmx == canalWash)
        {
            luces = GameObject.FindGameObjectsWithTag("Wash1");
            if (luces.Length != 0)
            {
                luces = GameObject.FindGameObjectsWithTag("PanWash1");
                for (int i = 0; i < luces.Length; i++) pivotes.Add(luces[i]);

            }

            luces = GameObject.FindGameObjectsWithTag("Wash2");
            if (luces.Length != 0)
            {
                luces = GameObject.FindGameObjectsWithTag("PanWash2");
                for (int i = 0; i < luces.Length; i++) pivotes.Add(luces[i]);

            }

            luces = GameObject.FindGameObjectsWithTag("Wash3");
            if (luces.Length != 0)
            {
                luces = GameObject.FindGameObjectsWithTag("PanWash3");
                for (int i = 0; i < luces.Length; i++) pivotes.Add(luces[i]);

            }

        }
    }
}