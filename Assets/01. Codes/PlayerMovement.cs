using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("플레이어 기본 세팅")]
    public float moveSpeed = 5f;

    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        
        Movement(inputX);

        if (!Input.GetButton("Horizontal")) return;
        Flip(inputX);
    }

    void Movement(float inputX)
    {
        rigid.linearVelocityX = inputX * moveSpeed;

        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.linearVelocityX = 0;
        }
    }

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
}
