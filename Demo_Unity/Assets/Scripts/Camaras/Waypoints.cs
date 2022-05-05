using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
     public GameObject[] waypoints;
    private GameObject objectToFind1;
    private GameObject objectToFind2;
    private int current = 0;
    public float rotSpeed; //rotation speed
    public float speed;
    private float waypointRadius = 1;

    // Start is called before the first frame update
    void Start()
    {
        objectToFind1 = GameObject.Find("Camara3");
        objectToFind2 = GameObject.Find("Camara4");
    }

    // Update is called once per frame
    void Update()
    {

        float dist = Vector3.Distance(waypoints[current].transform.position, transform.position);
        print("Distance to other: " + dist);
        if (dist < waypointRadius)
        {
            current++;
            //current = Random.Range(0,waypoints.Length);
            if(current >= waypoints.Length)
            {
                current = 0;
            }
        }

        //right (1,0,0) -> hacia arriba (plano XZ)
        //left (-1,0,0) -> hacia abajo (plano XZ)

        //up (0,1,0) -> hacia derecha (plano YZ)
        //down (0,-1,0) -> hacia izquierda (plano YZ)

        //forward (0,0,1) -> hacia izquierda girando (plano XY)
        //back (0,0,-1) -> hacia derecha girando (plano XY) 

        //one (1,1,1) -> el enfoque se mueve en todas las direcciones
        //zero(0,0,0) -> no se mueve el enfoque

        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        
        //transform.RotateAround(transform.position, Vector3.right, rotSpeed * Time.deltaTime);

        /*if (current == 0 && objectToFind1.name == "Camara3")
        {
            transform.RotateAround(transform.position, Vector3.right, rotSpeed * Time.deltaTime);
        }
        if (current == 0 && objectToFind2.name == "Camara4")
        {
            transform.RotateAround(transform.position, Vector3.left, rotSpeed * Time.deltaTime);
        }
        else if(current == 1 && objectToFind1.name == "Camara3")
        {
            transform.RotateAround(transform.position, Vector3.left, rotSpeed * Time.deltaTime);
        }
        else if (current == 1 && objectToFind1.name == "Camara4")
        {
            transform.RotateAround(transform.position, Vector3.down, rotSpeed * Time.deltaTime);
        }
        else if(current == 2 && objectToFind1.name == "Camara3")
        {
            transform.RotateAround(transform.position, Vector3.right, rotSpeed * Time.deltaTime);
        }
        else if (current == 2 && objectToFind1.name == "Camara4")
        {
            transform.RotateAround(transform.position, Vector3.up, rotSpeed * Time.deltaTime);
        }*/
    }
}
