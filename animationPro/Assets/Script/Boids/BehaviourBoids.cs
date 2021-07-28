using System;
using UnityEngine;

public class BehaviourBoids : MonoBehaviour
{
    public Vector3 velocity;
    public float maxVelocity;

    private void Start()
    {
        velocity = transform.forward * maxVelocity;
    }

    private void Update()
    {
        if (velocity.magnitude > maxVelocity)
        {
            velocity = velocity.normalized * maxVelocity;
        }
    
        transform.position += velocity * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(velocity);
        }
}
