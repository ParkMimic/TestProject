using UnityEngine;

public class Checker : MonoBehaviour
{
    public Transform groundPos;
    public Transform wallPos;
    public float groundRadius = 0.2f;
    public Vector2 wallBoxSize = new Vector2(0.5f, 1f);

    public bool isJumping = false;

    public enum State { Ground, Wall, None }

    State CheckState()
    {
        bool isGround = Physics2D.OverlapCircle(groundPos.position, groundRadius, LayerMask.NameToLayer("Ground"));
        bool isWall = Physics2D.OverlapBox(wallPos.position, wallBoxSize, LayerMask.NameToLayer("Ground"));
        if (isGround) return State.Ground;
        if (isWall) return State.Wall;

        return State.None;
    }

    private void Update()
    {
        State state = CheckState();
        PlayerMovement player = GetComponent<PlayerMovement>();
        
        switch (state)
            {
            case State.Ground: player.isJumping = false; break;
            case State.Wall: break;
            case State.None: isJumping = true; break;
        }
    }
}
