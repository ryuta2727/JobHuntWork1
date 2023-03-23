using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualTextContoroller : MonoBehaviour
{
    [SerializeField]
    Text manualRightClick;
    [SerializeField]
    private bool aTo0 = true;
    [SerializeField]
    private bool aTo255 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
       if(aTo0)
       {
            aTo0 = false;
            StartCoroutine(ColorATo0());
       }
       else if(aTo255)
       {
            aTo255 = false;
            StartCoroutine(ColorATo255());
       }
    }
    IEnumerator ColorATo0()
    {
        for (int i = 0; i < 120; i++)
        {
            manualRightClick.color = manualRightClick.color - new Color32(0, 0, 0, 2);
            yield return new WaitForSeconds(0.01f);
        }
        Debug.Log("b");
        aTo255 = true;
    }
    IEnumerator ColorATo255()
    {
        Debug.Log("a");
        for (int i = 0; i < 120; i++)
        {
            manualRightClick.color = manualRightClick.color + new Color32(0, 0, 0, 2);
            yield return new WaitForSeconds(0.01f);
        }
        aTo0 = true;
    }
    public void RightClickT()
    {
        this.gameObject.SetActive(false);
    }
}
