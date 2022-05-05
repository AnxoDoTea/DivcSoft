using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class VXCon : MonoBehaviour
{

    private DMX dmx;
    private Light foco_strobo;
    private Light foco_blinder;

    //STROBO
    private GameObject[] strobeLight1;
    private int maxValueStrobo = 50;
    private bool flagOnStrobo = false;

    //BLINDER
    private GameObject[] blinderLight1;
    private int maxValueBlinder = 200;
    private bool flagOnBlinder = false;


    // Start is called before the first frame update
    void Start()
    {
        dmx = FindObjectOfType<DMX>();
        strobeLight1 = GameObject.FindGameObjectsWithTag("StrobeLight1");
        blinderLight1 = GameObject.FindGameObjectsWithTag("BlinderLight1");
        stroboOff();
        blinderOff();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //-------------------------------------BOTONES STROBO-------------------------------------



    //-------------BOTÓN BLACKOUT-------------
    public void strobeBlackout()
    {
        for (int i = 0; i < strobeLight1.Length; i++)
        {
            strobeLight1[i].SetActive(true);
        }

        flagOnStrobo = true;
        dmx.setCanalDMX(15);
        dmx.setValorDMX(255);
        blackout();

    }

    //-------------BOTÓN FLASH-------------
    public void strobeFlash()
    {
        if (flagOnStrobo)
        {
            StartCoroutine("flashRutine");
        }
    }

    //-------------BOTÓN OFF STROBO-------------
    public void stroboOff()
    {
        for (int i = 0; i < strobeLight1.Length; i++)
        {
            strobeLight1[i].SetActive(false);
        }

        flagOnStrobo = false;
        StopCoroutine("flashRutine");
    }



    //-------------------------------------BOTONES BLINDER-------------------------------------



    //-------------BOTÓN ENCENDER CEGADORAS-------------
    public void blinderOn()
    {
        for (int i = 0; i < blinderLight1.Length; i++)
        {
            blinderLight1[i].SetActive(true);
        }

        flagOnBlinder = true;
        dmx.setCanalDMX(17);
        dmx.setValorDMX(10);
        blinderActivation();
    }

    //-------------BOTÓN PARTY CEGADORA-------------
    public void blinderParty()
    {
        if (flagOnBlinder)
        {
            StartCoroutine("blinderRutine");
        }
    }



    //-------------BOTÓN OFF BLINDER-------------
    public void blinderOff()
    {
        for (int i = 0; i < blinderLight1.Length; i++)
        {
            blinderLight1[i].SetActive(false);
        }

        flagOnBlinder = false;
        StopCoroutine("blinderRutine");
    }

    //--------------------------------------------STROBO-------------------------------------

    public void blackout()
    {
        int valorBlackout = 0;

        if (dmx.getCanalDMX() == 15)
        {
            valorBlackout = dmx.getValorDMX();
        }

        for (int i = 0; i < strobeLight1.Length; i++)
        {
            foco_strobo = strobeLight1[i].GetComponent<Light>();
            foco_strobo.intensity = maxValueStrobo * valorBlackout / 255;
        }
    }

    public void flash()
    {
        int valorFlash = 0;

        if (dmx.getCanalDMX() == 16)
        {
            valorFlash = dmx.getValorDMX();
        }

        for (int i = 0; i < strobeLight1.Length; i++)
        {
            foco_strobo = strobeLight1[i].GetComponent<Light>();
            foco_strobo.intensity = maxValueStrobo * valorFlash / 255;
        }
    }

    public IEnumerator flashRutine()
    {

        while (true)
        {
            dmx.setCanalDMX(16);
            dmx.setValorDMX(255);
            flash();
            yield return new WaitForSeconds(0.2f);
            dmx.setCanalDMX(16);
            dmx.setValorDMX(0);
            flash();
            yield return new WaitForSeconds(0.2f);

        }
    }

    //--------------------------------------------BLINDER-------------------------------------

    public void blinderActivation()
    {
        int valorBlinder = 0;

        if (dmx.getCanalDMX() == 17)
        {
            valorBlinder = dmx.getValorDMX();
        }

        for (int i = 0; i < blinderLight1.Length; i++)
        {
            foco_blinder = blinderLight1[i].GetComponent<Light>();
            foco_blinder.spotAngle = maxValueBlinder * valorBlinder / 255;
        }
    }

    public void blinderIntesity()
    {
        int valorBlinder = 0;

        if (dmx.getCanalDMX() == 18)
        {
            valorBlinder = dmx.getValorDMX();
        }

        for (int i = 0; i < blinderLight1.Length; i++)
        {
            foco_blinder = blinderLight1[i].GetComponent<Light>();
            foco_blinder.intensity = maxValueBlinder * valorBlinder / 255;
        }
    }

    //STROBO CON CEGADORA
    public IEnumerator blinderRutine()
    {
        while (true)
        {
            dmx.setCanalDMX(18);
            dmx.setValorDMX(50);
            blinderIntesity();
            yield return new WaitForSeconds(0.2f);
            dmx.setCanalDMX(18);
            dmx.setValorDMX(0);
            blinderIntesity();
            yield return new WaitForSeconds(0.2f);
        }
    }

    public IEnumerator DemoVX()
    {
        yield return new WaitForSeconds(18f);
        strobeBlackout();
        strobeFlash();
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(10f);
        stroboOff();


    }

    public void activarDemo()
    {
        StartCoroutine("DemoVX");
    }
}
