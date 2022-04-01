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
    private float _speed = 0.1f;
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
        _coroutineDamage = StartCoroutine(SetDamageHealth());
    }

    public void Heal()
    {
        _coroutineHeal = StartCoroutine(SetHealHealth());
    }

    private IEnumerator SetDamageHealth()
    {
        float target = _health - _damage;

        while (_health != target)
        {
            _health = Mathf.MoveTowards(_health, target, _speed * Time.deltaTime);
            _slider.value = _health;

            if (_health < _minHealth)
            {
                _health = _minHealth;
            }           

            if (_health == target || _health == _minHealth)
            {
                StopCoroutine(_coroutineDamage);
            }

            yield return null;
        }
    }

    private IEnumerator SetHealHealth()
    {
        float target = _health + _damage;

        while (_health != target)
        {
            _health = Mathf.MoveTowards(_health, target, _speed * Time.deltaTime);
            _slider.value = _health;

            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }

            if (_health == target || _health == _maxHealth)
            {
                StopCoroutine(_coroutineHeal);
            }

            yield return null;
        }
    }
}
