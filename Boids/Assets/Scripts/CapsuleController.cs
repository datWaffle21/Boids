using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour {

    public float moveSpeed = 5f;
    public float angle;

    GameObject player = null;
    public Vector3 position;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Boid");
        position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        angle = Random.Range(0, 360);
        player.transform.Rotate(Vector3.back * angle);
    }

    // Update is called once per frame
    void Update() {
        //Vector3 inputDir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;
        position = player.transform.position;

        //if travelling left && position.x < -10
        if (position.x < -10) {
            player.transform.Translate(new Vector3(20, 0, 0), Space.World);
        }

        //if travelling right && position.x > 10
        if (position.x > 10) {
            player.transform.Translate(new Vector3(-20, 0, 0), Space.World);
        }

        if (position.y > 5) {
            player.transform.Translate(new Vector3(0, -10, 0), Space.World);
        }

        if (position.y < -5) {
            player.transform.Translate(new Vector3(0, 10, 0), Space.World);

        }

        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed, Space.Self);
    }
}
