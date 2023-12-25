using UnityEngine;

public class Test : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print($"<color=#f69>碰到東西囉!</color>");

        if (collision.gameObject.name.Contains("Player"))
        {
            print($"<color=#f69>碰到 {collision.gameObject.name} 囉!</color>");
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        print($"<color=#f69>碰到東西囉! OCCH </color>");
    }
}
