using System;
using Roguelike.Skills;
using Roguelike.Units;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    private Transform _transform;
    private Skill currentEffect;
    public Action _action;
    
    private void OnTriggerEnter(Collider other)
    {
        _transform = other.transform;
        if (_transform.TryGetComponent(out Unit unit))
            if(unit.GetBehaviour().Name == "Player")
                return;
        if(currentEffect.Transforms.Contains(_transform))
            return;
        currentEffect.Transforms.Add(_transform);
        _action?.Invoke();
    }
    
    private void OnTriggerExit(Collider other)
    {
        currentEffect.Transforms.Remove(_transform);
    }

    private void OnDisable()
    {
        currentEffect.Transforms.Remove(_transform);
    }

    public void SetEffect(Skill currentEffect)
    {
        this.currentEffect = currentEffect;
    }
}
