using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpheresPlacement : MonoBehaviour
{
    public GameObject sphere1;
    public GameObject sphere2;
    private Rigidbody rb1;
    private Rigidbody rb2;
    private float radius = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       PlaceSpheresRandomly();
       rb1 = sphere1.GetComponent<Rigidbody>();
       rb2 = sphere2.GetComponent<Rigidbody>();
    }

    void PlaceSpheresRandomly()
    {
        sphere1.transform.position = GetRandomPosition();
        sphere2.transform.position = GetRandomPosition();
    }
    Vector3 GetRandomPosition()
    {
        float x = Random.Range(-radius, radius);
        float z = Random.Range(-radius, radius);
        return new Vector3(x, 1f, z); //1f so that the object is above the surface
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetMouseButtonDown(0))
        {
            rb1.linearVelocity = Vector3.zero;
            rb1.angularVelocity= Vector3.zero;
            rb2.linearVelocity = Vector3.zero;
            rb2.angularVelocity = Vector3.zero;
            PlaceSpheresRandomly();
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PushSphere1ToSphere2();
        }
        
    }

    private void PushSphere1ToSphere2()
    {
        // “to minus from”
        //     The ‘to’ point is b, the ‘from’ point
        //     is a.
        //     I.e.: b – a = direction
        //     (10, 8) – (3, 3) = (7, 5)
        // normalization works like it's scaling the vector down so that later, when it's used in adding force, we add some sort of fixed force as opposed the force depended on the distance.
        // In case the distance is very high, the force would also be very high if the direction wasn't normalized.
        Vector3 direction = (sphere2.transform.position - sphere1.transform.position);
        rb1.AddForce(direction * 5f, ForceMode.VelocityChange);
    }
}
