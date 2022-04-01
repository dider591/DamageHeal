using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _maxHealth = 1f;
    private float _minHealth = 0f;
    private float _health;

    public float maxHealth => _maxHealth;
    public float minHealth => _minHealth;
    public float health => _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void SetHealth(float health)
    {
        _health = health;
    }
}
