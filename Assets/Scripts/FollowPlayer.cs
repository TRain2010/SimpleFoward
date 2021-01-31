using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector3 offset;
    public Vector3 rotate;
    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
        transform.eulerAngles = rotate;
    }
}
