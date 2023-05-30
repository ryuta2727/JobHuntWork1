using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class EscGaming : MonoBehaviour
{
    [SerializeField]
    private string _scenename;

    private bool canNextScene = true;
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed && canNextScene)
        {
            SceneManager.LoadScene(_scenename);
        }
    }
    public void OnEsc(InputAction.CallbackContext context)
    {
        canNextScene = false;
        foreach (Transform child in transform.transform)
        {
            child.gameObject.SetActive(true);
        }
    }
    public void OnCloseButton()
    {
        canNextScene = true;
        foreach (Transform child in transform.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    public void OnCloseGamaing()
    {
        Application.Quit();
    }
}
