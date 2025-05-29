using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float torqueAmount = 5f; // ȸ�� ���� ũ�� ������
    [SerializeField] float basespeed = 50f; // �⺻ �ӵ�
    [SerializeField] float boostspeed = 80f; 
    bool isBoosting = false; // �ν�Ʈ ���� ����
    private Rigidbody2D rb;
    private SurfaceEffector2D surfaceEffector2D;

    bool isRunnig =true; // ���� ���� ������ ����

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
        surfaceEffector2D = Object.FindFirstObjectByType<SurfaceEffector2D>();
    }

    void Update()
    {
        currentKey = Input.GetKey(KeyCode.LeftArrow) ? InputKey.Left :
            Input.GetKey(KeyCode.RightArrow) ? InputKey.Right : InputKey.None;

        isBoosting = Input.GetKey(KeyCode.UpArrow);

    }

    public void GameOver()
    {
        isRunnig = false;
    }

    private void FixedUpdate()
    {
        if(!isRunnig)return;

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

        surfaceEffector2D.speed = isBoosting ? boostspeed : basespeed;
    }
}
