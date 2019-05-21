using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public Vector3 Pivot; // En torno a este punto se van a rotar los objetos que tengan este script.

    public bool RotateX = false;
    public bool RotateY = true;
    public bool RotateZ = false;

    public float rotationSpeed; // Vector negativo para cambiar de dirección.
    public bool isMoving;

    void FixedUpdate()
    {
        if (isMoving)
        {
            transform.position += (transform.rotation * Pivot);

            Vector3 rotationVector = new Vector3(RotateX ? 1f : 0f, RotateY ? 1f : 0f, RotateZ ? 1f : 0f);
            transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.fixedDeltaTime, rotationVector);

            transform.position -= (transform.rotation * Pivot);

            Vector3 rot = transform.rotation.eulerAngles;

            transform.rotation = Quaternion.Euler(new Vector3(rot.x % 360f, rot.y % 360f, rot.z % 360f));
        }        
    }

}
