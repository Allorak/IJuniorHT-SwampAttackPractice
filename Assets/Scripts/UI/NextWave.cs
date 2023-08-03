using System;
using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _nextWaveButton;

    private void OnEnable()
    {
        _spawner.AllEnemiesSpawned += OnAllEnemiesSpawned;
        _nextWaveButton.onClick.AddListener(OnNextWaveButtonClicked);
    }

    private void OnDisable()
    {
        _spawner.AllEnemiesSpawned -= OnAllEnemiesSpawned;
        _nextWaveButton.onClick.RemoveListener(OnNextWaveButtonClicked);
    }

    private void OnAllEnemiesSpawned()
    {
        _nextWaveButton.gameObject.SetActive(true);
    }

    private void OnNextWaveButtonClicked()
    {
        _spawner.NextWave();
        _nextWaveButton.gameObject.SetActive(false);
    }
}
