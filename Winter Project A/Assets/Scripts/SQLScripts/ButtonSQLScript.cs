using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonSQLScript : MonoBehaviour
{
    // Start is called before the first frame update

    Button myBtn;
    public Text myText;
    public Text myText1;
    public Text myText2;


    void Start()
    {
        myBtn = GetComponent<Button>();
        myBtn.onClick.AddListener(delegate
        {
            StreamingDatabaseManager.UpdatePlayerTrainingInTeam(0,"Strength");
            StreamingDatabaseManager.UpdatePlayerTrainingInTeam(0, "Agility");
            StreamingDatabaseManager.UpdatePlayerTrainingInTeam(0, "Tackling");
            //This is a test
            Debug.Log("update success");
            List<Player> TempPlayer = StreamingDatabaseManager.GetPlayersFromTeam(0);//Test if player's ability is indeed increased
            int RandomIndex = Random.Range(0,TempPlayer.Count-1);
            myText.text = "Right now player's Strength is: " + TempPlayer[RandomIndex].strength + "  Player Name is " + TempPlayer[RandomIndex].playerName;
            myText1.text = "Right now player's Agility is: " + TempPlayer[RandomIndex].agility + "  Player Name is " + TempPlayer[RandomIndex].playerName;
            myText2.text = "Right now player's Tackling is: " + TempPlayer[RandomIndex].tackling + "  Player Name is " + TempPlayer[RandomIndex].playerName;
        });
    }

    // Update is called once per frame
    void OnDestroy()
    {
        myBtn.onClick.RemoveAllListeners();
    }
}
