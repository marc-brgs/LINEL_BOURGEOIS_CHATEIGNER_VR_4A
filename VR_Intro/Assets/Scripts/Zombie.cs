using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private GameManager GM;
    
    public int maxHP;
    public int currentHP;
    public int damage;
    public float walkSpeed;

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
        walkSpeed = .7f;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    void Walk()
    {
        var step =  walkSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, GM.player.transform.position, step);
    }
}
