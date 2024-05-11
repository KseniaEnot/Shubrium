using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BigEnemyStarter : MonoBehaviour
{
    public BigEnemyMove BigEnemy;

    public UnityEvent bigEnemyStarted;

    private float bigEnemySpeed;

    private void Start()
    {
        bigEnemySpeed = BigEnemy.movementSpeed;
        BigEnemy.movementSpeed = 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BigEnemy.movementSpeed = bigEnemySpeed;
            bigEnemyStarted.Invoke();
            gameObject.SetActive(false);
        }
        
    }
}
