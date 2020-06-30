using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSQLScript : MonoBehaviour
{
    // Start is called before the first frame update

    Button myBtn;
    void Start()
    {
        int count = StreamingDatabaseManager.GetPlayersCount();
        Debug.Log("there are " + count + " players");
        myBtn = GetComponent<Button>();
        myBtn.onClick.AddListener(delegate
        {   int tempAbilityScore = StreamingDatabaseManager.GetPlayerScore(1);
            Debug.Log("Right now Messi's player score is: "+tempAbilityScore);
            tempAbilityScore++;
            StreamingDatabaseManager.UpdatePlayerAbility(tempAbilityScore, 1);            
        });
    }

    // Update is called once per frame
    void OnDestroy()
    {
        myBtn.onClick.RemoveAllListeners();
    }
}
