using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour    //Movimiento lateral (panoramico)
{
    private static float maxTilt = 250;    //Grados
    private float valorTilt = 0;
    public int canalSpotLight = 10;
    public int canalBeam = 11;
    public int canalWash = 12;
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
            tilt();
            flagCanal = true;
        }
        else
        {
            flagCanal = false;
        }            
    }

    public void tilt()  //Centraremos en 128
    {
        if (flagCanal == true)
        {
            valorTilt = dmx.getValorDMX();
        }
        else
        {
            dmx.setValorDMX((int)valorTilt);
        }
        for (int i = 0; i < pivotes.Count; i++) pivotes[i].transform.localRotation = Quaternion.Euler(x + maxTilt * (valorTilt - 45) / 255, 0, 0); //el +60 (antes -128) establece la posición inicial de la cabeza móvil y los límites de la rotación
    }

    void selectMovingHead()
    {
        pivotes.Clear();
        if (canalDmx == canalSpotLight)
        {
            luces = GameObject.FindGameObjectsWithTag("SpotLight1");
            if (luces.Length != 0)
            {
                luces = GameObject.FindGameObjectsWithTag("TiltSpot1");
                for (int i = 0; i < luces.Length; i++) pivotes.Add(luces[i]);

            }

            luces = GameObject.FindGameObjectsWithTag("SpotLight2");
            if (luces.Length != 0)
            {
                luces = GameObject.FindGameObjectsWithTag("TiltSpot2");
                for (int i = 0; i < luces.Length; i++) pivotes.Add(luces[i]);
            }
        }
        else if (canalDmx == canalBeam)
        {
            luces = GameObject.FindGameObjectsWithTag("Beam");
            beamLight = luces[0].GetComponent<ParticleSystem>();
            if (beamLight.isPlaying)
            {
                luces = GameObject.FindGameObjectsWithTag("TiltBeam");
                for (int i = 0; i < luces.Length; i++) pivotes.Add(luces[i]);
            }
        }

        else if (canalDmx == canalWash)
        {
            luces = GameObject.FindGameObjectsWithTag("Wash1");
            if (luces.Length != 0)
            {
                luces = GameObject.FindGameObjectsWithTag("TiltWash1");
                for (int i = 0; i < luces.Length; i++) pivotes.Add(luces[i]);

            }

            luces = GameObject.FindGameObjectsWithTag("Wash2");
            if (luces.Length != 0)
            {
                luces = GameObject.FindGameObjectsWithTag("TiltWash2");
                for (int i = 0; i < luces.Length; i++) pivotes.Add(luces[i]);

            }

            luces = GameObject.FindGameObjectsWithTag("Wash3");
            if (luces.Length != 0)
            {
                luces = GameObject.FindGameObjectsWithTag("TiltWash3");
                for (int i = 0; i < luces.Length; i++) pivotes.Add(luces[i]);

            }
        }

    }
}