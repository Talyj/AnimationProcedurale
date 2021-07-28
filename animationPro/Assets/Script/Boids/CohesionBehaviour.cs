using System.Linq;
using UnityEngine;


[RequireComponent(typeof(BehaviourBoids))]
public class CohesionBehaviour : MonoBehaviour
{
    //public Vector3 leaderBoid;
    
    private BehaviourBoids _boid;
    public float radius;
    
    void Start()
    {
        _boid = GetComponent<BehaviourBoids>();
    }

    // Update is called once per frame
    void Update()
    {
        //leaderBoid = GameObject.FindGameObjectWithTag("leaderBoids").transform.position;
        // get the epicenter of every boids
        var boids = FindObjectsOfType<BehaviourBoids>();
        var average = Vector3.zero;
        var found = 0;

        foreach (var boid in boids.Where(b => b != _boid))
        {
            var diff = boid.transform.position - transform.position;
            if (diff.magnitude < radius)
            {
                average += diff;
                found += 1;
            }
        }

        if (found > 0)
        {
            average = average / found;
            _boid.velocity += Vector3.Lerp(Vector3.zero, average, average.magnitude / radius);
        }
    }
}
