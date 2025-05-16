using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float torqueAmount = 5f; // 회전 힘의 크기 조절용
    private Rigidbody2D rb;

    private enum InputKey
    {
        None,
        Left,
        Right
    }

    private InputKey currentKey = InputKey.None;

    private bool applyLeft = false;
    private bool applyRight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        currentKey = Input.GetKey(KeyCode.LeftArrow) ? InputKey.Left :
            Input.GetKey(KeyCode.RightArrow) ? InputKey.Right : InputKey.None;

    }

    private void FixedUpdate()
    {
        switch (currentKey)
        {
            case InputKey.Left:
                rb.AddTorque(torqueAmount, ForceMode2D.Force);
                break;
            case InputKey.Right:
                rb.AddTorque(-torqueAmount, ForceMode2D.Force);
                break;
            default:
                break;
        }
    }
}
