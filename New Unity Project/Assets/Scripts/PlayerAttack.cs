using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public CeruleanAnimation anim;
    public EnemySearch es;
    private Animator anim_p;
    // Start is called before the first frame update
    void Start()
    {
        anim_p = GetComponent<Animator>();
        (gameObject.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            (gameObject.GetComponent(typeof(BoxCollider)) as Collider).enabled = true;
            //Debug.Log("Scratch");
            //anim_p.SetTrigger("Scratch");
        }

        else
        {
            (gameObject.GetComponent(typeof(BoxCollider)) as Collider).enabled = false;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        Debug.Log("Trigg");
        //if (other.tag == "Enemy" && Input.GetMouseButtonDown(0))
        //{
            //Debug.Log("Trigger");
            anim.Hurt();
        es.GetHit();
        //}
    }
}
