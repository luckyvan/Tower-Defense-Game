using System;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public float speed = 70f;
    public float explosionRadius = 0f;

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
        transform.LookAt(target);
	}

    private void HitTarget()
    {
        GameObject effectInstance = GameObject.Instantiate(impactPrefab, transform.position, transform.rotation);

        Destroy(effectInstance, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(this.gameObject);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, explosionRadius);
        foreach(var collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
