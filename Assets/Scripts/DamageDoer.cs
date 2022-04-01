using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(Health))]

public class DamageDoer : MonoBehaviour
{
    [SerializeField] private GameObject _sliderObject;
    [SerializeField] private GameObject _playerObject;

    private Slider _slider;
    private Health _health;
    private float _damage = 0.1f;
    private float _heal = 0.1f;
    private float _speed = 0.1f;
    private Coroutine _coroutineDamage;
    private Coroutine _coroutineHeal;

    private void Start()
    {
        _slider = _sliderObject.GetComponent<Slider>();
        _health = _playerObject.GetComponent<Health>();
        _slider.value = _health.health;
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
        float target = _health.health - _damage;

        while (_health.health != target)
        {
            _health.SetHealth( Mathf.MoveTowards(_health.health, target, _speed * Time.deltaTime));
            _slider.value = _health.health;

            if (_health.health < _health.minHealth)
            {
                _health.SetHealth(_health.minHealth);
            }           

            if (_health.health == target || _health.health == _health.minHealth)
            {
                StopCoroutine(_coroutineDamage);
            }

            yield return null;
        }
    }

    private IEnumerator SetHealHealth()
    {
        float target = _health.health + _heal;

        while (_health.health != target)
        {
            _health.SetHealth( Mathf.MoveTowards(_health.health, target, _speed * Time.deltaTime));
            _slider.value = _health.health;

            if (_health.health > _health.maxHealth)
            {
                _health.SetHealth(_health.maxHealth);
            }

            if (_health.health == target || _health.health == _health.maxHealth)
            {
                StopCoroutine(_coroutineHeal);
            }

            yield return null;
        }
    }
}
