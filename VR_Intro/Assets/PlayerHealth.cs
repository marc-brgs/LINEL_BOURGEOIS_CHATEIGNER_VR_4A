using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public int maxHealth = 100;
    public int currentHealth;
    public bool canRegen;

    public HealthBar healthBar;
    
    void Awake()
    {
        if(instance != null){
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scene");
            return ;
        }
        instance = this;
    }
    
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        canRegen = true;

    }

    void Update()
    {

        if (canRegen == true)
        {
            StartCoroutine(PlayerRegen());
        }


        if (currentHealth <= 0)
        {
            PlayerDeath();
        }
    }
    

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Regenerate()
    {
        if (currentHealth <= maxHealth -3)
        {
            currentHealth += 3;
            healthBar.SetHealth(currentHealth);
        }
    }

    public void PlayerDeath()
    {
        SceneManager.LoadScene("Menu");
    }


    public IEnumerator PlayerRegen()
    {
        canRegen = false;
        Regenerate();
        yield return new WaitForSeconds(1f);
        canRegen = true;
        
    }
    
}
