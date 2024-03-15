using System;
using Roguelike.Skills;
using UnityEngine;

public class SERVICELOCAROR_GAMEPLAY : MonoBehaviour
{
    [SerializeField] private EffectsList _effectsList;
    [SerializeField] private GameObject Player;
    private void Awake()
    {
        ServiceLocator serviceLocator = new ServiceLocator();
        ServiceLocator.current.Register(_effectsList);
    }
}
