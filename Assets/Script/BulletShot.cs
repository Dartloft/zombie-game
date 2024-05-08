using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    private float speed = 5;

    private Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        dir = GameObject.Find("Dir").transform.position;    
        transform.position = GameObject.Find("FirePoint").transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<EnemyMovement>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
