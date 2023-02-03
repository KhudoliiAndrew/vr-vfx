using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Brackable : MonoBehaviour
{
    public GameObject brokenObject;
    
    public void Broke()
    {
        var spawnedObject = Instantiate(brokenObject, transform.position, transform.rotation);
        spawnedObject.AddComponent<BrockenController>();

        AddVelocityToDestoyedObject(spawnedObject);
        
        Destroy(gameObject);
    }

    private void AddVelocityToDestoyedObject(GameObject gameObject)
    {
        foreach (Transform child in gameObject.transform)
        {
            if(child.GetComponent<Rigidbody>() == null) return;
            child.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 8)
            Broke();
    }
}
