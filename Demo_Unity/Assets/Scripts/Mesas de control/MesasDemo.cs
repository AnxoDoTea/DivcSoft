using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesasDemo : MonoBehaviour
{
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

    public IEnumerator DemoMesas()
    {
        yield return new WaitForSeconds(5f);
        videoTable.SetActive(true);
        lightsTable.SetActive(false);
        vxTable.SetActive(false);
        soundTable.SetActive(false);
        yield return new WaitForSeconds(5f);
        videoTable.SetActive(false);
        lightsTable.SetActive(true);
        vxTable.SetActive(false);
        soundTable.SetActive(false);
        yield return new WaitForSeconds(5f);
        videoTable.SetActive(false);
        lightsTable.SetActive(false);
        vxTable.SetActive(true);
        soundTable.SetActive(false);
        yield return new WaitForSeconds(5f);
        videoTable.SetActive(false);
        lightsTable.SetActive(false);
        vxTable.SetActive(false);
        soundTable.SetActive(true);
        yield return new WaitForSeconds(5f);
        videoTable.SetActive(false);
        lightsTable.SetActive(false);
        vxTable.SetActive(false);
        soundTable.SetActive(false);
    }

    public void activarDemo()
    {
        StartCoroutine("DemoMesas");
    }
}
