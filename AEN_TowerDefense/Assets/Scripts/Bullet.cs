using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Attributes")]
    public float speed = 70f;
    public float damage = 10f;

    [Header("Unity Setup Fields")]
    private Transform target;

    public void Seek(Transform _target)
    {
        target = _target;
    }
    

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceOfTheMovement = speed * Time.deltaTime;

        if(dir.magnitude <= distanceOfTheMovement)
        {
            // This means we hit to the target, the bullet should disappear
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceOfTheMovement, Space.World);
    }

    void HitTarget()
    {
        Enemy enemy = target.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.GetDamage(damage);
        }
        Destroy(gameObject);
    }
}
