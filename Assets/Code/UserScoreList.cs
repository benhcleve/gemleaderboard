using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserScoreList : MonoBehaviour
{
    public GameObject UserEntryPrefab;
    ScoreManager scoreManager;

    int lastChangeCounter;

    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        }
    void Update()
    {
        if(scoreManager == null) {
            Debug.LogError("You forgot to add the score manager component to a game object!");
            return;
        }

        if(scoreManager.GetChangeCounter() == lastChangeCounter) {
            //No change since last update! Do nothing.
            return;
        }
         lastChangeCounter = scoreManager.GetChangeCounter();
         
        while(this.transform.childCount > 0) {
            Transform c = this.transform.GetChild(0);
            c.SetParent(null);
            Destroy (c.gameObject);
        }
        //These names are pulled from Public ScoreManager function GetUserNames();
        string[] names = scoreManager.GetUserNames("Gems");

        //Finds Components for each UserEntry and changes text accordingly
        foreach(string name in names) {
            GameObject go = (GameObject)Instantiate(UserEntryPrefab);
            int rank = System.Array.IndexOf(names, name) + 1;
            go.transform.SetParent(this.transform);
            go.transform.Find ("UserName").GetComponent<TextMeshProUGUI>().text = name;
            go.transform.Find ("UserScore").GetComponent<TextMeshProUGUI>().text = scoreManager.GetScore(name, "Gems").ToString();
            go.transform.Find ("UserRank").GetComponent<TextMeshProUGUI>().text = rank.ToString();
        }

    }
    
}
