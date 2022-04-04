using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class Health : MonoBehaviour
{   
    private float _targetHealth = 1f;
    private float _steepValue = 0.1f;
    private float _maxHealth = 1f;
    private float _minHealth = 0f;
    private float _currentHealth;

    public event Action<float, float> Changed;

    public float TargetHealth => _targetHealth;
    public float MaxHealth => _maxHealth;
    public float MinHealth => _minHealth;
    public float CurrentHealth => _currentHealth;

    public void Damage()
    {       
        _currentHealth = _targetHealth;
        _targetHealth -= _steepValue;

        _targetHealth = Mathf.Clamp(_targetHealth, _minHealth, _maxHealth);

        Changed?.Invoke(_currentHealth, _targetHealth);
    }

    public void Heal()
    {
        _currentHealth = _targetHealth;
        _targetHealth += _steepValue;

        _targetHealth = Mathf.Clamp(_targetHealth, _minHealth, _maxHealth);

        Changed?.Invoke(_currentHealth, _targetHealth);
    }
}