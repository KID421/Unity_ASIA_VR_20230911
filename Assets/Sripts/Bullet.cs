using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 子彈碰到物件時刪除
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
