using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private List<Tank> _tanks;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _delayBetweenSpawn = 3f;

    private int _pointsCount;
    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _pointsCount = _spawnPoints.Count;
        _waitForSeconds = new WaitForSeconds(_delayBetweenSpawn);

        StartCoroutine(SpawnTank());
    }

    private IEnumerator SpawnTank()
    {
        while (true)
        {
            int tanksCount = Stats.Level < _tanks.Count ? Stats.Level : _tanks.Count;
            Instantiate(TakeRandomObject(_tanks, tanksCount), TakeRandomObject(_spawnPoints, _pointsCount).position, transform.rotation);
            yield return _waitForSeconds;
        }
    }

    private T TakeRandomObject<T>(List<T> collection, int maxValue)
    {
        int index= Random.Range(0, maxValue);
        return collection[index];
    }
}
