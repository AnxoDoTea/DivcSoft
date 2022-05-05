using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DMX : MonoBehaviour
{
    //private byte[] arrayDMX;
    private int canalSeleccionado;
    private int valorSeleccionado;

    public Slider sliderCanal;
    public Slider sliderValor;
    public Toggle checkBoxCanal;
    public Text printCanal;
    public Text printValor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkSliders();

    }

    public void checkSliders()
    {
        if (checkBoxCanal.isOn == true)
        {
            canalSeleccionado = (int)sliderCanal.value;
        }
        else
        {
            canalSeleccionado = 0;
        }
        printCanal.text = "valor:" + canalSeleccionado.ToString();
        //Debug.Log("Canal: " + canalSeleccionado);

        valorSeleccionado = (int)sliderValor.value;
        printValor.text = "valor:" + valorSeleccionado.ToString();
        //Debug.Log("Valor: " + valorSeleccionado);

    }



    //-----------------GETTERS Y SETTERS---------------------------------------
    public int getCanalDMX()
    {
        return canalSeleccionado;
    }

    public int getValorDMX()
    {
        return valorSeleccionado;
    }

    public void setCanalDMX(int canal)
    {
        canalSeleccionado = canal;
    }

    public void setValorDMX(int valor)
    {
        sliderValor.value = (float)valor;
        valorSeleccionado = valor;
    }

}