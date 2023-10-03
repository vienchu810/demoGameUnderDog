using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
   public float speed = 5f; // Tốc độ di chuyển của enemy
    public Transform leftPoint; // Điểm bên trái của BoxCollider2D
    public Transform rightPoint; // Điểm bên phải của BoxCollider2D
    public SpriteRenderer spriteRenderer; // Tham chiếu đến SpriteRenderer của enemy

    private bool movingRight = true; // Biến kiểm tra hướng di chuyển

    void Start()
    {
        // Lấy tham chiếu đến SpriteRenderer nếu chưa có
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        // Di chuyển enemy theo hướng và tốc độ xác định
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        // Kiểm tra nếu enemy chạm vào điểm bên trái hoặc bên phải của BoxCollider2D
        if (transform.position.x >= rightPoint.position.x)
        {
            movingRight = false;
            FlipSprite();
        }
        else if (transform.position.x <= leftPoint.position.x)
        {
            movingRight = true;
            FlipSprite();
        }
    }

    // Phương thức để đảo ngược hình ảnh của enemy
    void FlipSprite()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1f; // Đảo ngược giá trị trên trục x
        transform.localScale = newScale;
    }

}
