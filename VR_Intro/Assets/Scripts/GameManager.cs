using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    
    public GameObject player;
    public List<GameObject> zombies;
    private int wave = 0;
    public int zombieLeft = 0;

    private int initialNumberOfZombies = 4;
    
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
        // RandomSummon(10);
    }

    // Update is called once per frame
    void Update()
    {
        if (zombieLeft == 0)
        {
            zombies.Clear();
            NextWave();
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            foreach (var zombie in zombies)
            {
                Destroy(zombie);
                zombieLeft--;
            }
            zombies.Clear();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    
    void RandomSummon(int zombieNumber)
    {
        for (int i = 0; i < zombieNumber; i++)
        {
            var zombie = Resources.Load<GameObject>("Zombie");
            int randX = UnityEngine.Random.Range(-19, 19);
            int randZ = UnityEngine.Random.Range(-19, 19);
            randX = randX < 5 && randX > -5 ? randX * 2 : randX;
            randZ = randZ < 5 && randZ > -5 ? randZ * 2 : randZ;
            zombies.Add(Instantiate(zombie, new Vector3(randX,0.5f,randZ), Quaternion.identity));
            zombieLeft++;
        }
    }

    void BossSummon()
    {
        var zombie = Resources.Load<GameObject>("Zombie");
        int randX = UnityEngine.Random.Range(-19, 19);
        int randZ = UnityEngine.Random.Range(-19, 19);
        randX = randX < 5 && randX > -5 ? randX * 2 : randX;
        randZ = randZ < 5 && randZ > -5 ? randZ * 2 : randZ;
        zombies.Add(Instantiate(zombie, new Vector3(randX,0.5f,randZ), Quaternion.identity));
        zombieLeft++;
    }

    void NextWave()
    {
        wave++;
        if (wave % 5 == 0)
        {
            BossSummon();
        }
        else
        {
            RandomSummon(initialNumberOfZombies + wave);
        }
        Debug.Log("Wave " + wave + ", zombies " + zombieLeft);
    }
}
