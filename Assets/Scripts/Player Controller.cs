using UnityEngine;

public class BirdFlapController : MonoBehaviour
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Game Over!");
    }
}