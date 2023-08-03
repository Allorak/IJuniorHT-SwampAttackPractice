using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _target;

    public event UnityAction AllEnemiesSpawned;

    private Wave _currentWave;
    private int _currentWaveIndex = 0;
    private float _timeSinceLastSpawn = 0;
    private int _spawned;

    private void Start()
    {
        SetWave(_currentWaveIndex);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeSinceLastSpawn += Time.deltaTime;

        if (_timeSinceLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;

            _timeSinceLastSpawn = 0;
        }

        if (_currentWave.Count <= _spawned)
        {
            if(_waves.Count > _currentWaveIndex + 1)
                AllEnemiesSpawned?.Invoke();

            _currentWave = null;
        }
    }

    public void NextWave()
    {
        SetWave(++_currentWaveIndex);
        _spawned = 0;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_target);
        enemy.Dying += OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDied;

        _target.AddMoney(enemy.Reward);
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}
