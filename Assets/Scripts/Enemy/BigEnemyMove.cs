using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyMove : MonoBehaviour
{
    public Transform spawnPoint;
    public float movementSpeed;
    private Rigidbody rb;

    private Vector3 movementDirection = Vector3.up;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = movementDirection * movementSpeed;
    }

    // Update is called once per frame

    public void Respawn()
    {
        transform.position = spawnPoint.position;
    }
}
