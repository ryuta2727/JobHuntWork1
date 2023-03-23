using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TreasureCount : MonoBehaviour
{
    TextMeshProUGUI tmp;
    private int a = 0;
    [SerializeField]
    Clear clear;
    //関のスクリプトを引っ張ってくる
    private void Awake()
    {
        tmp = this.GetComponent<TextMeshProUGUI>();
        clear.GetComponent<Clear>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        a = clear.clear;
        //Debug.Log(a);
        switch(a)
        {
            case 0:
                tmp.text = "0";
                break;
            case 1:
                tmp.text = "1";
                break;
            case 2:
                tmp.text = "2";
                break;
            case 3:
                tmp.text = "3";
                break;
            case 4:
                tmp.text = "4";
                break;
            case 5:
                tmp.text = "5";
                break;
            case 6:
                tmp.text = "6";
                break;
            case 7:
                tmp.text = "7";
                break;
            case 8:
                tmp.text = "8";
                break;
            case 9:
                tmp.text = "9";
                break;
        }
    }
}
