using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeruleanAnimation : MonoBehaviour
{

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hurt()
    {
        anim.SetTrigger("CeruleanHit");
    }
    /*
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigg");
        if (other.tag == "Player" && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Trigger");
            anim.SetTrigger("CeruleanHit");
        }
    }
    */
}
