using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flip.Module;
public class GlobalWorldOffSet : BaseSingletonWithMono<GlobalWorldOffSet>
{
    public Vector3 WorldOffSet => worldOffSet;
    [SerializeField] private Transform mainWorld;
    [SerializeField] private Transform offWorld;
    private Vector3 worldOffSet;
    private void Start()
    {
        worldOffSet = mainWorld.transform.position - offWorld.transform.position;
    }
}
