using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform[] lanes; // SpawnPoint ที่กำหนด
    private int currentLane = 0;  // Lane ปัจจุบัน

    void Start()
    {
        // ตั้งค่าตำแหน่งเริ่มต้นเป็น Lane แรก
        if (lanes.Length > 0)
        {
            transform.position = lanes[currentLane].position;
        }
    }

    void Update()
    {
        // เปลี่ยน Lane ด้วยปุ่ม W / S
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveLane(-1); // ขึ้น Lane
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveLane(1); // ลง Lane
        }
    }

    void MoveLane(int direction)
    {
        int newLane = currentLane + direction;
        if (newLane >= 0 && newLane < lanes.Length)  // ตรวจสอบว่าอยู่ในช่วงที่กำหนด
        {
            currentLane = newLane;
            transform.position = new Vector3(transform.position.x, lanes[currentLane].position.y, lanes[currentLane].position.z);
        }
    }
}


