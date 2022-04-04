using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health: MonoBehaviour
{   
    private float _health = 1f;
    private float _damage = 0.1f;
    private float _heal = 0.1f;
    private float _maxHealth = 1f;
    private float _minHealth = 0f;
    private float _currentHealth;

    public UnityEvent healthEvent;

    public float health => _health;
    public float maxHealth => _maxHealth;
    public float minHealth => _minHealth;
    public float currentHealth => _currentHealth;

    private void SetHealth(float health)
    {
        _health = health;        
    }

    public void Damage()
    {
        _currentHealth = _health;
        _health -= _damage;

        if (_health < minHealth)
        {
            SetHealth(minHealth);
        }

        healthEvent.Invoke();
    }

    public void Heal()
    {
        _currentHealth = _health;
        _health += _heal;

        if (_health > maxHealth)
        {
            SetHealth(maxHealth);
        }

        healthEvent.Invoke();
    }
}
