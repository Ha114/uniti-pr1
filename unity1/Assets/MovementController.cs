using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;


public class MovementController : MonoBehaviour
{
    public Rigidbody rb;
    public int speed = 1000;
    public bool Iteraction = false;
    public Material red;

    void OnTriggerEnter(Collider other)
    {
        CanInteract(other.gameObject);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
  

    private void GetInputAndUpdatePosition() {

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed * Time.deltaTime);
        }

    }

    private void CanInteract(GameObject g)
    {
        var dist = Vector3.Distance(transform.position, g.transform.position);
        Debug.Log("Distance = " + dist);
        if (dist <= 4f)
        {
            Iteraction = true;
            if (Iteraction == true)
            {
                InteractWithInteractibale(g);
            }
        }
        else
        {
            if (Iteraction == false)
            {
                Debug.Log("Iteraction FALSE");
            }
        }
    }
    void InteractWithInteractibale(GameObject g)
    {
        Debug.Log("Iteraction TRUE");
        g.gameObject.GetComponent<Renderer>().material = red;
        Iteraction = false;
    }

    void Update()
    {
        GetInputAndUpdatePosition();
    }
}
