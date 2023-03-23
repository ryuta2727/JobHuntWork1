using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSearch : MonoBehaviour
{
    public bool PlayerSearcher = false;//���G�p
    protected GameObject playerObject;
    [SerializeField] protected int enemyLayer;//�G�l�~�[�̃��C���[���
    [SerializeField] protected int playerLayer;//�G�l�~�[�̃��C���[���
    // Start is called before the first frame update
    void Start()
    {
        enemyLayer = this.gameObject.layer;
        playerObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerLayer = playerObject.gameObject.layer;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && enemyLayer ==playerLayer)
        {
            this.PlayerSearcher = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || enemyLayer != playerLayer)
        {
            this.PlayerSearcher=false;
        }
    }
}
