using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedGainPerSecond = 0.3f;
    [SerializeField] private float rotationSpeed = 200f;

    private float rotateSpeed = 0;
    private int _steerValue;
    void Update()
    {
        speed += speedGainPerSecond * Time.deltaTime;
        rotateSpeed = _steerValue * rotationSpeed * Time.deltaTime;
        transform.Rotate(0f,rotateSpeed,0f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(0);
        }
           
    }

    public void Steer(int value)
    {
        _steerValue = value;
    }
}
