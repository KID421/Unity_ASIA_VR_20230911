using UnityEngine;
using System.Collections;

/// <summary>
/// 學習協同程序 Coroutine
/// 讓程式等待 (停留)
/// </summary>
public class LearnCoroutine : MonoBehaviour
{
    // 1. 一開始發 500 塊
    // 2. 等 2 秒
    // 3. 出小兵
    // 4. 等 2 秒
    // 5. 出野怪
    // 6. 等 3.5 秒
    // 7. 出小龍

    // 協同程序三個必需條件
    // 1. 引用 System.Collections 命名空間
    // 2. 定義一個方法並且傳回類型為 IEnumerator
    // 3. 使用 StartCoroutine 啟動

    private IEnumerator Test()
    {
        print("<color=#6f9>發五百</color>");
        yield return new WaitForSeconds(2);
        print("<color=#6f9>出小兵</color>");
        yield return new WaitForSeconds(2);
        print("<color=#6f9>出野怪</color>");
        yield return new WaitForSeconds(3.5f);
        print("<color=#6f9>出小龍</color>");
    }

    private void Awake()
    {
        StartCoroutine(Test());
    }
}
