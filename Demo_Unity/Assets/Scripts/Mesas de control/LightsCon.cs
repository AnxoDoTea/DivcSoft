using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightsCon : MonoBehaviour
{

    private GameObject[] spotLight1;
    private GameObject[] spotLight2;
    private GameObject[] wash1;
    private GameObject[] wash2;
    private GameObject[] wash3;
    private GameObject[] beam;
    private GameObject[] profile;

    private GameObject[] spotLight1_tilt;
    private GameObject[] spotLight2_tilt;
    private GameObject[] wash1_tilt;
    private GameObject[] wash2_tilt;
    private GameObject[] wash3_tilt;
    private GameObject[] beam_tilt;
    private GameObject[] profile_tilt;

    private GameObject[] spotLight1_pan;
    private GameObject[] spotLight2_pan;
    private GameObject[] wash1_pan;
    private GameObject[] wash2_pan;
    private GameObject[] wash3_pan;
    private GameObject[] beam_pan;
    private GameObject[] profile_pan;

    private ParticleSystem beamLight;

    private DMX dmx;
    private Light foco;
    //ZOOM
    private int maxValue = 3000;

    //TILT
    private float xt = 0f, yt = 0f, zt = 0f;
    private static float maxTilt = 250;

    //PAN
    float xp = 0f, yp = 0f, zp = 0f;
    private static float maxPan = 540;

    //GOBOS
    private static Texture2D gobo1, gobo3, gobo4;
    private static Texture2D profile_gobo1, profile_gobo2, profile_gobo3, profile_gobo4, profile_gobo5, profile_gobo6, profile_gobo7, profile_gobo8, profile_gobo9;


    // Start is called before the first frame update
    void Start()
    {
        //General
        spotLight1 = GameObject.FindGameObjectsWithTag("SpotLight1");
        spotLight2 = GameObject.FindGameObjectsWithTag("SpotLight2");
        wash1 = GameObject.FindGameObjectsWithTag("Wash1");
        wash2 = GameObject.FindGameObjectsWithTag("Wash2");
        wash3 = GameObject.FindGameObjectsWithTag("Wash3");
        beam = GameObject.FindGameObjectsWithTag("Beam");
        profile = GameObject.FindGameObjectsWithTag("Profile1");

        dmx = FindObjectOfType<DMX>();
        apagarLuces();

        //TILT
        Vector3 anglest = transform.eulerAngles;
        xt = anglest.x;
        yt = anglest.y;
        zt = anglest.z;
        spotLight1_tilt = GameObject.FindGameObjectsWithTag("TiltSpot1");
        spotLight2_tilt = GameObject.FindGameObjectsWithTag("TiltSpot2");
        wash1_tilt = GameObject.FindGameObjectsWithTag("TiltWash1");
        wash2_tilt = GameObject.FindGameObjectsWithTag("TiltWash2");
        wash3_tilt = GameObject.FindGameObjectsWithTag("TiltWash3");
        beam_tilt = GameObject.FindGameObjectsWithTag("TiltBeam");
        profile_tilt = GameObject.FindGameObjectsWithTag("TiltProfile");


        //PAN
        Vector3 anglesp = transform.eulerAngles;
        xp = anglesp.x;
        yp = anglesp.y;
        zp = anglesp.z;
        spotLight1_pan = GameObject.FindGameObjectsWithTag("PanSpot1");
        spotLight2_pan = GameObject.FindGameObjectsWithTag("PanSpot2");
        wash1_pan = GameObject.FindGameObjectsWithTag("PanWash1");
        wash2_pan = GameObject.FindGameObjectsWithTag("PanWash2");
        wash3_pan = GameObject.FindGameObjectsWithTag("PanWash3");
        beam_pan = GameObject.FindGameObjectsWithTag("PanBeam");
        profile_pan = GameObject.FindGameObjectsWithTag("PanProfile");

        //GOBOS
        importGobos();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //----------------------------Botones grupo de luces---------------------------- 
    public void Fspot1()
    {
        for (int i = 0; i < spotLight1.Length; i++)
        {
            spotLight1[i].SetActive(true);
        }

        dmx.setCanalDMX(1);
        dmx.setValorDMX(255);
        zoom(spotLight1);

        dmx.setCanalDMX(4);
        dmx.setValorDMX(90);
        gobo(spotLight1);

        StartCoroutine("MovimientosSpot1");




    }

    public void Fspot2()
    {
        for (int i = 0; i < spotLight2.Length; i++)
        {
            spotLight2[i].SetActive(true);
        }

        dmx.setCanalDMX(1);
        dmx.setValorDMX(255);
        zoom(spotLight2);

        dmx.setCanalDMX(4);
        dmx.setValorDMX(90);
        gobo(spotLight2);

        StartCoroutine("MovimientosSpot2");



    }

    public void Fwash1()
    {
        for (int i = 0; i < wash1.Length; i++)
        {
            wash1[i].SetActive(true);
        }

        dmx.setCanalDMX(6);
        dmx.setValorDMX(255);
        colorRojo(wash1);

        StartCoroutine("MovimientosWash1");


    }

    public void Fwash2()
    {
        for (int i = 0; i < wash2.Length; i++)
        {
            wash2[i].SetActive(true);
        }


        StartCoroutine("MovimientosWash2");


    }

    public void Fwash3()
    {
        for (int i = 0; i < wash3.Length; i++)
        {
            wash3[i].SetActive(true);
        }

        StartCoroutine("MovimientosWash3");


    }

    public void Fbeam()
    {
        //ESTO PRENDE EL BEAM
        for (int i = 0; i < beam.Length; i++)
        {
            beamLight = beam[i].GetComponent<ParticleSystem>();
            beamLight.Play();
        }

        StartCoroutine("MovimientosBeam");
    }

    public void Fprofile()
    {
        for (int i = 0; i < profile.Length; i++)
        {
            profile[i].SetActive(true);
        }

        dmx.setCanalDMX(1);
        dmx.setValorDMX(255);
        zoom(profile);

        dmx.setCanalDMX(3);
        dmx.setValorDMX(130);
        pan(profile_pan);


        StartCoroutine("MovimientosProfile");


    }


    //------------------------------Funciones generales----------------------------------------

    public void apagarLuces()
    {
        for (int i = 0; i < spotLight1.Length; i++) spotLight1[i].SetActive(false);
        for (int i = 0; i < spotLight2.Length; i++) spotLight2[i].SetActive(false);
        for (int i = 0; i < wash1.Length; i++) wash1[i].SetActive(false);
        for (int i = 0; i < wash2.Length; i++) wash2[i].SetActive(false);
        for (int i = 0; i < wash3.Length; i++) wash3[i].SetActive(false);
        for (int i = 0; i < profile.Length; i++) profile[i].SetActive(false);

        //ESTO APAGA EL BEAM
        for (int i = 0; i < beam.Length; i++)
        {
            beamLight = beam[i].GetComponent<ParticleSystem>();
            beamLight.Pause();
            beamLight.Clear();
        }
        StopAllCoroutines();
    }

    public void apagarSpot1()
    {
        for (int i = 0; i < spotLight1.Length; i++) spotLight1[i].SetActive(false);
        StopCoroutine("MovimientosSpot1");
    }

    public void apagarSpot2()
    {
        for (int i = 0; i < spotLight2.Length; i++) spotLight2[i].SetActive(false);
        StopCoroutine("MovimientosSpot2");
    }

    public void apagarWash1()
    {
        for (int i = 0; i < wash1.Length; i++) wash1[i].SetActive(false);
        StopCoroutine("MovimientosWash1");
    }

    public void apagarWash2()
    {
        for (int i = 0; i < wash2.Length; i++) wash2[i].SetActive(false);
        StopCoroutine("MovimientosWash2");
    }

    public void apagarWash3()
    {
        for (int i = 0; i < wash3.Length; i++) wash3[i].SetActive(false);
        StopCoroutine("MovimientosWash3");
    }

    public void apagarBeam()
    {
        //ESTO APAGA EL BEAM
        for (int i = 0; i < beam.Length; i++)
        {
            beamLight = beam[i].GetComponent<ParticleSystem>();
            beamLight.Pause();
            beamLight.Clear();
        }
        StopCoroutine("MovimientosBeam");
    }

    public void apagarProfile()
    {
        for (int i = 0; i < profile.Length; i++) profile[i].SetActive(false);
        StopCoroutine("MovimientosProfile");
    }



    //-----------------------COROUTINES SPOT1---------------------------------------

    public IEnumerator MovimientosSpot1()
    {

        while (true)
        {

            for (int i = 110; i <= 140; i = i + 1)
            {
                dmx.setCanalDMX(3);
                dmx.setValorDMX(i);
                pan(spotLight1_pan);
                yield return new WaitForSeconds(0.05f);
            }

            for (int i = 140; i >= 110; i = i - 1)
            {
                dmx.setCanalDMX(3);
                dmx.setValorDMX(i);
                pan(spotLight1_pan);
                yield return new WaitForSeconds(0.05f);
            }

        }
    }

    //-----------------------COROUTINES SPOT2---------------------------------------

    public IEnumerator MovimientosSpot2()
    {

        while (true)
        {

            for (int i = 110; i <= 140; i = i + 1)
            {
                dmx.setCanalDMX(3);
                dmx.setValorDMX(i);
                pan(spotLight2_pan);
                yield return new WaitForSeconds(0.05f);
            }

            for (int i = 140; i >= 110; i = i - 1)
            {
                dmx.setCanalDMX(3);
                dmx.setValorDMX(i);
                pan(spotLight2_pan);
                yield return new WaitForSeconds(0.05f);
            }
        }

    }
    //-----------------------COROUTINES WASH1---------------------------------------

    public IEnumerator MovimientosWash1()
    {
        while (true)
        {

            for (int i = 1; i <= 255; i = i + 20)
            {
                dmx.setCanalDMX(2);
                dmx.setValorDMX(i);
                tilt(wash1_tilt);
                yield return new WaitForSeconds(0.05f);
            }

            for (int i = 255; i >= 1; i = i - 20)
            {
                dmx.setCanalDMX(2);
                dmx.setValorDMX(i);
                tilt(wash1_tilt);
                yield return new WaitForSeconds(0.05f);
            }
        }

    }
    //-----------------------COROUTINES WASH2---------------------------------------

    public IEnumerator MovimientosWash2()
    {
        while (true)
        {

            for (int i = 1; i <= 255; i = i + 5)
            {
                dmx.setCanalDMX(3);
                dmx.setValorDMX(i);
                pan(wash2_pan);
                yield return new WaitForSeconds(0.05f);
            }

            for (int i = 255; i >= 1; i = i - 5)
            {
                dmx.setCanalDMX(3);
                dmx.setValorDMX(i);
                pan(wash2_pan);
                yield return new WaitForSeconds(0.05f);
            }
        }

    }

    //-----------------------COROUTINES WASH3---------------------------------------

    public IEnumerator MovimientosWash3()
    {
        while (true)
        {
            dmx.setCanalDMX(5);
            colorRandom(wash3);
            yield return new WaitForSeconds(0.02f);
        }
    }

    //-----------------------COROUTINES BEAM1---------------------------------------

    public IEnumerator MovimientosBeam()
    {
        while (true)
        {

            for (int i = 110; i <= 140; i = i + 1)
            {
                dmx.setCanalDMX(3);
                dmx.setValorDMX(i);
                pan(beam_pan);
                yield return new WaitForSeconds(0.05f);
            }

            for (int i = 140; i >= 110; i = i - 1)
            {
                dmx.setCanalDMX(3);
                dmx.setValorDMX(i);
                pan(beam_pan);
                yield return new WaitForSeconds(0.05f);
            }
        }

    }

    //-----------------------COROUTINES PROFILE---------------------------------------

    public IEnumerator MovimientosProfile()
    {
        while (true)
        {
            for (int i = 0; i <= 225; i = i + 25)
            {
                dmx.setCanalDMX(8);
                dmx.setValorDMX(i);
                profileGobos();
                yield return new WaitForSeconds(0.05f);
            }




        }
    }

    //-----------------------COROUTINES DEMO---------------------------------------
    public IEnumerator DemoLuces()
    {
        Fprofile();
        yield return new WaitForSeconds(2f);
        Fbeam();
        yield return new WaitForSeconds(2f);
        Fwash3();
        yield return new WaitForSeconds(2f);
        Fwash2();
        yield return new WaitForSeconds(2f);
        Fwash1();
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(20f);
        apagarLuces();



    }

    public void activarDemo()
    {
        StartCoroutine("DemoLuces");
    }





    //------------------------------ZOOM----------------------------------------

    public void zoom(GameObject[] luces)
    {
        int valorZoom = 0;

        if (dmx.getValorDMX() > 0 && dmx.getCanalDMX() == 1)
        {
            valorZoom = dmx.getValorDMX();
        }

        // Tenemos que normalizar nuestros valores entre 0 y 255 (DMX)
        for (int j = 0; j < luces.Length; j++)
        {
            foco = luces[j].GetComponent<Light>();
            foco.range = maxValue * valorZoom / 255;
        }

    }

    //------------------------------TILT----------------------------------------

    public void tilt(GameObject[] tilt)
    {
        List<GameObject> pivotest = new List<GameObject>();
        int valorTilt = 0;

        for (int i = 0; i < tilt.Length; i++) pivotest.Add(tilt[i]);

        if (dmx.getValorDMX() > 0 && dmx.getCanalDMX() == 2)
        {
            valorTilt = dmx.getValorDMX();
        }

        for (int i = 0; i < pivotest.Count; i++) pivotest[i].transform.localRotation = Quaternion.Euler(xt + maxTilt * (valorTilt - 45) / 255, 0, 0); //el +60 (antes -128) establece la posición inicial de la cabeza móvil y los límites de la rotación
    }




    //------------------------------PAN----------------------------------------

    public void pan(GameObject[] pan)
    {
        List<GameObject> pivotesp = new List<GameObject>();
        int valorPan = 0;
        for (int i = 0; i < pan.Length; i++) pivotesp.Add(pan[i]);

        if (dmx.getValorDMX() > 0 && dmx.getCanalDMX() == 3)
        {
            valorPan = dmx.getValorDMX();
        }

        for (int i = 0; i < pivotesp.Count; i++) pivotesp[i].transform.rotation = Quaternion.Euler(xp, yp + maxPan * (valorPan - 128) / 255, zp);
    }

    //-----------------------------GOBO------------------------------------------

    public void gobo(GameObject[] gobos_luces)
    {
        List<GameObject> luces = new List<GameObject>();
        for (int i = 0; i < gobos_luces.Length; i++) luces.Add(gobos_luces[i]);
        int valorGobo = 0;

        if (dmx.getValorDMX() > 0 && dmx.getCanalDMX() == 4)
        {
            valorGobo = dmx.getValorDMX();
        }

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

    //    [MenuItem("AssetDatabase/LoadAssetExample")]
    static void importGobos()
    {
        gobo1 = Resources.Load<Texture2D>("Gobos/gobo1");
        gobo3 = Resources.Load<Texture2D>("Gobos/gobo3");
        gobo4 = Resources.Load<Texture2D>("Gobos/gobo4");

        profile_gobo1 = Resources.Load<Texture2D>("Gobos/profileMulti1");
        profile_gobo2 = Resources.Load<Texture2D>("Gobos/profileMulti2");
        profile_gobo3 = Resources.Load<Texture2D>("Gobos/profileMulti3");
        profile_gobo4 = Resources.Load<Texture2D>("Gobos/profileMulti4");
        profile_gobo5 = Resources.Load<Texture2D>("Gobos/profileMulti5");
        profile_gobo6 = Resources.Load<Texture2D>("Gobos/profileMulti6");
        profile_gobo7 = Resources.Load<Texture2D>("Gobos/profileMulti7");
        profile_gobo8 = Resources.Load<Texture2D>("Gobos/profileMulti8");
        profile_gobo9 = Resources.Load<Texture2D>("Gobos/profileMulti9");

    }

    //------------------------------COLOR RANDOM----------------------------------

    void colorRandom(GameObject[] luces)
    {
        byte rojo = 255, verde = 255, azul = 255;

        if (dmx.getCanalDMX() == 5)
        {
            rojo = (byte)Random.Range(0, 256);
            verde = (byte)Random.Range(0, 256);
            azul = (byte)Random.Range(0, 256);

            for (int j = 0; j < luces.Length; j++)
            {
                foco = luces[j].GetComponent<Light>();
                foco.color = new Color32(rojo, verde, azul, 255);
            }
        }

    }

    //---------------------------COLOR ROJO---------------------------------------

    void colorRojo(GameObject[] luces)
    {
        byte rojo = 255, verde = 255, azul = 255;

        if (dmx.getCanalDMX() == 6)
        {
            rojo = (byte)dmx.getValorDMX();
            verde = (byte)0;
            azul = (byte)0;

            for (int j = 0; j < luces.Length; j++)
            {
                foco = luces[j].GetComponent<Light>();
                foco.color = new Color32(rojo, verde, azul, 255);
            }
        }

    }

    //---------------------------COLOR AZUL---------------------------------------

    void colorAzul(GameObject[] luces)
    {
        byte rojo = 255, verde = 255, azul = 255;

        if (dmx.getCanalDMX() == 7)
        {
            azul = (byte)dmx.getValorDMX();
            verde = (byte)0;
            rojo = (byte)0;

            for (int j = 0; j < luces.Length; j++)
            {
                foco = luces[j].GetComponent<Light>();
                foco.color = new Color32(rojo, verde, azul, 255);
            }
        }

    }

    //-------------------------PROFILE--------------------------------------------

    void profileGobos()
    {
        List<GameObject> luces = new List<GameObject>();
        for (int i = 0; i < profile.Length; i++) luces.Add(profile[i]);
        int valorGobo = 0;

        if (dmx.getValorDMX() >= 0 && dmx.getCanalDMX() == 8)
        {
            valorGobo = dmx.getValorDMX();
        }

        //----------------PROFILE GOBO 1-------------------------
        if (valorGobo >= 0 && valorGobo < 25)
        {
            for (int j = 0; j < luces.Count; j++)
            {
                foco = luces[j].GetComponent<Light>();
                foco.cookie = profile_gobo1;
            }

        }

        //----------------PROFILE GOBO 2-------------------------
        else if (valorGobo >= 25 && valorGobo < 50)
        {
            for (int j = 0; j < luces.Count; j++)
            {
                foco = luces[j].GetComponent<Light>();
                foco.cookie = profile_gobo2;
            }
        }

        //----------------PROFILE GOBO 3-------------------------
        else if (valorGobo >= 50 && valorGobo < 75)
        {
            for (int j = 0; j < luces.Count; j++)
            {
                foco = luces[j].GetComponent<Light>();
                foco.cookie = profile_gobo3;
            }
        }

        //----------------PROFILE GOBO 4-------------------------
        else if (valorGobo >= 75 && valorGobo < 100)
        {
            for (int j = 0; j < luces.Count; j++)
            {
                foco = luces[j].GetComponent<Light>();
                foco.cookie = profile_gobo4;
            }
        }

        //----------------PROFILE GOBO 5-------------------------
        else if (valorGobo >= 100 && valorGobo < 125)
        {
            for (int j = 0; j < luces.Count; j++)
            {
                foco = luces[j].GetComponent<Light>();
                foco.cookie = profile_gobo5;
            }
        }

        //----------------PROFILE GOBO 6-------------------------
        else if (valorGobo >= 125 && valorGobo < 150)
        {
            for (int j = 0; j < luces.Count; j++)
            {
                foco = luces[j].GetComponent<Light>();
                foco.cookie = profile_gobo6;
            }
        }

        //----------------PROFILE GOBO 7-------------------------
        else if (valorGobo >= 150 && valorGobo < 175)
        {
            for (int j = 0; j < luces.Count; j++)
            {
                foco = luces[j].GetComponent<Light>();
                foco.cookie = profile_gobo7;
            }
        }

        //----------------PROFILE GOBO 8-------------------------
        else if (valorGobo >= 175 && valorGobo < 200)
        {
            for (int j = 0; j < luces.Count; j++)
            {
                foco = luces[j].GetComponent<Light>();
                foco.cookie = profile_gobo8;
            }
        }

        //----------------PROFILE GOBO 9-------------------------
        else if (valorGobo >= 200 && valorGobo < 225)
        {
            for (int j = 0; j < luces.Count; j++)
            {
                foco = luces[j].GetComponent<Light>();
                foco.cookie = profile_gobo9;
            }
        }


    }




}
