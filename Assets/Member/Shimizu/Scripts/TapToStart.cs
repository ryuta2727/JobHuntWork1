using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class TapToStart : MonoBehaviour
{
    [SerializeField]
   private string _scenename;
 
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene(_scenename);
        }
    }
}
