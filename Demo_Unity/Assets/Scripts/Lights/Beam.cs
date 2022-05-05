using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    private ParticleSystem beamLight;
    private DMX valorDmx;
    private bool flagCanal;
    public int canal = 3;
    private float valorBeam = 0;
    private int canalBeam = 0;

    private GameObject[] luces;

    // Start is called before the first frame update
    void Start()
    {
        //desactivar el sistema de particulas al iniciar la simulacion
        luces = GameObject.FindGameObjectsWithTag("Beam");

        for (int i = 0; i < luces.Length; i++) 
        {
            beamLight = luces[i].GetComponent<ParticleSystem>();
            beamLight.Pause();
        }
        valorDmx = FindObjectOfType<DMX>();
        flagCanal = false;
    }

    // Update is called once per frame
    void Update()
    {
        canalBeam = valorDmx.getCanalDMX();
        if (canalBeam == canal)
        { 
            beam();
            flagCanal = true;
        }
        else
        {
            flagCanal = false;    
        } 
    }

    void beam()
    {
        if (flagCanal == true)
        {
            valorBeam = valorDmx.getValorDMX();

            //Para valores mayores a 20, se activa el beam. Si no, se apaga
            if (valorBeam >= 20)
            {
                for (int i = 0; i < luces.Length; i++)
                {
                    beamLight = luces[i].GetComponent<ParticleSystem>();
                    beamLight.Play();
                }
 
            }
            else
            {
                for (int i = 0; i < luces.Length; i++)
                {
                    beamLight = luces[i].GetComponent<ParticleSystem>();
                    beamLight.Pause();
                    beamLight.Clear();
                }

            }

        }
        else
        {
            valorDmx.setValorDMX((int)valorBeam);
        }

    }

}