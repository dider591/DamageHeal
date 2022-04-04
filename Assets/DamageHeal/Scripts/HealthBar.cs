using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _bar;

    private float _speed = 0.1f;
    private float _currentHealth;
    private float _targetHealth;
    private bool _isRunning = true;

    private void Start()
    {
        _health = GetComponent<Health>();
        _health.Changed += StartDraw;
        _bar = GetComponent<Slider>();
        _bar.value = _health.TargetHealth;       
    }

    private void StartDraw(float current, float Target)
    {
        _currentHealth = current;
        _targetHealth = Target;

        if (_isRunning)
        {
            StartCoroutine(SetHealth());
        }
    }

    private IEnumerator SetHealth()
    {
        _isRunning = false;

        while (_currentHealth != _targetHealth)
        {
            _currentHealth = Mathf.MoveTowards(_currentHealth, _targetHealth, _speed * Time.deltaTime);
            _bar.value = _currentHealth;

            yield return null;
        }

        _isRunning = true;
    }

    private void OnDisable()
    {
        _health.Changed -= StartDraw;
    }
}
