using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] lanes; // จุดเลนที่กำหนด
    private int currentLane = 0;  // เลนปัจจุบัน
    public float changeLaneInterval = 2.0f; // เปลี่ยนเลนทุกๆ กี่วินาที

    void Start()
    {
        // ตั้งค่าตำแหน่งเริ่มต้นเป็น Lane แรก
        if (lanes.Length > 0)
        {
            transform.position = lanes[currentLane].position;
        }

        // เริ่มให้เปลี่ยนเลนแบบสุ่มทุกๆ X วินาที
        InvokeRepeating(nameof(RandomMoveLane), changeLaneInterval, changeLaneInterval);
    }

    void RandomMoveLane()
    {
        if (lanes.Length <= 1) return; // ถ้ามีแค่เลนเดียวไม่ต้องเปลี่ยน

        int newLane;
        do
        {
            newLane = Random.Range(0, lanes.Length); // สุ่มเลนใหม่
        } while (newLane == currentLane); // ห้ามสุ่มตำแหน่งเดิมซ้ำ

        currentLane = newLane;
        transform.position = new Vector3(transform.position.x, lanes[currentLane].position.y, lanes[currentLane].position.z);
    }
}
