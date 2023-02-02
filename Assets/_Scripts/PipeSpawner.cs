using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnRate;
    [SerializeField] private float minHeight;
    [SerializeField] private float maxHeight;

    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnPipe), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnPipe));
    }

    private void SpawnPipe()
    {
        if (!UIManager.isGameStarted) return;
        if (Player.isPause) return;
        
        GameObject pipes = Instantiate(pipePrefab, transform.position, Quaternion.identity, transform);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
