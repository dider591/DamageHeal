using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))] 

public class ButtonsAnimator : MonoBehaviour
{
    private const string Damage = "Damage";
    
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ButtonAnimate()
    {
        _animator.SetTrigger(Damage);
    }
}
