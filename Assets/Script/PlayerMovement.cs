using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject bullet;
    private Rigidbody2D rb;
    public float speed;
    [SerializeField]private int health;
    private Vector2 moveVelocity;

    private bool hit = true;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Rotate();

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);

            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -36f, 36f),Mathf.Clamp(transform.position.y, -17f , 17f));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();

    }

    private void Rotate()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }

    private void Movement()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);


    }

    IEnumerator HitBoxOff()
    {
        hit = false;
        yield return new WaitForSeconds(1.5f);
        hit = true;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Enemy")
        {
            if(hit)
            {
                StartCoroutine(HitBoxOff());
                health--;
                Destroy(GameObject.Find("healthBar").transform.GetChild(0).gameObject);

                if(health < 0)
                {
                    Manager.gameover = true;
                }
            }
            
        }
    }



}
