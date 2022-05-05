using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gobo : MonoBehaviour
{
    private Light foco;
    private DMX valorDmx;
    private bool flagCanal;
    public int canal = 14;
    private static Texture2D gobo1, gobo3, gobo4;
    private float valorGobo = 0;
    private int canalGobo = 0;
    private GameObject[] spotLight;
    private List<GameObject> luces = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        valorDmx = FindObjectOfType<DMX>();
        flagCanal = false;
        importGobos();
    }

    void Update()
    {
        canalGobo = valorDmx.getCanalDMX();
        if (canalGobo == canal)
        {
            selectMovingHead();
            replaceGobo();
            flagCanal = true;
        }
        else
        {
            flagCanal = false;
        }
    }

    void replaceGobo()
    {
        if (flagCanal == true)
        {
            valorGobo = valorDmx.getValorDMX();

            if (valorGobo >= 0 && valorGobo < 40)
            {
                for (int j = 0; j < luces.Count; j++)
                {
                    foco = luces[j].GetComponent<Light>();
                    foco.cookie = null;
                }
                
            }
            else if (valorGobo >= 40 && valorGobo < 80)
            {
                for (int j = 0; j < luces.Count; j++)
                {
                    foco = luces[j].GetComponent<Light>();
                    foco.cookie = gobo1;
                }
                
            }
            else if (valorGobo >= 80 && valorGobo < 120)
            {
                for (int j = 0; j < luces.Count; j++)
                {
                    foco = luces[j].GetComponent<Light>();
                    foco.cookie = gobo3;
                }
                
            }

            else if (valorGobo >= 120 && valorGobo < 160)
            {
                for (int j = 0; j < luces.Count; j++)
                {
                    foco = luces[j].GetComponent<Light>();
                    foco.cookie = gobo4;
                }
            }
        }
        else
        {
            valorDmx.setValorDMX((int)valorGobo);
        }
    }


    static void importGobos(){
        gobo1 = Resources.Load<Texture2D>("Gobos/gobo1");
        gobo3 = Resources.Load<Texture2D>("Gobos/gobo3");
        gobo4 = Resources.Load<Texture2D>("Gobos/gobo4");
    }

    void selectMovingHead()
    {
        luces.Clear();

        spotLight = GameObject.FindGameObjectsWithTag("SpotLight1");
        if (spotLight.Length != 0)
        {
            for (int i = 0; i < spotLight.Length; i++) luces.Add(spotLight[i]);
        }

        spotLight = GameObject.FindGameObjectsWithTag("SpotLight2");
        if (spotLight.Length != 0)
        {
            for (int i = 0; i < spotLight.Length; i++) luces.Add(spotLight[i]);
        }

    }
}
