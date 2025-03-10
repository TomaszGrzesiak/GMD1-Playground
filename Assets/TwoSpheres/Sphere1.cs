using System;
using UnityEngine;

public class Sphere1 : MonoBehaviour
{
    private int counter = 0;
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision with sphere: " + other.gameObject.name.ToString() + ", counter: "+ counter++);      
    }
    
}
