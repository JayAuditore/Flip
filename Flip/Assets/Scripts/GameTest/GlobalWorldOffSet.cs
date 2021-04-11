using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flip.Module;
public class GlobalWorldOffSet : BaseSingletonWithMono<GlobalWorldOffSet>
{
    public Vector3 WorldOffSet => worldOffSet;
    [SerializeField] private Transform frontWorld;
    [SerializeField] private Transform backWorld;
    private Vector3 worldOffSet;
    private void Start()
    {
        worldOffSet = frontWorld.transform.position - backWorld.transform.position;
    }
}
