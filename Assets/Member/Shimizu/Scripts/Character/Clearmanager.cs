using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clearmanager : MonoBehaviour
{
    [SerializeField]
    private string _scenename2;

    [SerializeField]
    private string _scenename3;

    public bool Clear = false;

    public static bool Gameover = false;
    private void Start()
    {
        Clear = false;
        Gameover = false;
    }
    void Update()
    {
        if(Clear == true)
        {
            SceneManager.LoadScene(_scenename2);
        }

        if(Gameover == true)
        {
            SceneManager.LoadScene(_scenename3);
        }

    }
}
