using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textcontrol : MonoBehaviour
{
    // Start is called before the first frame update
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameControlScript.disable)
            text.text = "Ball is gone";
        if (!gameControlScript.disable)
            text.text = "Ball is here";

    }
}
