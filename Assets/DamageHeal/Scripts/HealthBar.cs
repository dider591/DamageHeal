using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _bar;

    private float _speed = 0.05f;
    private float _currentHealth;
    private float _targetHealth;
    private Coroutine _coroutine;

    private void Start()
    {
        _health = GetComponent<Health>();
        _health.ChangedHealth += StartDraw;
        _bar = GetComponent<Slider>();
        _bar.value = _health.TargetHealth;       
    }

    public void StartDraw(float current, float Target)
    {
        _currentHealth = current;
        _targetHealth = Target;

        _coroutine = StartCoroutine(SetHealth());
    }

    private IEnumerator SetHealth()
    {
        while (_currentHealth != _targetHealth || _currentHealth != _health.MinHealth || _currentHealth != _health.MaxHealth)
        {
            _currentHealth = Mathf.MoveTowards(_currentHealth, _targetHealth, _speed * Time.deltaTime);
            _bar.value = _currentHealth;

            yield return null;
        }

        StopCoroutine(_coroutine);
    }

    private void OnDisable()
    {
        _health.ChangedHealth -= StartDraw;
    }
}
