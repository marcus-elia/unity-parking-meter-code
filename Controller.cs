// This is from a tutorial on youtube by SpawnCampGames: https://www.youtube.com/watch?v=TBIYSksI10k

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Rigidbody sphereRb;
    private float moveInput;
    private float turnInput;
    public float forwardSpeed;
    public float reverseSpeed;
    public float turnSpeed;


    // Start is called before the first frame update
    void Start()
    {
        sphereRb.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        moveInput *= moveInput > 0 ? forwardSpeed : reverseSpeed;

        transform.position = sphereRb.transform.position;

        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.Rotate(0f, newRotation, 0f, Space.World);
    }

    private void FixedUpdate()
    {
        sphereRb.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
    }
}
