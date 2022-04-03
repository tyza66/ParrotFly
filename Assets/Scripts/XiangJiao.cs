using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XiangJiao : MonoBehaviour
{
    public float speed = 0.05f;
    public float lifeTime = 5f;

    private float nowTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        this.transform.Translate(new Vector2(-speed, 0));
        nowTime += Time.deltaTime;
        if (nowTime >= lifeTime) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        ParrotControl parrot = collision.GetComponent<ParrotControl>();
        if (parrot == null) return;
        parrot.ChangeHealth(3);
        parrot.ChangeScore(10);
        Destroy(this.gameObject);
    }
}
