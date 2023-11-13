using UnityEngine;

public class FireSystem : MonoBehaviour
{
    #region 資料
    [Header("彈匣的子彈數量"), Range(0, 10)]
    public int magazineCount = 7;
    [Header("子彈總數"), Range(20, 200)]
    public int bulletTotal = 28;
    [Header("目前子彈數量"), Range(0, 10)]
    public int bulletCurrent = 7;
    [Header("子彈預製物")]
    public GameObject prefabBullet;
    [Header("子彈生成點")]
    public Transform pointSpawnBullet;
    [Header("開槍動畫參數")]
    public string parFire = "觸發開槍";
    [Header("動畫控制器")]
    public Animator ani;
    [Header("音效來源")]
    public AudioSource aud;
    [Header("開槍音效")]
    public AudioClip soundFire;
    #endregion

    /* 這裡是練習的區域
    public bool openDoor = true;
    public bool isDead = false;

    private void Awake()
    {
        // print("<color=green>喚醒事件</color>");
        Instantiate(prefabBullet);
    }

    private void Start()
    {
        // print("<color=yellow>開始事件</color>");

        if (openDoor)
        {
            print("已經開門");
        }

        if (isDead)
        {
            print("已經死亡");
        }
    }
    */

    private void Update()
    {
        // print("<color=red>更新事件</color>");

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ani.SetTrigger(parFire);
            Instantiate(prefabBullet, pointSpawnBullet.position, pointSpawnBullet.rotation);

            float volume = Random.Range(0.8f, 3.2f);
            aud.PlayOneShot(soundFire, volume);
        }
    }
}
