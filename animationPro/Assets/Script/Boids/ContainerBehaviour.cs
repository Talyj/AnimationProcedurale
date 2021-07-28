using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BehaviourBoids))]
public class ContainerBehaviour : MonoBehaviour
{
    private BehaviourBoids _boid;
    public float radius;
    public float boundaryForce;
    
    void Start()
    {
        _boid = GetComponent<BehaviourBoids>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_boid.transform.position.magnitude > radius)
        {
            _boid.velocity += transform.position.normalized * (radius - _boid.transform.position.magnitude) * boundaryForce * Time.deltaTime; 
        }
    }
}
