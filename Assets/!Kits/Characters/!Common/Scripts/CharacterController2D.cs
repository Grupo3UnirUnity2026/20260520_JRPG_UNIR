using UnityEngine;

public class CharacterController2D : MonoBehaviour, IVisible
{
    [SerializeField] float movementSpeed = 3f;

    Rigidbody2D rb2D;
    Animator animator;

    [SerializeField] IVisible.Side side = IVisible.Side.Neutral;

    private void Awake()
    {
        this.rb2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.rb2D.linearVelocity = rawMove * movementSpeed;
    }

    Vector2 rawMove = Vector2.zero;
    public void SetRawMove(Vector2 rawMove)
    {
        this.rawMove = rawMove;
        this.animator.SetFloat("HorizontalVelocity", this.rawMove.x);
        this.animator.SetFloat("VerticalVelocity", this.rawMove.y);
    }

    public IVisible.Side GetSide()
    {
        return this.side;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
