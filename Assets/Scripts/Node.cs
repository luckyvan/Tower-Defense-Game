using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Color startColor;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Vector3 positionOffset = new Vector3(0, 0.5f, 0);

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;
        
        if (turret != null)
        {
            Debug.Log("Can't Build there! -- TODO: Display ON Screen");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
