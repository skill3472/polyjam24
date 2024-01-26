using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public void Die(){
        Debug.Log("Goodbye...");
        Destroy(gameObject);
    }
}
