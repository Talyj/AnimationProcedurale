using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnBoids : MonoBehaviour
{
    [SerializeField] private GameObject boidPrefab;
    //[SerializeField] private GameObject leaderBoidPrefab;
    public static BehaviourBoids[] _allBoids;
    private GameObject[] allBoids;
    public int nbBoids;
    public float radius;
    private float _cooldownRespawn;
    private GameObject cam;

    private void Start()
    {
        cam = GameObject.FindWithTag("MainCamera");
    }

    private void Update()
    {
        _cooldownRespawn -= Time.deltaTime;
        if (_cooldownRespawn <= 0)
        {
            float dist = Vector3.Distance(cam.transform.position, gameObject.transform.position);
            if (dist < 3000)
            {
                _allBoids = FindObjectsOfType<BehaviourBoids>();
                if (_allBoids.Length <= 80)
                {
                    _cooldownRespawn = 5;
                    for (int i = 0; i < nbBoids; ++i)
                    {
                        Instantiate(boidPrefab, (new Vector3(0, 0, 0) + Random.insideUnitSphere * radius), Random.rotation);
                    }   
                }   
            }
            else
            {
                allBoids = GameObject.FindGameObjectsWithTag("boids");
                if (allBoids.Length > 0)
                {
                    foreach (var boid in allBoids)
                    {
                        Destroy(boid);
                    }   
                }
            }
        }
    }
}
