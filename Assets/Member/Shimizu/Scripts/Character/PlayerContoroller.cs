using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FadeOutRS;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerContoroller : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 3;
    [SerializeField]
    GameObject atackCollider;
    [SerializeField]
    Clearmanager sceneManager;
    Animator anim;
    Rigidbody2D rbody;
    SpriteRenderer spren;
    BoxCollider2D boxCollider2D;
    FadeOut fadeOut;

    private bool atacking = false;
    private bool dead = false;
    private bool startMove = false;
    private Vector2 playerMove = Vector2.zero;

    //ステータス
    private int playerHP = 100;
    private void Awake()
    {
        fadeOut = GameObject.Find("FadeOutBG").GetComponent<FadeOut>();
        sceneManager = GetComponent<Clearmanager>();
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        spren = GetComponent<SpriteRenderer>();
        boxCollider2D = atackCollider.GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの速さ
        rbody.velocity = new Vector2(playerMove.x * playerSpeed , playerMove.y * playerSpeed);
        //locommotionの判定
        if(rbody.velocity.magnitude < 0.5f)
        {
            anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
        }
        else
        {
            anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
        }
        //左右向き
        if(rbody.velocity.x > 0.5f)
        {
            spren.flipX = true;
            //
            Vector2 pos = atackCollider.transform.localPosition;
            pos.x = 0.5f;
            atackCollider.transform.localPosition = pos;
        }
        if(rbody.velocity.x < -0.5f)
        {
            spren.flipX = false;
            //
            Vector2 pos = atackCollider.transform.localPosition;
            pos.x = -0.5f;
            atackCollider.transform.localPosition = pos;
        }
        //死亡チェック
        if(playerHP <= 0)
        {
            Death();
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (startMove)
        {
            playerMove = context.ReadValue<Vector2>();
        }
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed && !atacking && startMove)
        {
            atacking = true;
            Atack();
        }
    }
    public void OnSuiSide(InputAction.CallbackContext context)
    {
        if (context.performed && !dead)
        {
            Death();
        }
    }
    public void OnEvent(InputAction.CallbackContext context)
    {
        if (context.performed && !dead)
        {
            startMove = true;
            anim.SetBool("Start", true);
        }
    }
    private void Atack()
    {
        anim.SetTrigger("Atack");
        StartCoroutine(AtackCollider());
        //アタックの処理
    }
    private void Dameged()
    {
        anim.SetTrigger("Damaged");
        playerHP -= 5;
        //被ダメ処理
    }
    private void Death()
    {
        anim.SetBool("Death", true);
        anim.SetBool("Start", false);
        StartCoroutine(DeathDelay());
    }
    IEnumerator AtackCollider()
    {
        yield return new WaitForSeconds(0.3f);
        boxCollider2D.enabled = true;
        yield return new WaitForSeconds(0.4f);
        boxCollider2D.enabled = false;
        atacking = false;
    }
    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(1);
        fadeOut.FadeOutStart();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("damage?");
        if(collision.gameObject.CompareTag("EnemyAttack"))
        {
            //Debug.Log("damage!");
            Dameged();
        }
    }
}
