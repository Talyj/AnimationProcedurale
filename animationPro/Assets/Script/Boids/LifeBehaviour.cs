using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LifeBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject boidPrefab;
    private BehaviourBoids _boid;
    public float radius;
    private int _survivalRate;
    private float _cooldownLifeCycle = 5;
    void Start()
    {
        _boid = GetComponent<BehaviourBoids>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeCycle();
    }

        private void lifeCycle()
    {
        _cooldownLifeCycle -= Time.deltaTime;
        if (_cooldownLifeCycle <= 0)
        {
            _cooldownLifeCycle = 5;
            var boids = FindObjectsOfType<BehaviourBoids>();
            //var average = Vector3.zero;
            var found = 0;

            foreach (var boid in boids.Where(b => b != _boid))
            {
                var diff = boid.transform.position - transform.position;
                if (diff.magnitude < radius)
                {
                    //average += boid.velocity;
                    found += 1;
                }
            }

            if (found >= 2 && found <= 3)
            {
                /*average = average / found;
                boid.velocity += Vector3.Lerp(boid.velocity, average, Time.deltaTime);*/
                _survivalRate = Random.Range(0, 100);
                if (_survivalRate <= 30)
                {
                    Instantiate(boidPrefab, gameObject.transform.position, Random.rotation);
                }
            }
            else if (found <= 0)
            {
                _survivalRate = Random.Range(0, 100);
                if (_survivalRate <= 10)
                {
                    Destroy(gameObject, 1);
                }
            }
            else if (found >= 5)
            {
                _survivalRate = Random.Range(0, 100);
                if (_survivalRate <= 50)
                {
                    Destroy(gameObject, 1);
                }
            }
        }
    }
}
