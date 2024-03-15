using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Roguelike.Skills
{
    public class EffectsList : MonoBehaviour, IService
    {
        public List<GameObject> effects = new List<GameObject>();

        public GameObject GetEffect(string _name)
        {
            for (int i = 0; i < effects.Count; i++)
            {
                if (effects[i].name == _name)
                    return effects[i];
            }

            return null;
        }

        public List<GameObject> GetEffects(string _name)
        {
            List<GameObject> gameObjects = new List<GameObject>();
            for (int i = 0; i < effects.Count; i++)
            {
                if (effects[i].name == _name)
                    gameObjects.Add(effects[i]);
            }

            return gameObjects;
        }
    }
}

