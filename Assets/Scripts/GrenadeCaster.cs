using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public float damage = 30;

    public Rigidbody grenadePrefab;
    public Transform grenadeSourceTransform;

    public float force = 10;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var explosion = Instantiate(grenadePrefab);
            explosion.transform.position = grenadeSourceTransform.position;
            explosion.GetComponent<Rigidbody>().AddForce(grenadeSourceTransform.forward * force);
            explosion.GetComponent<Grenade>().damage = damage;
        }
    }
}
