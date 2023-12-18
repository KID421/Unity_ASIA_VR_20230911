using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // private 私人：不顯示，不允許外存取
    // public 公開：顯示，允許外部存取

    // SerializeField 序列化欄位，把私人資料顯示

    // 單例模式：在遊戲內只有一個存在時適用，例如：GM
    // static 靜態：遊戲運行時就會將該資料存在記憶體
    public static GameManager instance;

    [SerializeField, Header("畫布結束畫面")]
    private CanvasGroup groupFinal;
    [SerializeField, Header("結束標題")]
    private TextMeshProUGUI textFinalTitle;
    [SerializeField, Header("按鈕重新遊戲")]
    private Button btnReplay;
    [SerializeField, Header("按鈕離開遊戲")]
    private Button btnQuit;
    [SerializeField, Header("手槍")]
    private FireSystem fireSystem;

    private void Awake()
    {
        // 實體物件 = 這個物件
        instance = this;
        // 按下離開按鈕後退出
        btnQuit.onClick.AddListener(Quit);
        // 按下重新遊戲後重載場景
        btnReplay.onClick.AddListener(Replay);
        // 恢復遊戲速度
        Time.timeScale = 1;

        Cursor.visible = false;
    }

    private void Quit()
    {
        // 離開遊戲：發佈執行檔才有作用
        Application.Quit();
    }

    private void Replay()
    {
        SceneManager.LoadScene("後室");
    }

    /// <summary>
    /// 開始顯示結束畫面
    /// </summary>
    /// <param name="finalTitle">結束標題文字</param>
    public void StartShowFinal(string finalTitle)
    {
        // 更新結束標題文字 = 結束標題參數
        textFinalTitle.text = finalTitle;
        // 開始淡入
        StartCoroutine(FadeIn());
        // 關閉開槍系統
        fireSystem.enabled = false;
        // 時間暫停
        Time.timeScale = 0;
    }

    private IEnumerator FadeIn()
    {
        for (int i = 0; i < 10; i++)
        {
            // 結束畫布群組 透明度 遞增 0.1
            groupFinal.alpha += 0.1f;
            // 等 0.03 秒 真實時間
            yield return new WaitForSecondsRealtime(0.03f);
        }

        groupFinal.interactable = true;
        groupFinal.blocksRaycasts = true;

        // 顯示滑鼠
        Cursor.lockState = CursorLockMode.Confined;

        Cursor.visible = true;

    }
}
