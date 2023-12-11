using TMPro;            // TMP 文字 空間
using UnityEngine;
using UnityEngine.UI;   // Image 圖片 空間

namespace KID
{
    public class DamagePlayer : DamageBasic
    {
        [Header("玩家血量文字")]
        public TextMeshProUGUI textHp;
        [Header("血條圖片")]
        public Image imageHp;

        private float hpMax;

        private void Awake()
        {
            hpMax = hp;
            textHp.text = hp.ToString();
        }

        public override void Damage(float damage)
        {
            base.Damage(damage);

            // 更新文字介面
            textHp.text = hp.ToString();
            // 更新圖片介面
            imageHp.fillAmount = hp / hpMax;
        }
    }
}

