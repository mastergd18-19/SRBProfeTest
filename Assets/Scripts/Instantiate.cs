using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{

    public Transform t;
    public GameObject go;


    // Update is called once per frame
    void Update()
    {
        ShootSphere();
    }

    void ShootSphere()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(go, t.position, t.rotation);
        }
    }

}
