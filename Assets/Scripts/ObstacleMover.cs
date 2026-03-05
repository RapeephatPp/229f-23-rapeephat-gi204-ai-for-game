using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 4f;        // ความเร็วที่สิ่งของพุ่งเข้าหาเรา
    public float deadZone = -15f;   // จุดที่ถ้าเลยไปแล้วจะถูกทำลาย (พ้นจอซ้าย)

    void Update()
    {
        // เคลื่อนที่ไปทางซ้าย
        transform.position += Vector3.left * speed * Time.deltaTime;

        // ถ้าพ้นหน้าจอไปแล้ว ให้ทำลายตัวเองเพื่อประหยัด Memory
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}