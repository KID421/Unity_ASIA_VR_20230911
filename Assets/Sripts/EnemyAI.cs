using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    [Header("怪物代理器")]
    public NavMeshAgent agent;
    [Header("玩家物件")]
    public Transform player;
    [Header("移動速度"), Range(0, 5)]
    public float moveSpeed = 2.5f;
    [Header("停止距離"), Range(0, 5)]
    public float stopDistance = 1;
    [Header("動畫控制器")]
    public Animator ani;
    [Header("延遲造成傷害"), Range(0, 5)]
    public float delayDamage = 0.6f;
    [Header("攻擊冷卻"), Range(0, 5)]
    public float cd = 2.1f;

    private string parMove = "移動數值";
    private string parAttack = "觸發攻擊";
    private bool canAttack = true;

    private void Awake()
    {
        // 代理器的速度 = 移動速度
        agent.speed = moveSpeed;
        // 代理器的停止距離 = 停止距離
        agent.stoppingDistance = stopDistance;
    }

    private void Update()
    {
        // 怪物代理器.設定目的地(玩家的座標)
        agent.SetDestination(player.position);

        // 移動值 = 代理器.加速度.轉換成浮點數 (大小)
        float move = agent.velocity.magnitude;
        // 動畫控制器.設定浮點數(浮點數參數，浮點數值)
        ani.SetFloat(parMove, move);

        // print($"<color=#f69>移動速度：{agent.velocity.magnitude}</color>");

        float distance = Vector3.Distance(transform.position, player.position);
        // print($"<color=#96f>距離：{distance}</color>");

        // 如果 移動速度 等於 零 並且 可以攻擊 並且 距離 小於 停止距離 就 攻擊
        // canAttack == true 簡寫 canAttack
        if (agent.velocity.magnitude == 0 && canAttack && distance < stopDistance)
        {
            // 不能攻擊
            canAttack = false;

            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        // 播放攻擊動畫
        ani.SetTrigger(parAttack);
        // 等 0.4 秒
        yield return new WaitForSeconds(delayDamage);
        // 造成玩家傷害
        print("<color=#f69>造成玩家傷害!</color>");
        // 等 2.1 秒
        yield return new WaitForSeconds(cd);
        // 恢復可攻擊狀態
        canAttack = true;
    }
}
