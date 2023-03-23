using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Clear : MonoBehaviour
{
    public int clear = 0;

    Clearmanager clearmanager;

    [SerializeField]
    TextMeshProUGUI ui;

    [SerializeField]
    int clearNum=0;
    // Start is called before the first frame update
    void Start()
    {
        //ui = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(clear==clearNum)
        {
            clearmanager= GetComponent<Clearmanager>();
            clearmanager.Clear = true;
        }

        //ui.text = clear.ToString();
    }
}
