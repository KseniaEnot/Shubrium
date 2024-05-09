using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Health player;

    public string playerTag;

    public float damage;

    private float timeBeforeNextAttack;
    public float timeBetweeenAttack;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(playerTag).GetComponent<Health>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == playerTag)
        {
            if (timeBeforeNextAttack <= 0)
            {
                OnEnemyAttack();
            }
        }
    }

    private void FixedUpdate()
    {
        if (timeBeforeNextAttack > 0)
        {
            timeBeforeNextAttack -= Time.deltaTime;
        }
    }

    public void OnEnemyAttack()
    {
        player.TakeDamage(damage);
        timeBeforeNextAttack = timeBetweeenAttack;
    }
}
