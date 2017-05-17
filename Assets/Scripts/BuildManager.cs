﻿using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More Than 1 BuildManager in Scene");
        }
        instance = this;
    }

    private TurretBlueprint turretToBuild;

    public bool CanBuild
    {
        get
        {
             return turretToBuild != null;
        }
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), node.transform.rotation);
        node.turret = turret;

        Debug.Log("Money Left: " + PlayerStats.Money);
    }
}
