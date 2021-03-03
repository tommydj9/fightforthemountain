using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private int round;
    private int zombiePerRound;
    private int currentZombieAlive;
    private int zombieLeft;

    public int zombieFirstRound = 10;
    public int zombieMultiplier = 2;
    public int maxZombieInScene = 3;
    public EnemySpawner enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        round = 1;
        zombiePerRound = zombieFirstRound;


        //enemySpawner.SpawnEnemy(maxZombieInScene, currentZombieAlive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRound()
    {
        round++;
        zombiePerRound *= zombieMultiplier;
        currentZombieAlive = zombiePerRound; //Meglio qui o quando viene istanziato l'enemy
    }

     
}
