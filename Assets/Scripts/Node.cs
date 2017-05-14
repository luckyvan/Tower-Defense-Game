using UnityEngine;

public class Node : MonoBehaviour {

    public Color hoverColor;
    private Color startColor;
    private GameObject turret;

    private Renderer rend;
    private Vector3 positionOffset = new Vector3(0, 0.5f, 0);

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't Build there! -- TODO: Display ON Screen");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
