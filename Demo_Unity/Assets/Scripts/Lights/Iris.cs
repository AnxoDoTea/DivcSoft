using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iris : MonoBehaviour
{
    private Light foco;
    public int canal = 15;
    private int canalIris = 0;
    private float valorIris = 0;
    private int maxValue = 200;
    private static Texture2D gobo_iris;
    private DMX valorDmx;
    private bool flagCanal;
    private GameObject[] spotLight;
    private List<GameObject> luces = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foco = GetComponent<Light>();
        valorDmx = FindObjectOfType<DMX>();
        flagCanal = false;
        importGobos();
    }

    // Update is called once per frame
    void Update()
    {
        canalIris = valorDmx.getCanalDMX();
        if (canalIris == canal)
        {
            selectMovingHead();
            iris();
            flagCanal = true;
        }
        else
        {
            flagCanal = false;
        }
    }

    void iris()
    {
        if(flagCanal == true)
        {
            valorIris = valorDmx.getValorDMX();
        }
        else
        {
            valorDmx.setValorDMX((int)valorIris);
        }
        // Tenemos que normalizar nuestros valores entre 0 y 255 (DMX)
        for (int j = 0; j < luces.Count; j++)
        {
            foco = luces[j].GetComponent<Light>();
            foco.cookie = gobo_iris;
            foco.spotAngle = maxValue * valorIris / 255;
        }
    }

    static void importGobos()
    {
        gobo_iris = Resources.Load<Texture2D>("Gobos/iris");
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
