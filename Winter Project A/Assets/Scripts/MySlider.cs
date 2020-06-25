using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mySlider : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text textSldr;
    Slider mySld;
    
    void Start()
    {
        mySld = GetComponent<Slider>();
        mySld.onValueChanged.AddListener(delegate
        {
            
            textSldr.text = "Value: " + mySld.value;

        });
    }

    // Update is called once per frame
    void OnDestroy()
    {
        mySld.onValueChanged.RemoveAllListeners();
    }
}
