using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class Health : MonoBehaviour
{   
    private float _targetHealth = 1f;
    private float _damage = 0.1f;
    private float _heal = 0.1f;
    private float _maxHealth = 1f;
    private float _minHealth = 0f;
    private float _currentHealth;

    public event Action<float, float> ChangedHealth;

    public float TargetHealth => _targetHealth;
    public float MaxHealth => _maxHealth;
    public float MinHealth => _minHealth;
    public float CurrentHealth => _currentHealth;

    public void Damage()
    {
        _currentHealth = _targetHealth;
        _targetHealth -= _damage;

        if (_targetHealth < MinHealth)
        {
            _targetHealth = MinHealth;
        }

        ChangedHealth?.Invoke(_currentHealth, _targetHealth);
    }

    public void Heal()
    {
        _currentHealth = _targetHealth;
        _targetHealth += _heal;

        if (_targetHealth > MaxHealth)
        {
            _targetHealth = MaxHealth;
        }

        ChangedHealth?.Invoke(_currentHealth, _targetHealth);
    }
}