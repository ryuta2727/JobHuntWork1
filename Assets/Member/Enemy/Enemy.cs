using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    //アニメーター
    public Animator Anim;
    [SerializeField]private float Speed = 2;
    [SerializeField] private int _chargeRange = 0;//攻撃の範囲
    [SerializeField] private float _recastTime = 3.0f;//攻撃の周期
    [SerializeField] private GameObject chargeObject;//突進の当たり判定
    [SerializeField] private PlayerSearch playersearch;//突進の当たり判定
    private bool search=false;
    private Vector3 defaultPos;//エネミーの初期座標

    private GameObject playerObject;
    private float _playerRange;    //プレイヤーとの距離
    private Vector3 playerPos;//プレイヤーの座標
    private bool trigger=false;
    public float m_attenuation = 0.5f;

    private Vector3 m_velocity;
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        chargeObject.SetActive(false);//攻撃の当たり判定
        playerObject = GameObject.FindWithTag("Player");
        this.defaultPos =this.transform.position;
        playersearch.GetComponent<PlayerSearch>();

    }

    // Update is called once per frame
    void Update()
    {
        
        playerPos = playerObject.transform.position;
        this._playerRange = Vector2.Distance(playerObject.transform.position, this.transform.position);
 
        if(_playerRange<_chargeRange)
        {
            StartCoroutine(Charge());
        }
        else
        {
            enemyMove();
        }
       
    }
    public void EnmeyDamaged()
    {
        this.gameObject.SetActive(false);
    }
    public IEnumerator Charge()
    {
        if(!trigger)
        {
            trigger = true;
            //アニメーションを呼び出す
            Anim.SetBool("Walk", false);
            Anim.SetTrigger("Attack");
            //オブジェクトを有効化
            chargeObject.SetActive(true);//当たり判定の有効化
            yield return new WaitForSeconds(0.1f);
            chargeObject.SetActive(false);
            yield return new WaitForSeconds(_recastTime);
            
            trigger = false;
        } 
    }

    private void enemyMove()
    {
        if (playersearch.PlayerSearcher&&trigger==false&&!trigger)
        {
            //プレイヤーに向かって移動
            Anim.SetBool("Walk", true);
            this.m_velocity += (playerPos - this.transform.position) * Speed;
            this.m_velocity *= m_attenuation;
            this.transform.position += m_velocity *= Time.deltaTime;
            if (this.transform.position.x > playerPos.x)
            {
                this.spriteRenderer.flipX = true;
            }
            else
            {
                this.spriteRenderer.flipX = false;
            }
        }
        else if(!playersearch.PlayerSearcher && trigger == true &&!trigger)
        {
            Debug.Log("いどう");
            //プレイヤーに向かって移動
            Anim.SetBool("Walk", true);
            this.m_velocity += (defaultPos - this.transform.position) * Speed;
            this.m_velocity *= m_attenuation;
            this.transform.position += m_velocity *= Time.deltaTime;
            if (this.transform.position.x > defaultPos.x)
            {
                this.spriteRenderer.flipX = true;
            }
            else
            {
                this.spriteRenderer.flipX = false;
            }
            if(this.transform.position==defaultPos)
            {
                Anim.SetBool("Walk", false);
            }

        }
    }
}
