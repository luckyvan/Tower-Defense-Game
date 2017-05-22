using System;
using UnityEngine;

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

    public GameObject buildEffect;
    public NodeUI nodeUI;
    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public bool CanBuild
    {
        get
        {
             return turretToBuild != null;
        }
    }

    public bool HasMoney
    {
        get
        {
            return PlayerStats.Money >= turretToBuild.cost;
        }
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;

        DeselectNode();
    }

    public void SelectNode (Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
}
