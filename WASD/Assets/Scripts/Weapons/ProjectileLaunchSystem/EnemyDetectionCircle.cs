using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionCircle
{
    private GameObject player = GameObject.Find("Player");    
    private Collider2D enemyAroundPlayer;    
    private Collider2D[] enemysAroundPlayer;
    
    public Collider2D[] getEnemysAroundPlayer(float circleRadius)      
    {        
        enemysAroundPlayer = Physics2D.OverlapCircleAll(player.transform.position, circleRadius);
        return enemysAroundPlayer;
    }

    public Collider2D getFirstEnemyAroundPlayer(float circleRadius)
    {             
        enemyAroundPlayer = Physics2D.OverlapCircle(player.transform.position, circleRadius);
        return enemyAroundPlayer;
    }
}
