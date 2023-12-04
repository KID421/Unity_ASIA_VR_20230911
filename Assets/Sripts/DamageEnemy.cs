using UnityEngine;

// 腳本名稱 : 繼承名稱
public class DamageEnemy : DamageBasic
{
    [Header("爆炸特效")]
    public GameObject prefabExplosion;

    private string bulletName = "子彈";

    // 碰撞事件：兩個物件碰撞開始時執行一次
    // 條件：
    // 1. 兩個物件都要有碰撞器 Collider，不限形狀
    // 2. 其中一個物件要有剛體 Rigidbody
    private void OnCollisionEnter(Collision collision)
    {
        // 如果 碰到物件的名稱 包含 子彈 兩個字 就受傷
        if (collision.gameObject.name.Contains(bulletName))
        {
            Damage(20);
        }
    }

    // override 加上空格
    protected override void Dead()
    {
        // 原本父類別的內容
        base.Dead();
        GameObject temp = Instantiate(prefabExplosion, transform.position + Vector3.up * 1.5f, Quaternion.identity);

        // 馬上刪除敵人 gameObject 此遊戲物件
        Destroy(gameObject);
        // 延遲 0.5 秒刪除爆炸特效
        Destroy(temp, 0.5f);
    }
}
