using UnityEngine;

public class Follow_player : MonoBehaviour {

    public Transform player;

    // Update is called once per frame
    void LateUpdate () {
        transform.position = player.transform.position + new Vector3(1.6f, 10.5f, -12.3f);
    }
}