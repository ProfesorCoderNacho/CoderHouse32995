using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SaveData
{
    public Vector3 LastCharacterPosition;
    public bool CanSprint;
    public float Health;
    public string CharacterName;
    public List<SuperPower> Superpowers;
    public LevelSaveData LevelSaveData;
}