using System;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public float speed = 70f;

    public GameObject impactPrefab;

    public void Seek (Transform _target)
    {
        target = _target;
    }
	
	void Update ()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
	}

    private void HitTarget()
    {
        GameObject effectInstance = GameObject.Instantiate(impactPrefab, transform.position, transform.rotation);

        Destroy(effectInstance, 2f);

        Destroy(this.gameObject);
    }
}
