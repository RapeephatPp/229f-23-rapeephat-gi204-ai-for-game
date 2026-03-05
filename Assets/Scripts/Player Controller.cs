using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;      // ความเร็วในการบิน
    public float tiltAmount = 15f;    // องศาการเอียงตัวเวลาบิน

    void Update()
    {
        // 1. รับค่า Input จากแป้นพิมพ์ (WASD หรือปุ่มลูกศร)
        float moveX = Input.GetAxis("Horizontal"); // ซ้าย-ขวา
        float moveY = Input.GetAxis("Vertical");   // ขึ้น-ลง

        // 2. คำนวณทิศทางการเคลื่อนที่
        Vector3 moveDirection = new Vector3(moveX, moveY, 0);
        
        // 3. สั่งให้ตัวละครเคลื่อนที่
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // 4. (แถม) เพิ่มการเอียงตัวเล็กน้อยให้ดูมีชีวิตชีวา (AI Suggested)
        float tilt = -moveX * tiltAmount;
        transform.rotation = Quaternion.Euler(0, 0, tilt);

        // 5. พลิกหน้าตัวละครตามทิศทางที่ไป
        if (moveX > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveX < 0) transform.localScale = new Vector3(-1, 1, 1);
    }
}