using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocation : MonoBehaviour
{
    private bool firstPerson = true;

    public Transform firstPersonLocation;
    public Transform thirdPersonLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.V))
        {
            if (firstPerson)
            {
                transform.position = thirdPersonLocation.position;
            }
            else
            {
                transform.position = firstPersonLocation.position;
            }
            firstPerson = !firstPerson;
        }
    }
}
