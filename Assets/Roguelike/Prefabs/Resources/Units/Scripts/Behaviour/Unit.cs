using System;
using Roguelike.Architecture.Scripts;
using Roguelike.Units;
using UnityEngine;

namespace  Roguelike.Units
{
    [RequireComponent(typeof(Rigidbody))]
    public class Unit : MonoBehaviour, IUpdateble
    {
        private UnitBehaviour behaviour;
        [SerializeField] private float speed;
        public void Init(UnitBehaviour behaviour)
        {
            GlobalUpdater.updatebles.Add(this);
            this.behaviour = behaviour;
            this.behaviour?.Init(300, this.gameObject);
        }

        public void Updates()
        {
            behaviour?.UnitUpdate();
        }

        public void FixedUpdates()
        {
            behaviour?.UnitFixedUpdate();
        }

        public UnitBehaviour GetBehaviour()
        {
            return behaviour;
        }
    }
}

