using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    // Kameranın otobüse göre konumu
    private Vector3 offset = new Vector3(0f, 6f, -12f);

    void LateUpdate()
    {
        if (player != null)
        {
            // Kamera otobüsün arkasında kalır ve dönüşünü takip eder
            transform.position = player.transform.position + player.transform.rotation * offset;

            // Kamera otobüsün baktığı yöne döner
            transform.rotation = player.transform.rotation;
        }
    }
}