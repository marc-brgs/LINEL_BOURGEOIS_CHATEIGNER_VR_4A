using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    private Weapon weapon;
    [SerializeField] private float lifeTime;
    private Rigidbody rigidbody;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(Weapon weapon)
    {
        this.weapon = weapon;
        Destroy(gameObject, lifeTime);
    }
    
    public void Launch()
    {
        rigidbody.AddRelativeForce(Vector3.forward * weapon.GetShootingForce(), ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        ITakeDamage[] damageTakers = other.GetComponentsInChildren<ITakeDamage>();

        foreach (var taker in damageTakers)
        {
            taker.TakeDamage(weapon, this, transform.position);
            Debug.Log("Hit");
        }
    }
}
