using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyWander : MonoBehaviour
{
    //navigation
    public GameObject leftPoint;
    public GameObject rightPoint;
    public float navPointRadius;
    


    // Properties
    private Rigidbody rigidBody;
    private Transform currentNavTarget;
    public float movementSpeed;


    public float rotationSpeed;

    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        currentNavTarget = leftPoint.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        float navTargetDistance = Vector3.Distance(currentNavTarget.position, transform.position);

        if (currentNavTarget == leftPoint.transform)
        {
            rigidBody.velocity = new Vector3(-movementSpeed, 0, 0);
        }
        else if (currentNavTarget == rightPoint.transform)
        {
            rigidBody.velocity = new Vector3(movementSpeed, 0, 0);
        }
        if ((navTargetDistance < navPointRadius) && currentNavTarget == leftPoint.transform)
        {
            targetRotation = Quaternion.AngleAxis(180, Vector3.up);
            currentNavTarget = rightPoint.transform;
        }
        else if ((navTargetDistance < navPointRadius) && currentNavTarget == rightPoint.transform)
        {
            targetRotation = Quaternion.AngleAxis(0, Vector3.down);
            currentNavTarget = leftPoint.transform;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(leftPoint.transform.position, navPointRadius);
        Gizmos.DrawWireSphere(rightPoint.transform.position, navPointRadius);
        Gizmos.DrawLine(leftPoint.transform.position, rightPoint.transform.position);
    }

    private void flip(Quaternion targetRotation)
    {
        
    }
}
