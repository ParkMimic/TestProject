using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("플레이어 조작 세팅")]
    public float moveSpeed = 5f;
    public float jumpPower = 5f;

    bool isJumping = false;
    bool isMoving = false;

    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Animator anim;
    Checker checker;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        checker = GetComponent<Checker>();
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        
        Move(inputX);
        Jump();
        

        if (!Input.GetButton("Horizontal")) return;
        Flip(inputX);
    }

    void Move(float inputX)
    {
        if (!isJumping)
        {
            if (Input.GetButton("Horizontal"))
                anim.SetBool("isMove", true);

            if (Input.GetButtonUp("Horizontal"))
            {
                anim.SetBool("isMove", false);
                rigid.linearVelocityX = 0;
            }
        }

        rigid.linearVelocityX = 0;
    }

    /* 플레이어 움직였을 때 뒤집을 함수
     * 반대로 움직이면 spriter 의 flip 을 작동할 것.
     */
    void Flip(float inputX)
    {
        if (inputX > 0)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
    }

    void Jump()
    {
        /* 
         * 점프 관련 로직 구현
         * Jump 키에 할당된 버튼으로 점프.
         * AddForce 를 사용하여 JumpPower 만큼 뛰어오를 것임.
         */
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            anim.SetBool("isJump", true);
            anim.SetBool("isMove", false);

            rigid.linearVelocity = Vector2.zero;
            rigid.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }

    public void OnGround()
    {
        isJumping = false;
        anim.SetBool("isJump", false);
    }
}
