using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    public float lifeTime = 100f;

    private float nowTime = 0;
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
        nowTime += Time.deltaTime;
        if (nowTime >= lifeTime) Destroy(gameObject);
    }
}
