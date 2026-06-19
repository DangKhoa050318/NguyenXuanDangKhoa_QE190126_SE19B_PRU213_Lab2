using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float torqueAmount = 1f;
    public float normalSpeed = 20f;
    public float boostSpeed = 30f;
    public bool canMove = true;

    public Rigidbody2D rb2d;
    public SurfaceEffector2D surfaceEffector2D;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (canMove == false)
        {
            return;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        rb2d.AddTorque(-horizontalInput * torqueAmount);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = normalSpeed;
        }
    }

    public void DisableControls()
    {
        canMove = false;
        Debug.Log("Đã tắt điều khiển thành công!");
    }
}