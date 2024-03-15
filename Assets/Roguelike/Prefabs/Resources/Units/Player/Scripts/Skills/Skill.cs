using System;
using System.Collections.Generic;
using System.Linq;
using Roguelike.Units;
using UnityEngine;
namespace Roguelike.Skills
{
    public abstract class Skill
    {
        protected float ManaCast;
        protected int DefaultDamage;
        protected ElementType Type;
        protected bool CanCast = true;
        public string Name;
        public float CooldownTime;
        public GameObject Effect;
        public List<Transform> Transforms = new List<Transform>();
        private float maxTime;
        private float currentTime = 0;
        
        public abstract void Set();

        public abstract void Cast(GameObject user);

        public abstract void StopCast();

        protected virtual void SplashDamage()
        {
            for (int i = 0; i < Transforms.Count; i++)
            {
                if (Transforms[i].TryGetComponent<Unit>(out Unit unit))
                {
                    unit.GetBehaviour().stats.TakeDamage(DamageCalculator.DoCalc(DefaultDamage, Type, unit.GetBehaviour().type));
                    Debug.Log($"unit name: {unit.name} unit hp {unit.GetBehaviour().stats.HP}");
                }
            }
        }

        protected virtual void SingleDamage()
        {
            if(Transforms.Count <= 0)
                return;

            if (Transforms[0].TryGetComponent<Unit>(out Unit unit))
            {
                unit.GetBehaviour().stats.TakeDamage(DamageCalculator.DoCalc(DefaultDamage, Type, unit.GetBehaviour().type));
                Debug.Log($"unit name: {unit.name} unit hp {unit.GetBehaviour().stats.HP}");
            }
            Effect.SetActive(false);
        }
        public void Cooldown(float time)
        {
            maxTime = time;
            if (currentTime >= maxTime)
            {
                CanCast = true;
                currentTime = 0;
            }
            else
            {
                currentTime += Time.deltaTime;
            }
        }

        protected void ClearTransforms()
        {
            Transforms.Remove(Transforms.FirstOrDefault(x =>
                x.gameObject.GetComponent<Unit>()?.GetBehaviour().stats.HP <= 0));
        }
    }
}