using System;
using Roguelike.Units;
using Roguelike.Units.CreateEnemy;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Unit player;
    private FireFactory _fireFactory = new FireFactory();
    private void Start()
    {
        player.Init(new PlayerUnit());
        Unit unit = _fireFactory.CreateSkeleton();
        Debug.Log(unit.GetBehaviour().type);
    }
}
