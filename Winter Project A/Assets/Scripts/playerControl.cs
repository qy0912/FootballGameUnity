using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerControl : MonoBehaviour
{
    float dirX, dirY;
    Rigidbody rb;
    bool moveRight = true;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        int count = 0;
        Debug.Log("start");
        count = StreamingDatabaseManager.GetPlayersCount();
        Debug.Log("there are" + count + "players");
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");
        if (moveRight)
            rb.velocity = new Vector3(3, 0, 0);
        if (!moveRight)
            rb.velocity = new Vector3(-3, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.name) {
            case "Enable":
                gameControlScript.disable = false;
                moveRight = true;
                break;
            case "Disable":
                gameControlScript.disable = true;
                moveRight = false;
                break;
        }
    }
}
