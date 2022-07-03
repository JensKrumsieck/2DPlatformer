using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    
    // Update is called once per frame
    void Update()
    {
        if (player is null) return;
        var position = player.position;
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }
}
