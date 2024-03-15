using Roguelike.Skills;
using UnityEngine;

namespace Roguelike.Units.CreateEnemy
{
    public class FireFactory : AbstractFactory
    {
        public override Unit CreateSkeleton()
        {
            var enemy = Resources.Load("SkeletonFire");
            GameObject go = Object.Instantiate(enemy) as GameObject;
            Unit unit = go.AddComponent<Unit>();
            unit.Init(new FireSkeleton());
            unit.GetBehaviour().type = ElementType.Fire;
            return unit;
        }
        public override Unit CreateSpider()
        {
            return null;
        }
    }
}