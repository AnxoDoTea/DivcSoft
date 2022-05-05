using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioMesas : MonoBehaviour
{

    public Toggle videoTable_check;
    public Toggle lightsTable_check;
    public Toggle vxTable_check;
    public Toggle soundTable_check;

    public GameObject videoTable;
    public GameObject lightsTable;
    public GameObject vxTable;
    public GameObject soundTable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

//----------------ACTIVAR MESA DE VIDEO-----------------------------

    public void activateVideoTable()
    {
        if (videoTable_check.isOn)
        {
            lightsTable_check.isOn = false;
            vxTable_check.isOn = false;
            soundTable_check.isOn = false;

            lightsTable.SetActive(false);
            vxTable.SetActive(false);
            soundTable.SetActive(false);

            videoTable.SetActive(true);
        }

        else
        {
            videoTable.SetActive(false);
        }
    }

//----------------ACTIVAR MESA DE LUCES-----------------------------

    public void activateLightsTable()
    {
        if (lightsTable_check.isOn)
        {
            videoTable_check.isOn = false;
            vxTable_check.isOn = false;
            soundTable_check.isOn = false;

            videoTable.SetActive(false);
            vxTable.SetActive(false);
            soundTable.SetActive(false);

            lightsTable.SetActive(true);
        }

        else
        {
            lightsTable.SetActive(false);
        }
    }

    //----------------ACTIVAR MESA DE VX-----------------------------

    public void activateVXTable()
    {
        if (vxTable_check.isOn)
        {
            videoTable_check.isOn = false;
            lightsTable_check.isOn = false;
            soundTable_check.isOn = false;

            videoTable.SetActive(false);
            lightsTable.SetActive(false);
            soundTable.SetActive(false);

            vxTable.SetActive(true);
        }

        else
        {
            vxTable.SetActive(false);
        }
    }

    //----------------ACTIVAR MESA DE SONIDO-----------------------------

    public void activateSoundTable()
    {
        if (soundTable_check.isOn)
        {
            lightsTable_check.isOn = false;
            vxTable_check.isOn = false;
            videoTable_check.isOn = false;

            lightsTable.SetActive(false);
            vxTable.SetActive(false);
            videoTable.SetActive(false);

            soundTable.SetActive(true);
        }

        else
        {
            soundTable.SetActive(false);
        }
    }


}
