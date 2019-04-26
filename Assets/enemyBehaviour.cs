using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    public Transform target;
    public bool active;

    public float movesSpeed;

    private float startTime;
    private float journeyLength;


    public Transform startPatrol;
    public Transform endPatrol;
    private float curRoute = 0;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

        journeyLength = Vector3.Distance(transform.position, endPatrol.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {

            Debug.Log(Vector3.Distance(transform.position, target.position));

            float distCovered = (Time.time - startTime) * movesSpeed;

            float fracJourney = distCovered / journeyLength;

            transform.position = Vector3.Lerp(this.transform.position, target.transform.position, fracJourney);

            Vector3 direction = target.transform.position - transform.position;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime);
        }

        if(!active)
        {
            if (curRoute == 0)
            {
                float distCovered = (Time.time - startTime) * movesSpeed;

                float fracJourney = distCovered / journeyLength;

                transform.position = Vector3.Lerp(this.transform.position, endPatrol.transform.position, fracJourney);

                Vector3 direction = endPatrol.transform.position - transform.position;

                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime);

                if (Vector3.Distance(transform.position, endPatrol.position) <= 1)
                {
                    Debug.Log("Route Change!!");
                    startTime = Time.time;

                    journeyLength = Vector3.Distance(transform.position, startPatrol.transform.position);

                    curRoute++;
                }
            }
            else if (curRoute == 1)
            {
                float distCovered = (Time.time - startTime) * movesSpeed;

                float fracJourney = distCovered / journeyLength;

                transform.position = Vector3.Lerp(this.transform.position, startPatrol.transform.position, fracJourney);

                Vector3 direction = startPatrol.transform.position - transform.position;

                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime);

                if (Vector3.Distance(transform.position, startPatrol.position) <= 1)
                {
                    startTime = Time.time;

                    journeyLength = Vector3.Distance(transform.position, endPatrol.transform.position);

                    curRoute--;
                }
            }
        }


        if (Vector3.Distance(transform.position, target.position) <= 12.5f)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

            startTime = Time.time;

            journeyLength = Vector3.Distance(transform.position, target.transform.position);

            active = true;
        }

        if(other.gameObject.tag == "EnemyTarget")
        {
            //Destroy(this.gameObject);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Destroy(this.gameObject);
    }
}
