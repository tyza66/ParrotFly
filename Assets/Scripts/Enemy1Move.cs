using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
    public float lifeTime = 100f;
    public float speed = 0.5f;

    private float nowTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Translate(new Vector2(-speed, 0));
        nowTime += Time.deltaTime;
        if (nowTime >= lifeTime) Destroy(gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == null) return;
        ParrotControl parrot = collision.GetComponent<ParrotControl>();
        if (parrot == null) return;
        parrot.ChangeScore(1);
    }
}
