using ThroughMe.Entities;
using TMPro;
using UnityEngine;

namespace ThroughMe.Ui
{
    public class UiGameStatus : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private Portal _portal;
        [SerializeField] private ObstacleLauncher _obstacleLauncher;

        [Header("Ui")]
        [SerializeField] private TextMeshProUGUI _speed;

        private void OnEnable()
        {
            _obstacleLauncher.OnSpeedUpdated += OnUpdateSpeed;
        }

        private void OnDisable()
        {
            _obstacleLauncher.OnSpeedUpdated -= OnUpdateSpeed;
        }

        private void OnUpdateSpeed(int speed) =>
            _speed.text = speed.ToString();
    }
}