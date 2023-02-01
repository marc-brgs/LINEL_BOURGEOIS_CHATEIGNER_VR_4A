using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : MonoBehaviour, ITakeDamage
{
    private GameManager GM;
    
    public int maxHP;
    public int currentHP;
    public float walkSpeed;

    public GameObject healthBarUI;
    public Slider slider;
    
    public NavMeshAgent agent;
    
    public Zombie(int HP)
    {
        maxHP = HP;
        currentHP = HP;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GM = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        
        healthBarUI.transform.LookAt(GM.camera.transform.position);
    }

    void Walk()
    {
        agent.SetDestination(GM.player.transform.position);
        agent.speed = walkSpeed;
    }
    
    public void TakeDamage(Weapon weapon, Projectile projectile, Vector3 contactPoint)
    {
        Debug.Log("Hit");
        currentHP -= weapon.GetDamage();
        slider.value = (float)currentHP/maxHP;
            
        if (currentHP <= 0)
        {
            Die();
            GM.zombieLeft--;
            GM.numZombiesIndicator.text = "ZOMBIES: " + GM.zombieLeft + "/" + GM.totalWaveZombie; // update UI
        }
    }
    
    public void Die()
    {
        Destroy(this.gameObject);
    }
}