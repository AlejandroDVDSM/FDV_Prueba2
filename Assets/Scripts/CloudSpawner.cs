using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private Cloud _itemPrefab;
    [SerializeField] private int _spawnAmount = 5;
    [SerializeField] private float _repeatRate = 2.5f;

    private List<Cloud> _cloudPool;
    private int _currentCloudIndex;
    
    private void Start()
    {
        InitCloudPool();
    }

    // Instantiate clouds and add them to the pool
    private void InitCloudPool()
    {
        _cloudPool = new List<Cloud>();

        for (int i = 0; i < _spawnAmount; i++)
        {
            _cloudPool.Add(Instantiate(_itemPrefab, transform));
            _cloudPool[i].gameObject.SetActive(false);
        }
        
        InvokeRepeating(nameof(SetPooledCloudActive), 0, _repeatRate);
    }

    // Set active a cloud from the pool
    private void SetPooledCloudActive()
    {
        
        if (_currentCloudIndex < _cloudPool.Count)
        {
            _cloudPool[_currentCloudIndex].gameObject.SetActive(true);
            
            _currentCloudIndex++;
        }
        else
            _currentCloudIndex = 0;
    }
}