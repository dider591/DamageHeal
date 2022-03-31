using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class DamageDoer : MonoBehaviour
{
    [SerializeField] private GameObject _sliderOdject;

    private Slider _slider;
    private float _maxHealth = 1f;
    private float _minHealth = 0f;
    private float _damage = 0.1f;
    private float _health;
    private Coroutine _coroutineDamage;
    private Coroutine _coroutineHeal;

    public float maxHealth => _maxHealth;

    private void Start()
    {
        _slider = _sliderOdject.GetComponent<Slider>();

        _health = _maxHealth;
        _slider.value = _health;
    }

    public void Damage()
    {
        _coroutineDamage = StartCoroutine((IEnumerator)SetDamageHealth());

        if (_health < _minHealth)
        {
            _health = _minHealth;
        }
    }

    public void Heal()
    {
        _coroutineHeal = StartCoroutine((IEnumerator)SetHealHealth());

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    private IEnumerable SetDamageHealth()
    {
        while (_health != _health - _damage)
        {
            _health = Mathf.MoveTowards(_health, _health - _damage, _damage * Time.deltaTime);
            _slider.value = _health;
        }

        yield return null;
    }

    private IEnumerable SetHealHealth()
    {
        while (_health != _health + _damage)
        {
            _health = Mathf.MoveTowards(_health, _health + _damage, _damage * Time.deltaTime);
            _slider.value = _health;
        }

        yield return null;
    }
}
