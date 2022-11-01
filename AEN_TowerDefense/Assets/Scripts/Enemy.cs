using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    public float speed = 10f;
    public float strength = 100f;

    [Header("Unity Setup Fields")]
    public GameObject destructionEffect;
    private Transform target;
    private int waypointIndex = 0;

    // On start, set the target for the first waypoint
    void Start()
    {
        target  = Waypoints.points[0];
    }

    // On every update, calculate the movement vector
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    public void GetDamage(float damage)
    {
        strength -= damage;
        if (strength<= 0f)
        {
            GameObject effect = (GameObject)Instantiate(destructionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(effect, 5f);
            PlayerStats.money += 50;
        }
    }

    void GetNextWaypoint()
    {
        // continue increasing the index until the last waypoint
        if(waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
        }
        else
        {
            waypointIndex++;
            target = Waypoints.points[waypointIndex];
        }
    }

    void EndPath()
    {
        if(PlayerStats.lives > 0)
        {
            PlayerStats.lives --;
        }
        Destroy(gameObject);
    }
}
