using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private GameManager GM;
    
    public int maxHP;
    public int currentHP;
    public int damage;
    
    private float walkSpeed = .7f;
    
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
        var step =  walkSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, GM.player.transform.position, step);
    }
}
