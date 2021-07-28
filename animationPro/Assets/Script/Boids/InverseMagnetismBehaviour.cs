using System.Linq;
using UnityEngine;

public class InverseMagnetismBehaviour : MonoBehaviour
{
    private BehaviourBoids _boid;

    public float radius;
    public float repulsionForce;
    
    void Start()
    {
        _boid = GetComponent<BehaviourBoids>();
    }

    // Update is called once per frame
    void Update()
    {
        var boids = FindObjectsOfType<BehaviourBoids>();
        var average = Vector3.zero;
        var found = 0;

        foreach (var boid in boids.Where(b => b != _boid))
        {
            var diff = boid.transform.position - this.transform.position;
            if (diff.magnitude < radius)
            {
                average += diff;
                found += 1;
            }
        }

        if (found > 0)
        {
            average = average / found;
            _boid.velocity -= Vector3.Lerp(Vector3.zero, average, average.magnitude / radius) * repulsionForce;
        }
    }
}
