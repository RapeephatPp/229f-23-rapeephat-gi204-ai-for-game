using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float flapForce = 5f; 
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }
    }

    void Flap()
    {
        // รีเซ็ตความเร็วแนวดิ่งก่อน เพื่อให้กระโดดได้แรงเท่ากันทุกครั้ง
        rb.linearVelocity = Vector2.up * flapForce;
        
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    // ฟังก์ชันตรวจสอบเมื่อนกตกแมพ หรือชนสิ่งกีดขวาง
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // เมื่อชนกับอะไรก็ตาม (ก้อนเมฆ หรือ สิ่งกีดขวาง)
        Debug.Log("Game Over! Time Stopped.");
        
        // สั่งให้เวลาในเกมกลายเป็น 0 (หยุดนิ่ง)
        Time.timeScale = 0f; 
    }
}