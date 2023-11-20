using UnityEngine;
using UnityEngine.AI;

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

    private string parMove = "移動數值";

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
    }
}
