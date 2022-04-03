using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrotControl : MonoBehaviour
{
    public int maxHealth = 3;
    public float fly_Force = 180.0f;
    public float fly_StayTime = 0.2f;
    public float superTime = 0.5f;
    public GameObject lifesText;
    public GameObject scoreText;
    public GameObject enemyMaker;
    public GameObject Menu;
    public GameObject BeginText;
    public GameObject InfoText;

    private new Rigidbody2D rigidbody2D;
    private int nowHealth = 3;
    private float now_Fly_Stay = 0.0f;
    private Vector2 reLive;
    private int myscore = 0;
    private TMPro.TextMeshProUGUI health;
    private TMPro.TextMeshProUGUI scoreNum;
    private TMPro.TextMeshProUGUI endScoreNum;
    private float gravityScale;
    private EnemyMaker enemyMakerOK;
    private Animator animator;
    private float nowSuperTime = 0;

    public bool begin = false;
    public bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        gravityScale = rigidbody2D.gravityScale;
        rigidbody2D.gravityScale = 0;
        reLive = transform.position;
        health = lifesText.GetComponent<TMPro.TextMeshProUGUI>();
        scoreNum = scoreText.GetComponent<TMPro.TextMeshProUGUI>();
        endScoreNum = Menu.GetComponentsInChildren<TMPro.TextMeshProUGUI>()[1];
        enemyMakerOK = enemyMaker.GetComponent<EnemyMaker>();
        animator = GetComponent<Animator>();
        Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        now_Fly_Stay -= Time.deltaTime;
        if (now_Fly_Stay < -1000) now_Fly_Stay = 0.0f;
        if (Input.anyKeyDown && now_Fly_Stay <= 0 && dead != true)
        {
            Fly(Vector2.up, fly_Force);
            begin = true;
        }
        if (begin == true)
        {
            rigidbody2D.gravityScale = gravityScale;
            enemyMakerOK.MakeStart();
            BeginText.SetActive(false);
            InfoText.SetActive(false);
        }
        else
        {
            if (dead) rigidbody2D.gravityScale = 99;
            else rigidbody2D.gravityScale = 0;
        }
        if (nowSuperTime > 0)
        {
            nowSuperTime -= Time.deltaTime;
            animator.SetBool("Super", true);
        }
        else animator.SetBool("Super", false);

    }
    public void Fly(Vector2 direction, float force)
    {
        rigidbody2D.AddForce(direction * force);
        now_Fly_Stay = fly_StayTime;
    }
    public void ChangeHealth(int num)
    {
        if (num < 0)
        {
            if (nowSuperTime > 0)
            {
                return;
            }
            if (nowHealth <= 1)
            {
                begin = false;
                dead = true;
                animator.SetBool("Dead", true);
                health.text = "X0";
                Menu.SetActive(true);
                endScoreNum.text = "" + myscore;
                return;
            }
            nowHealth += num;
            health.text = "X" + nowHealth;
            this.transform.position = reLive;
            nowSuperTime = superTime;
        }
        else if (num > 0)
        {
            if (nowHealth == maxHealth)
            {
                return;
            }
            if (nowHealth + num >= maxHealth) nowHealth = maxHealth;
            else nowHealth += num;
            health.text = "X" + nowHealth;
        }
        Debug.Log("ÑªÁ¿" + nowHealth);
    }
    public void ChangeScore(int num)
    {
        myscore += num;
        scoreNum.text = "" + myscore;
    }
    public int GetScore()
    {
        return myscore;
    }
}
