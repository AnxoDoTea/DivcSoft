using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt_blinder : MonoBehaviour
{
    private static float maxTilt = 250;    //Grados
    private float valorTilt = 0;
    public int canal = 4;
    private int canalDmx = 0;
    private DMX dmx;
    float x = 0f, y = 0f, z = 0f;
    private bool flagCanal;

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
        if (canalDmx == canal)
        {
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
        transform.localRotation = Quaternion.Euler(x - maxTilt * (valorTilt - 45) / 255, 0, 0); //el +60 (antes -128) establece la posición inicial de la cabeza móvil y los límites de la rotación
    }
}
