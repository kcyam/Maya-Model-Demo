using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBack : MonoBehaviour
{

    public float force = 1;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            //Debug.Log("Ouch");
            Vector3 pushDirection = other.transform.position - transform.position;

            pushDirection = -pushDirection.normalized;

            GetComponent<Rigidbody>().AddForce(pushDirection * force * 100);

        }
    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.tag == "Player")// && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Punch");
            Vector3 pushDirection = other.transform.position - transform.position;

            pushDirection = -pushDirection.normalized;

            GetComponent<Rigidbody>().AddForce(pushDirection * force * 100);
        }
        
    }
}
