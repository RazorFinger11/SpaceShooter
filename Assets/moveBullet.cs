using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBullet : MonoBehaviour
{
    public float shotSpeed;
    public float bulletLifetime;
    public GameObject ship;
    public GameObject target;

    public string targetName;
    public string shooterName;

    private float startTime;
    private float journeyLength;

    public bool isTurret;

    public GameObject turretBarrel;

    private void Start()
    {
        if (!isTurret)
        {
            ship = GameObject.Find("StarSparrow9");
            target = GameObject.Find(targetName);
        }
        else
        {
            ship = this.gameObject;
            turretBarrel = this.transform.GetChild(0).gameObject;
            target = turretBarrel.transform.GetChild(1).gameObject;
        }

        startTime = Time.time;

        journeyLength = Vector3.Distance(ship.transform.position, target.transform.position);
    }

    void Update()
    {
        //this.transform.Translate(ship.transform.forward * shotSpeed * Time.deltaTime);
        float distCovered = (Time.time - startTime) * shotSpeed;

        float fracJourney = distCovered / journeyLength; 

        transform.position = Vector3.Lerp(ship.transform.position, target.transform.position, fracJourney);

        Destroy(this.gameObject, bulletLifetime);
    }
}
