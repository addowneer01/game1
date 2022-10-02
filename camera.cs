using UnityEngine;

public class camera : MonoBehaviour
{
    public Vector3 pos;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        if (player.transform.position.y >= 0) { gameObject.transform.position = player.transform.position + pos; }
    }
}
