using ThroughMe.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThroughMe.Somethings
{
    public class GameStatus : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private Portal _portal;
        [SerializeField] private ObstacleLauncher _obstacleLauncher;

        [Header("Data")]
        [SerializeField] private Data _health;
        [SerializeField] private Image _heart;
        [SerializeField] private Transform _heartContainer;

        [Header("Ui")]
        [SerializeField] private TextMeshProUGUI _speed;
        
        private GameObject[] _hearts;

        private int _initialHealth;
        private int _currentHealth;

        private void Awake()
        {
            _initialHealth = _health.Value;
            _currentHealth = _health.Value;

            SpawnHeart();
        }

        private void OnEnable()
        {
            _obstacleLauncher.OnSpeedUpdated += OnUpdateSpeed;
            _portal.OnObstacleCrashed += OnReduceHeart;
            _portal.OnDied += OnReduceHeart;
        }

        private void OnDisable()
        {
            _obstacleLauncher.OnSpeedUpdated -= OnUpdateSpeed;
            _portal.OnObstacleCrashed -= OnReduceHeart;
            _portal.OnDied -= OnReduceHeart;
        }

        private void OnUpdateSpeed(int speed) =>
            _speed.text = $"Speed {speed}";

        private void OnReduceHeart()
        {
            _currentHealth--;
            for (int i = _currentHealth; i < _initialHealth; i++)
                _hearts[i].SetActive(false);
        }

        private void SpawnHeart()
        {
            _hearts = new GameObject[_initialHealth];
            for (int i = 0; i < _initialHealth; i++)
            {
                _hearts[i] = Instantiate(_heart, _heartContainer).gameObject;
                _hearts[i].name = $"heart {i}";
            }
        }
    }
}