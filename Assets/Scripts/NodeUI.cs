using UnityEngine;

public class NodeUI : MonoBehaviour {
    public GameObject ui;
    private Node target;

    public void SetTarget(Node _target)
    {
        ui.SetActive(true);
        target = _target;
        transform.position = target.GetBuildPosition();
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
