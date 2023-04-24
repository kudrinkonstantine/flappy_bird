using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

public class PipeGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnHeight;
    [SerializeField] private float _minSpawnHeight;

    private float _elapsedTime = 0;

    private void Start()
    {
        ResetPool();
        Initialize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {

            if (TryGetObject(out GameObject pipe))
            {
                _elapsedTime = 0;

                float spawnHeight = Random.Range(_minSpawnHeight, _maxSpawnHeight);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnHeight, transform.position.z);

                pipe.SetActive(true);
                pipe.transform.position = spawnPoint;

                DisableObjectPastScreen();
            }
        }
    }
}
