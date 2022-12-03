using UnityEngine;

public class Follow_player : MonoBehaviour {

    public Transform player;

    // Update is called once per frame
    void LateUpdate () {
        transform.position = player.transform.position + new Vector3(2.8f, 4.05f, 3.91f);
    }
}