using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    [SerializeField]
    GameObject script,open;

    Clear c;
    // Start is called before the first frame update
    void Start()
    {
        c = script.GetComponent<Clear>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerAtack"))
        {
            c.clear++;
            this.gameObject.SetActive(false);
            var Open = Instantiate(open, transform.position, Quaternion.identity);
            Open.gameObject.layer = this.gameObject.layer;
            Open.gameObject.GetComponent<SpriteRenderer>().sortingLayerID =
                this.gameObject.GetComponent<SpriteRenderer>().sortingLayerID;
            Destroy(this);
        }
    }
}
