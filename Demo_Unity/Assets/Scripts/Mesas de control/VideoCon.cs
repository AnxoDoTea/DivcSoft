using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class VideoCon : MonoBehaviour
{
    public VideoPlayer screenR;
    public VideoPlayer screenL;
    public VideoPlayer screen_PIP_R;
    public VideoPlayer screen_PIP_L;

    public GameObject pantallaR;
    public GameObject pantallaL;
    public GameObject pipR;
    public GameObject pipL;

    public Texture camara1;
    public Texture camara2;
    public Texture camara3;
    public Texture camara4;
    public Texture video;
    public Texture offScreen;

    public Renderer pantallaRenderer_R;
    public Renderer pantallaRenderer_L;
    public Renderer pipRenderer_R;
    public Renderer pipRenderer_L;

    public Toggle checkPIPbox;

    public GameObject pip_cam1;
    public GameObject pip_cam2;
    public GameObject pip_cam3;
    public GameObject pip_cam4;
    public GameObject pip_vid;



    // Start is called before the first frame update
    void Start()
    {
        pantallaRenderer_R = pantallaR.GetComponent<Renderer>();
        pantallaRenderer_L = pantallaL.GetComponent<Renderer>();
        pipRenderer_R = pipR.GetComponent<Renderer>();
        pipRenderer_L = pipL.GetComponent<Renderer>();

        pantallaRenderer_R.material.mainTexture = offScreen;
        pantallaRenderer_L.material.mainTexture = offScreen;
        pipRenderer_R.material.mainTexture = offScreen;
        pipRenderer_L.material.mainTexture = offScreen;


    }

    // Update is called once per frame
    void Update()
    {


    }

    public void ApagarPantallas()
    {
        screenR.Pause();
        screenL.Pause();
        screen_PIP_R.Pause();
        screen_PIP_L.Pause();

        pantallaRenderer_R.material.mainTexture = offScreen;
        pantallaRenderer_L.material.mainTexture = offScreen;
        pipRenderer_R.material.mainTexture = offScreen;
        pipRenderer_L.material.mainTexture = offScreen;
    }

    //-----------------------------------FUNCIONES PANTALLA LED PRINCIPAL---------------------------------

    public void Camara1()
    {
        screenR.Pause();
        screenL.Pause();
        pantallaRenderer_R.material.mainTexture = camara1;
        pantallaRenderer_L.material.mainTexture = camara1;

    }

    public void Camara2()
    {
        screenR.Pause();
        screenL.Pause();
        pantallaRenderer_R.material.mainTexture = camara2;
        pantallaRenderer_L.material.mainTexture = camara2;
    }

    public void Camara3()
    {
        screenR.Pause();
        screenL.Pause();
        pantallaRenderer_R.material.mainTexture = camara3;
        pantallaRenderer_L.material.mainTexture = camara3;
    }

    public void Camara4()
    {
        screenR.Pause();
        screenL.Pause();
        pantallaRenderer_R.material.mainTexture = camara4;
        pantallaRenderer_L.material.mainTexture = camara4;
    }

    public void Video()
    {
        screenR.Play();
        screenL.Play();
        pantallaRenderer_R.material.mainTexture = video;
        pantallaRenderer_L.material.mainTexture = video;
    }


    //-----------------------------------FUNCIONES PANTALLA PIP---------------------------------


    public void Camara1_PIP()
    {
        screen_PIP_R.Pause();
        screen_PIP_L.Pause();
        pipRenderer_R.material.mainTexture = camara1;
        pipRenderer_L.material.mainTexture = camara1;

    }

    public void Camara2_PIP()
    {
        screen_PIP_R.Pause();
        screen_PIP_L.Pause();
        pipRenderer_R.material.mainTexture = camara2;
        pipRenderer_L.material.mainTexture = camara2;
    }

    public void Camara3_PIP()
    {
        screen_PIP_R.Pause();
        screen_PIP_L.Pause();
        pipRenderer_R.material.mainTexture = camara3;
        pipRenderer_L.material.mainTexture = camara3;
    }

    public void Camara4_PIP()
    {
        screen_PIP_R.Pause();
        screen_PIP_L.Pause();
        pipRenderer_R.material.mainTexture = camara4;
        pipRenderer_L.material.mainTexture = camara4;
    }

    public void Video_PIP()
    {
        screen_PIP_R.Play();
        screen_PIP_L.Play();
        pipRenderer_R.material.mainTexture = video;
        pipRenderer_L.material.mainTexture = video;
    }


    public void PIP()
    {
        if (checkPIPbox.isOn)
        {
            pipR.SetActive(true);
            pipL.SetActive(true);
            pip_cam1.SetActive(true);
            pip_cam2.SetActive(true);
            pip_cam3.SetActive(true);
            pip_cam4.SetActive(true);
            pip_vid.SetActive(true);

        }

        else
        {
            pipR.SetActive(false);
            pipL.SetActive(false);
            pip_cam1.SetActive(false);
            pip_cam2.SetActive(false);
            pip_cam3.SetActive(false);
            pip_cam4.SetActive(false);
            pip_vid.SetActive(false);
        }
    }

    public IEnumerator DemoVideo()
    {
        yield return new WaitForSeconds(12f);
        Camara4();
        yield return new WaitForSeconds(2f);
        Camara1_PIP();
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(14f);
        ApagarPantallas();

    }

    public void activarDemo()
    {
        StartCoroutine("DemoVideo");
    }





}
