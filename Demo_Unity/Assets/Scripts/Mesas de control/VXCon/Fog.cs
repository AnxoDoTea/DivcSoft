using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    public ParticleSystem fog;
    DMX DMX;
    int canalFOG = 0;
    //int valorFOG = 0;
    [SerializeField] int canal = 20;
    ParticleSystem.VelocityOverLifetimeModule velocityModule;

    // Start is called before the first frame update
    void Start()
    {
        fog.Stop();
        velocityModule = fog.velocityOverLifetime;
        DMX = FindObjectOfType<DMX>();
    }

    // Update is called once per frame
    void Update()
    {

        DMX = FindObjectOfType<DMX>();
        canalFOG = DMX.getCanalDMX();

        //OPCION PARA MANEJAR MAQUINA DE HUMO POR SLIDERS DMX (DESCOMENTAR SI SE QUIERE ESTO)

        /*if(canalFOG == canal) {
        valorFOG = DMX.getValorDMX();

        if (valorFOG == 0)
        {
            fog.Stop();
        }
        else if (valorFOG <= 85 && valorFOG != 0)
        {
            fog.Play();
            velocityModule.zMultiplier = 1;
            Debug.Log("FOG: valor 1");
        }
        else if (valorFOG > 85 && valorFOG <= 170)
        {
            fog.Play();
            velocityModule.zMultiplier = 2;
            Debug.Log("FOG: valor 2");
         }
        else if (valorFOG > 170)
        {
            fog.Play();
            velocityModule.zMultiplier = 3;
            Debug.Log("FOG: valor 3");
        }
        
        }*/

        //OPCION PARA MANEJAR MAQUINA DE HUMO POR SLIDERS DMX (DESCOMENTAR SI SE QUIERE ESTO)

    }

    //------------------------APAGAR HUMO-----------------------------

    public void offFog()
    {
        DMX.setCanalDMX(20);
        canalFOG = DMX.getCanalDMX();

        if(canalFOG==canal) fog.Stop();

    }

    //------------------------EFECTO 1 HUMO---------------------------

    public void fogInt1()
    {
        DMX.setCanalDMX(20);
        canalFOG = DMX.getCanalDMX();

        if (canalFOG == canal)
        {
            fog.Play();
            velocityModule.speedModifier = 1;
            Debug.Log("FOG: valor 1");
        }
    }

    //------------------------EFECTO 2 HUMO---------------------------

    public void fogInt2()
    {
        DMX.setCanalDMX(20);
        canalFOG = DMX.getCanalDMX();

        if (canalFOG == canal)
        {
            fog.Play();
            velocityModule.speedModifier = 2;
            Debug.Log("FOG: valor 2");
        }
    }

    //------------------------EFECTO 3 HUMO---------------------------

    public void fogInt3()
    {
        DMX.setCanalDMX(20);
        canalFOG = DMX.getCanalDMX();

        if (canalFOG == canal)
        {
            fog.Play();
            velocityModule.speedModifier = 3;
            Debug.Log("FOG: valor 3");
        }
    }

}
