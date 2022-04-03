using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Part : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision == null) return;
        ParrotControl parrot = collision.collider.GetComponent<ParrotControl>();
        if (parrot == null) return;
        parrot.ChangeHealth(-1);
        Destroy(this.gameObject);
    }
}
