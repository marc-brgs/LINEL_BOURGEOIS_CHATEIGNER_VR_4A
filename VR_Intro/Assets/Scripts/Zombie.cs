using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    private GameManager GM;
    
    public int maxHP;
    public int currentHP;
    public int damage;
    public float walkSpeed;

    public NavMeshAgent agent;

    public Zombie(int HP, int damage)
    {
        maxHP = HP;
        currentHP = HP;
        this.damage = damage;
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
    }

    void Walk()
    {
        /*
        var step =  walkSpeed * Time.deltaTime; // calculate distance to move
        // transform.position = Vector3.MoveTowards(transform.position, GM.player.transform.position, step);
        this.GetComponent<Rigidbody>().velocity =
            -Vector3.MoveTowards(transform.position, GM.player.transform.position, step).normalized * walkSpeed;
            */
        
        agent.SetDestination(GM.player.transform.position);
        agent.speed = walkSpeed;
    }

    public void Die()
    {
        Destroy(this);
    }
}