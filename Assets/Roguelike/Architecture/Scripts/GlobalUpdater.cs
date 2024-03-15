using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Roguelike.Architecture.Scripts;
using Roguelike.Units;
using UnityEngine;

public class GlobalUpdater : MonoBehaviour
{
    public static List<IUpdateble> updatebles = new List<IUpdateble>();
    private void Update()
    {
        if(updatebles.Count > 0)
        {
            for (int i = 0; i < updatebles.Count; i++)
            {
                updatebles[i].Updates();
            }
        }
    }
    private void FixedUpdate()
    {
        if(updatebles.Count > 0)
        {
            for (int i = 0; i < updatebles.Count; i++)
            {
                updatebles[i].FixedUpdates();
            }
        }
    }
}
