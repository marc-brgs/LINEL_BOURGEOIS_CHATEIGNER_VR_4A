using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private GameObject bulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Shoot()
    {
        base.Shoot();
        GameObject projectileInstance = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }
}
