using System.Collections.Generic;
using System.Linq;
using Roguelike.Units;
using UnityEngine;
using UnityEngine.VFX;

namespace Roguelike.Skills
{
    public class Water : Skill
    {
        private int currentWave = -1;
        private List<GameObject> allEffects = new List<GameObject>();
        public Water(List<GameObject> effect)
        {
            allEffects = effect;
        }
        public override void Set()
        {
            Name = "Water";
            Type = ElementType.Water;
            ManaCast = 10;
            DefaultDamage = 4;
            CooldownTime = 1f;
            //callbacks subscribe
            foreach (var effect in allEffects)
            {
                effect.GetComponent<CollisionHandler>()._action += SingleDamage;
            }
        }
        public override void Cast(GameObject user)
        {
            if (CanCast)
            {
                CanCast = false;
                currentWave++;
                Effect = allEffects[currentWave];
                Effect.transform.position = user.transform.Find("SkillPoint").position;
                Effect.transform.position = new Vector3(Effect.transform.position.x, 0.0689999f,Effect.transform.position.z);
                Effect.transform.rotation = user.transform.rotation;
                Effect.GetComponent<CollisionHandler>().SetEffect(this);
                Effect.SetActive(true);
                if (currentWave >= allEffects.Count -1)
                {
                    currentWave = -1;
                }
                Debug.Log(currentWave);
                Debug.Log(allEffects.Count);
            }
        }
        
        public override void StopCast()
        {
            
        }
    }
}