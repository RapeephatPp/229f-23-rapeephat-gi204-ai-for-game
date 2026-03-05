using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // ลาก Prefab สิ่งกีดขวางมาใส่ตรงนี้
    public float spawnRate = 2f;      // วินาทีที่จะเสกออกมา 1 อัน
    public float heightOffset = 3f;   // ระยะสุ่มความสูง (บน-ล่าง)
    private float timer = 0;

    void Start()
    {
        SpawnObstacle();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnObstacle();
            timer = 0;
        }
    }

    void SpawnObstacle()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // เสกสิ่งกีดขวางในตำแหน่งที่สุ่มความสูง
        Instantiate(obstaclePrefab, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}