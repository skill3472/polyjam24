using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public GameObject particlePrefab;
    private AudioManager am;

    void Start(){
        am = FindObjectOfType<AudioManager>();
    }
    public void Die(){
        Debug.Log("Goodbye...");
        GameObject x = Instantiate(particlePrefab, transform.position, transform.rotation);
        am.Play("ParasiteDeath");
        Destroy(x, 3f);
        Destroy(gameObject);
    }
}
