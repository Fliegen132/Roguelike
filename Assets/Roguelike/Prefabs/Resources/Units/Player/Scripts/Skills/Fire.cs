using System.Linq;
using Roguelike.Units;
using UnityEngine;

namespace Roguelike.Skills
{
    public class Fire : Skill
    {
        public Fire(GameObject effect)
        {
            Effect = effect;
        }

        public override void Set()
        {
            Name = "Fire";
            Type = ElementType.Fire;
            ManaCast = 10;
            DefaultDamage = 2;
            CooldownTime = 0.4f;
        }
        public override void Cast(GameObject user)
        {
            ClearTransforms();
            Effect.transform.position = user.transform.Find("SkillPoint").position;
            Effect.transform.rotation = user.transform.rotation;
            Effect.SetActive(true);
            Effect.GetComponent<CollisionHandler>().SetEffect(this);
            if (CanCast)
            {
                CanCast = false;
                SplashDamage();
            }
        }
        public override void StopCast()
        {
            Effect.SetActive(false);
            Transforms.Clear();
        }
    }
}