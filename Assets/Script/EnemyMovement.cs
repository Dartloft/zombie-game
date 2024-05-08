using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private List<Rigidbody2D> EnemyRb;

    public float speed;
    public float SpeedRotation;
    private Transform playerPos;
    private Rigidbody2D _rb;
    private Vector2 targetDireciton;
    [SerializeField] private int health;
    private float repelRange = 0.5f;


    // Start is called before the first frame update
    private void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        _rb = GetComponent<Rigidbody2D>();

        if(EnemyRb == null)
        {
            EnemyRb = new List<Rigidbody2D>();
        }

        EnemyRb.Add(_rb);
    }

    void OnDestroy()
    {
        EnemyRb.Remove(_rb);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(transform.position, playerPos.position) > 0.3f)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        }

        Vector3 direction = playerPos.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _rb.rotation = angle;
    }

    private void FixedUpdate()
    {
        Vector2 repelForce = Vector2.zero;
        foreach(Rigidbody2D enemy in EnemyRb)
        {
            if(enemy == _rb)
            {
                continue;
            }
            if (Vector2.Distance(enemy.position, _rb.position) <= repelRange)
            {
                Vector2 repelDir = (_rb.position - enemy.position).normalized;
                repelForce += repelDir;
            }
        }

    }


}
