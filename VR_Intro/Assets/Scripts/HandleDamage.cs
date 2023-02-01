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
    private Zombie zombie;
    
    private void Awake()
    {
        GM = GameManager.Instance;
        rigidbody = GetComponent<Rigidbody>();
        zombie = GetComponent<Zombie>();
    }

    public void TakeDamage(Weapon weapon, Projectile projectile, Vector3 contactPoint)
    {
		Debug.Log("Hit");
        zombie.currentHP -= weapon.GetDamage();
        
        if (zombie.currentHP <= 0)
        {
            GetComponent<Zombie>().Die();
            GM.zombieLeft--;
            GM.numZombiesIndicator.text = "ZOMBIES: " + GM.zombieLeft + "/" + GM.totalWaveZombie; // update UI
        }
    }
}
