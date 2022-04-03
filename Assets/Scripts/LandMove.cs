using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMove : MonoBehaviour
{
    public GameObject player;
    public float speed = 0.005f;
    public float changeTime = 12.0f;

    private float nowTime = 0f;
    private Vector2 position;
    ParrotControl parrot;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        parrot = player.GetComponent<ParrotControl>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        this.transform.Translate(new Vector2(-speed, 0));
        nowTime += Time.deltaTime;
        if (nowTime >= changeTime)
        {
            transform.position = position;
            nowTime = 0f;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null) return;
        ParrotControl parrot = collision.collider.GetComponent<ParrotControl>();
        if (parrot == null) return;
        parrot.ChangeHealth(-1);
    }
}
