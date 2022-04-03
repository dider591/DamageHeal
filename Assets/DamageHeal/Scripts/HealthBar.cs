using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject _health;
    [SerializeField] private Slider _bar;

    private Health _healthPlayer;
    private float _speed = 0.1f;
    private float _currentHealth;
    private float _targetHealth;
    private Coroutine _coroutine;

    private void Start()
    {
        _healthPlayer = _health.GetComponent<Health>();
        _bar = GetComponent<Slider>();
        _bar.value = _healthPlayer.health;       
    }

    public void StartDrawHealthbar()
    {
        _currentHealth = _healthPlayer.currentHealth;
        _targetHealth = _healthPlayer.health;

        _coroutine = StartCoroutine(SetHealth());
    }

    private IEnumerator SetHealth()
    {
        while (true)
        {
            _currentHealth = Mathf.MoveTowards(_currentHealth, _targetHealth, _speed * Time.deltaTime);
            _bar.value = _currentHealth;

            if (_currentHealth == _targetHealth || _currentHealth == _healthPlayer.minHealth || _currentHealth == _healthPlayer.maxHealth)
            {
                StopCoroutine(_coroutine);
            }

            yield return null;
        }
    }
}
