using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Zombie))]
[RequireComponent(typeof(Rigidbody))]
public class HandleDamage : MonoBehaviour, ITakeDamage
{
    private GameManager GM;
    
    private Rigidbody rigidbody;
    
    private void Awake()
    {
        GM = GameManager.Instance;
        rigidbody = GetComponent <Rigidbody>();
    }

    public void TakeDamage(Weapon weapon, Projectile projectile, Vector3 contactPoint)
    {
        Debug.Log("Hit");
        GetComponent<Zombie>().Die();
        GM.zombieLeft--;
    }
}
