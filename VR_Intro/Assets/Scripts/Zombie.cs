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

    private bool isInRange = false;
    public bool canAttack;

    public int power;
    
    
    public GameObject healthBarUI;
    public Slider slider;
    
    public NavMeshAgent agent;

    public bool dawae = false;
    public AudioClip dawaeSound;
    public AudioSource audioSource;

    public float dist;
    

    public Zombie(int HP)
    {
        maxHP = HP;
        currentHP = HP;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GM = GameManager.Instance;
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        
        healthBarUI.transform.LookAt(GM.camera.transform.position);

        dist = Vector3.Distance(this.transform.position, GM.player.transform.position);

        if (dawae == false && dist < 2)
        {
            dawae = true;
            audioSource.clip = dawaeSound;
            audioSource.Play();
        }

        if (dist > 3)
        {
            dawae = false;
        }

        if (dist < 1)
        {
            if (canAttack == true)
            {
                StartCoroutine(DealDamage());
            }
        }
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


    public IEnumerator DealDamage()
    {
        if (Random.Range(0, 5) > 1)
        {
            canAttack = false;
            PlayerHealth.instance.TakeDamage(power);
            yield return new WaitForSeconds(1f);
            canAttack = true;
        }
    }
    
    public void Die()
    {
        Destroy(this.gameObject);
    }
}