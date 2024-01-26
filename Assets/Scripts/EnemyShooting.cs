using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform aim, playerPosition;
    [Min(0f)] public float shootingInterval, rotationSpeed;
    private float timeToNextShot;

    // Start is called before the first frame update
    void Start()
    {
        timeToNextShot = shootingInterval;
        if(playerPosition == null){
            playerPosition = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowards(playerPosition.position);
        timeToNextShot -= Time.deltaTime;
        if(timeToNextShot <= 0)
        {
            Shoot();
            timeToNextShot = shootingInterval;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, new Vector2(aim.position.x+1f, aim.position.y), aim.rotation);
    }

    void RotateTowards(Vector3 target)
    {
        Vector3 direction = target - aim.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        aim.rotation = Quaternion.Slerp(aim.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
