using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameControlScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectToDisable;
    public static bool disable = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (disable)
            objectToDisable.SetActive(false);
        else
            objectToDisable.SetActive(true);
    }
}
