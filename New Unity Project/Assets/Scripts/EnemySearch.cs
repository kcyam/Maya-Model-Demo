using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearch : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public GameObject player;
    public bool isDead;

    public bool playerDetected;
    public float movementSpeed;
    public float wanderTime;
    public float distanceFinder;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            
            if (player == null)
            {
                FindTarget();

                if (wanderTime > 0)
                {
                    transform.Translate(Vector3.forward * movementSpeed);
                    wanderTime -= Time.deltaTime;
                }

                else
                {
                    wanderTime = Random.Range(5.0f, 15.0f);
                    Wander();
                }
            }

            else
            {
                FollowTarget();
            }
        }

        if(currentHealth <= 0 && !isDead)
        {
            isDead = true;
            currentHealth = 0;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            (gameObject.GetComponent(typeof(SphereCollider)) as Collider).enabled = false;
            anim.enabled = !anim.enabled;
            //Destroy(this.gameObject);
        }
    }

    void FindTarget()
    {
        //Debug.Log("Finding");
        Vector3 center = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Collider[] hitColliders = Physics.OverlapSphere(center, 10);
        int i = 0;
        while(i<hitColliders.Length)
        {
            if(hitColliders[i].transform.tag == "Player")
            {
                //Debug.Log("Found");
                player = hitColliders[i].transform.gameObject;
            }
            i++;
        }
    }

    void FollowTarget()
    {
        //Debug.Log("Found");
        Vector3 targetPosition = player.transform.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);

        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        if(distance < distanceFinder)
        {
            transform.Translate(Vector3.forward * movementSpeed);
        }

        else
        {
            player = null;
        }
    }

    void Wander()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }

    public void GetHit()
    {
        currentHealth -= 1;
    }
    /* Search for player
     * Detect player
     * Follow player
     * 
     * 
     */
}
