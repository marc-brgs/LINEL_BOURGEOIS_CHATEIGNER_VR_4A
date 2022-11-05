using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    
    public GameObject player;
    private int wave = 0;
    private int zombieLeft = 0;

    private void Awake() 
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else 
        {
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        randomSummon(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    
    void randomSummon(int zombieNumber)
    {
        for (int i = 0; i < zombieNumber; i++)
        {
            var zombie = Resources.Load<GameObject>("Zombie");
            int randX = UnityEngine.Random.Range(-19, 19);
            int randZ = UnityEngine.Random.Range(-19, 19);
            randX = randX < 5 && randX > -5 ? randX * 2 : randX;
            randZ = randZ < 5 && randZ > -5 ? randZ * 2 : randZ;
            Instantiate(zombie, new Vector3(randX,0.5f,randZ), Quaternion.identity);
        }
        
    }
}
