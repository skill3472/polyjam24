using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public GameObject particlePrefab;
    public void Die(){
        Debug.Log("Goodbye...");
        GameObject x = Instantiate(particlePrefab, transform.position, transform.rotation);
        Destroy(x, 3f);
        Destroy(gameObject);
    }
}
