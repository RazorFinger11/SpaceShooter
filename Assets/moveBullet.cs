using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBullet : MonoBehaviour
{
    public float shotSpeed;
    public float bulletLifetime;
    void Update()
    {
        this.transform.Translate(transform.forward * shotSpeed * Time.deltaTime);

        Destroy(this, bulletLifetime);
    }
}
