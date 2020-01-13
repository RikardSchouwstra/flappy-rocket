using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float rcsThrust = 100f;
    [SerializeField] private float mainThrust = 100f;

    Rigidbody rigidBody;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //print("space");

            rigidBody.AddRelativeForce(Vector3.up * mainThrust);

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; //take manual control of rotation

        if (Input.GetKey(KeyCode.A) && !(Input.GetKey(KeyCode.D)))
        {
            //print("left");
            float rotationSpeed = rcsThrust * Time.deltaTime;
            rigidBody.transform.Rotate(Vector3.forward * rotationSpeed);
        }

        if (Input.GetKey(KeyCode.D) && !(Input.GetKey(KeyCode.A)))
        {
            //print("right");
            float rotationSpeed = rcsThrust * Time.deltaTime;
            rigidBody.transform.Rotate(-Vector3.forward * rotationSpeed);
        }

        rigidBody.freezeRotation = false; //resume rotation of rigid body
    }

    void OnCollisionEnter(Collision collision)
    {
        print("collided");
    }
    
}
