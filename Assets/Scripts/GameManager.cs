using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gmInstance;
    public int difficulty = 0;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (gmInstance == null) {
            gmInstance = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
