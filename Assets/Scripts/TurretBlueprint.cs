// The Serializable attribute lets you embed a class with sub properties in the inspector.
using UnityEngine;

[System.Serializable]
public class TurretBlueprint {

    public GameObject prefab;
    public GameObject upgradedPrefab
        ;

    public int cost;
    public int upgradeCost;
}
