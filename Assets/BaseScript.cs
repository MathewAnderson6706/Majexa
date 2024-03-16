using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    public GameObject[] Hearts = new GameObject[3];
    int Health = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") 
        {
            Hearts[Health - 1].SetActive(false);
            Health--;
            if (Health <= 0) { Application.Quit(); UnityEditor.EditorApplication.isPlaying = false; }
        }
    }
}
