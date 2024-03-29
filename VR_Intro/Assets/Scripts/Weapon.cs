using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
public class Weapon : MonoBehaviour
{
    [SerializeField] protected float shootingForce;
    [SerializeField] protected Transform bulletSpawn;
    [SerializeField] private float recoilForce;
    [SerializeField] private int damage;
    
    private Rigidbody rigidbody;
    private XRGrabInteractable interactableWeapon;
    
    protected void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        interactableWeapon = GetComponent<XRGrabInteractable>();
    }

    public virtual void Shoot()
    {
        ApplyRecoil();
        Debug.Log("Shoot");
    }

    private void ApplyRecoil()
    {
        rigidbody.AddRelativeForce(Vector3.back * recoilForce, ForceMode.Impulse);
    }

    public float GetShootingForce()
    {
        return shootingForce;
    }
    
    public int GetDamage()
    {
        return damage;
    }
}
