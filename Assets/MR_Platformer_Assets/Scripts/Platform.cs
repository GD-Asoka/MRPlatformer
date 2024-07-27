using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Platform : MonoBehaviour
{
    public bool move, rotate;
    public Transform endPoint, startPoint;
    private Rigidbody rb;

    private void Awake()
    {
        if(endPoint && startPoint)
            direction = (endPoint.position - transform.position).normalized;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        //if (move)
        //    rb.constraints = RigidbodyConstraints.FreezeRotation;
        //if (rotate)
        //    rb.constraints = RigidbodyConstraints.FreezePosition;
    }

    public float speed = 10f, checkDist = 0.01f;
    public float destinationCheck = 0.5f;
    private float destCheckDelta = 0;
    

    public Vector3 rotationAxis;
    public float rotationSpeed;
    private Vector3 destination, direction;

    private void Update()
    {
        destCheckDelta += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (move)
        {
            rb.velocity = direction * speed * Time.fixedDeltaTime;
            if (Vector3.Distance(transform.position, endPoint.position) <= checkDist && destCheckDelta >= destinationCheck)
            {
                transform.position = endPoint.position;
                direction *= -1;
                destCheckDelta = 0;
                destination = startPoint.position;
                return;
            }
            if (Vector3.Distance(transform.position, startPoint.position) <= checkDist && destCheckDelta >= destinationCheck)
            {
                transform.position = startPoint.position;
                direction *= -1;
                destCheckDelta = 0;
                destination = endPoint.position;
                return;
            }
        }
        if(rotate)
        {
            transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
            //rb.AddTorque(rotationAxis * rotationSpeed * Time.fixedDeltaTime);
        }   
    }
}
