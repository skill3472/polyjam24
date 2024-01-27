using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager gmInstance;
    public int lastSceneIndex; // Just swap out for a normal number once the game is finished
    public int difficulty = 0;
    private AudioManager am;

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
        am = FindObjectOfType<AudioManager>();
        if(SceneManager.GetActiveScene().buildIndex == lastSceneIndex)
        {
            am.Play("Win");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
