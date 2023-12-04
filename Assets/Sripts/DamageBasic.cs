using UnityEngine;

public class DamageBasic : MonoBehaviour
{
    [Header("血量"), Range(0, 1000)]
    public float hp = 100;

    /// <summary>
    /// 角色受傷方法
    /// </summary>
    /// <param name="damage">受到的傷害值</param>
    public void Damage(float damage)
    {
        // 血量 遞減 傷害值
        hp -= damage;
        // 將血量 限制在 0 ~ 1000 之間
        hp = Mathf.Clamp(hp, 0, 1000);
        // 如果 血量 <= 0 就死亡
        if (hp <= 0) Dead();
    }

    // private 私人：只有這個腳本可以用
    // public 公開：全部腳本都可以用
    // protected 保護：允許子類別使用

    // virtual 虛擬：允許子類別覆寫 override

    /// <summary>
    /// 角色死亡方法
    /// </summary>
    protected virtual void Dead()
    {
        print("<color=#69f>死亡</color>");
    }
}
