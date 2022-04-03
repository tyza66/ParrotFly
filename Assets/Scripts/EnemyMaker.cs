using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    public GameObject player;
    public float stayTime = 2.0f;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject huaSheng;
    public GameObject xiangJiao;

    private float nowTime = 0;
    bool run = false;
    float y = 1.11243f;
    ParrotControl parrot;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        parrot = player.GetComponent<ParrotControl>();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        score = parrot.GetScore();
        if (run)
        {
            nowTime += Time.deltaTime;
            if (nowTime >= stayTime && parrot.begin == true)
            {
                if (score <= 30)
                {
                    int h = Random.Range(0, 10);
                    if (h <= 8) MakeEnemy1();
                    else MakeEnemy3();
                    if (h == 3) MakeHuaSheng();
                }
                else if (score <= 60)
                {
                    MakeEnemy1_1();
                }
                else if (score <= 90)
                {
                    MakeEnemy1_2();
                    int h = Random.Range(0, 10);
                    if (h <= 2) MakeHuaSheng();
                }
                else if (score <= 120)
                {
                    stayTime = 1.9f;
                    int h = Random.Range(0, 10);
                    if (h <= 8) MakeEnemy1();
                    else MakeEnemy3();
                }
                else if (score <= 130)
                {
                    MakeEnemy1_2();
                    int h = Random.Range(0, 10);
                    if (h <= 2) MakeHuaSheng();
                    if (h == 10) MakeXiangJiao();
                }
                else if (score <= 150)
                {
                    stayTime = 1.8f;
                    MakeEnemy1_1();
                }
                else if (score < 180)
                {
                    MakeEnemy1_2();
                    int h = Random.Range(0, 10);
                    if (h <= 1) MakeXiangJiao();
                    if (h > 8) MakeHuaSheng();
                }
                else if (score < 189)
                {
                    stayTime = 3;
                    MakeEnemy2();
                }
                else if (score <= 200)
                {
                    stayTime = 2.0f;
                    int h = Random.Range(0, 10);
                    MakeEnemy1_1();
                    if (h <= 2) MakeXiangJiao();
                }
                else if (score <= 220)
                {
                    MakeEnemy3();
                }
                else if (score <= 250)
                {
                    int h = Random.Range(0, 10);
                    if (h <= 8) MakeEnemy1();
                    else MakeEnemy3();
                    if (score == 250) MakeEnemy4();
                }
                else if (score <= 280)
                {
                    MakeEnemy1_2();
                    int h = Random.Range(0, 10);
                    if (h <= 1) MakeXiangJiao();
                    if (h > 8) MakeHuaSheng();
                }
                else if (score <= 300)
                {
                    stayTime = 1.9f;
                    MakeEnemy1_1();
                    int h = Random.Range(0, 10);
                    if (h <= 1) MakeHuaSheng();
                    if (h == 10) MakeXiangJiao();
                }
                else if (score <= 400)
                {
                    int h = Random.Range(0, 10);
                    if (h <= 8) MakeEnemy1();
                    else MakeEnemy3();
                    if (h <= 2) MakeHuaSheng();
                    if (h == 10) MakeXiangJiao();
                    if (score == 400)
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            MakeHuaSheng();
                        }
                    }
                }
                else if (score <= 500)
                {
                    stayTime = 1.8f;
                    int h = Random.Range(0, 10);
                    if (h <= 8) MakeEnemy1_2();
                    else MakeEnemy3();
                    if (h <= 1) MakeHuaSheng();
                    if (h == 10) MakeXiangJiao();
                }
                else if (score <= 600)
                {
                    stayTime = 1.8f;
                    int h = Random.Range(0, 10);
                    if (h <= 8) MakeEnemy1();
                    else MakeEnemy3();
                    if (h <= 1) MakeHuaSheng();
                    if (h == 10) MakeXiangJiao();
                    if (score == 520)
                    {
                        for (int i = 1; i <= 20; i++)
                        {
                            MakeXiangJiao();
                        }
                    }
                }
                else if (score <= 612)
                {
                    stayTime = 3;
                    MakeEnemy2();
                }
                else if (score <= 700)
                {
                    stayTime = 2f;
                    int h = Random.Range(0, 10);
                    if (h <= 8) MakeEnemy1();
                    else MakeEnemy3();
                    if (h <= 1) MakeHuaSheng();
                    if (h == 10) MakeXiangJiao();
                }
                else if (score <= 2500)
                {
                    int h = Random.Range(0, 10);
                    if (h <= 8) MakeEnemy1();
                    else MakeEnemy3();
                    if (h <= 1) MakeHuaSheng();
                    if (h == 10) MakeXiangJiao();
                }
                else if (score <= 3000)
                {
                    int h = Random.Range(0, 10);
                    if (h <= 8) MakeEnemy1();
                    else MakeEnemy3();
                    if (h <= 1) MakeHuaSheng();
                    if (h >= 9) MakeXiangJiao();
                }
                else
                {
                    int h = Random.Range(0, 10);
                    if (h <= 7) MakeEnemy1();
                    else MakeEnemy3();
                }
                nowTime = 0;
            }
        }
    }
    public void MakeStart()
    {
        run = true;
    }
    public void MakeStop()
    {
        run = false;
    }
    public void MakeEnemy1()
    {
        if (y < -1.68f) y = -1.68f;
        if (y > 4.55f) y = 4.55f;
        float change = Random.Range(-1.5f, 1.5f);
        if (y + change >= -1.68f && y + change <= 4.55f)
        {
            y = y + change;
        }
        Instantiate(enemy1, new Vector3(5.21f, y, -10f), Quaternion.identity);
    }
    public void MakeEnemy1_1()
    {
        if (y < -1.68f) y = -1.68f;
        if (y > 4.55f) y = 4.55f;
        float change = Random.Range(-1.5f, 1.5f);
        if (y + change >= -1.68f && y + change <= 4.55f)
        {
            y = y + change;
        }
        GameObject e1 = Instantiate(enemy1, new Vector3(5.21f, y, -10f), Quaternion.identity);
        Enemy1Move newEnemy = e1.GetComponent<Enemy1Move>();
        newEnemy.speed = 0.06f;
    }
    public void MakeEnemy1_2()
    {
        if (y < -1.68f) y = -1.68f;
        if (y > 4.55f) y = 4.55f;
        float change = Random.Range(-1.5f, 1.5f);
        if (y + change >= -1.68f && y + change <= 4.55f)
        {
            y = y + change;
        }
        GameObject e1 = Instantiate(enemy1, new Vector3(5.21f, y, -10f), Quaternion.identity);
        Enemy1Move newEnemy = e1.GetComponent<Enemy1Move>();
        newEnemy.speed = 0.07f;
    }
    public void MakeEnemy2()
    {
        float change = Random.Range(-0.5f, 0.5f);
        if (y < -2.73f) y = -2.73f;
        if (y > 2.25f) y = 2.25f;
        if (y + change >= -2.73f && y + change <= 2.25f)
        {
            y = y + change;
        }
        Instantiate(enemy2, new Vector3(5.21f, y, -0.1f), Quaternion.identity);
    }
    public void MakeEnemy3()
    {
        if (y < -2.42f) y = -2.42f;
        if (y > 3.22f) y = 3.22f;
        float change = Random.Range(-1.5f, 1.5f);
        if (y + change >= -2.42f && y + change <= 3.22f)
        {
            y = y + change;
        }
        Instantiate(enemy3, new Vector3(5.21f, y, -0.1f), Quaternion.identity);
    }

    public void MakeHuaSheng()
    {
        float h = Random.Range(0f, 4.8f);
        float z = Random.Range(0f, 2.73f);
        Instantiate(huaSheng, new Vector3(z, h, -1f), Quaternion.identity);
    }

    public void MakeXiangJiao()
    {
        float h = Random.Range(0f, 4.8f);
        float z = Random.Range(0f, 2.73f);
        Instantiate(xiangJiao, new Vector3(z, h, -1f), Quaternion.identity);
    }

    public void MakeEnemy4()
    {
        Instantiate(enemy4, new Vector3(5.74f, 1.424956f, 2f), Quaternion.identity);
    }
}
