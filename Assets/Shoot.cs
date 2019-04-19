using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject bullet;
    public GameObject shootPoint;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, new Vector3(shootPoint.transform.position.x, shootPoint.transform.position.y, shootPoint.transform.position.z), Quaternion.LookRotation(this.transform.forward));
        }
    }
}
