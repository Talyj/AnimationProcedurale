using System.Diagnostics;
using System.Linq;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class AlignementBehaviour : MonoBehaviour
{
    private BehaviourBoids _boid;
    public float radius;
    
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
            var diff = boid.transform.position - transform.position;
            if (diff.magnitude < radius)
            {
                average += boid.velocity;
                found += 1;
            }
        }

        if (found > 0)
        {
            average = average / found;
            _boid.velocity += Vector3.Lerp(_boid.velocity, average, Time.deltaTime);
        }
    }
}
