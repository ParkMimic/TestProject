using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("플레이어 기본 스텟")]
    public float speed = 2.0f;
    public float jumpForce = 2f;

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriter;

    Transform groundPos;
    Transform wallPos;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        rigid.linearVelocityX = inputX * speed;

        if (inputX == 0) return;
        if (inputX < 0)
        {
            spriter.flipX = true;
        }
        else
        {
            spriter.flipX = false;
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigid.linearVelocity = Vector2.zero;
            rigid.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
    }
}
