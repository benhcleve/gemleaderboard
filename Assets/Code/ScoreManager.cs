using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour
{

    Dictionary<string, Dictionary<string, int> > userScores;

    int changeCounter = 0;
    void Start()
    {
        //Example Users. Takes a string for the username, then takes a type of 'Gems' and the amount of gems the user has.
        SetScore("Ben", "Gems", 267);
        SetScore("Peter", "Gems", 300);
        SetScore("John", "Gems", 112);
        SetScore("Bethany", "Gems", 4);
        SetScore("Jordan" , "Gems", 16);
        SetScore("Wendy" , "Gems", 19);
        SetScore("Frank" , "Gems", 77);
        SetScore("Patty" , "Gems", 47);
        SetScore("fasfdsaf", "Gems", 267);
        SetScore("dfsadfas", "Gems", 300);
        SetScore("dfsafsdaf", "Gems", 112);
        SetScore("dfsafdsaf", "Gems", 4);
        SetScore("ffff", "Gems", 16);
        SetScore("aaaa" , "Gems", 19);
        SetScore("bbbb" , "Gems", 77);
        SetScore("cccc" , "Gems", 47);

    }

    void Init() {
        if(userScores != null)
            return;

        userScores = new Dictionary<string, Dictionary<string, int> >();
    }




    public int GetScore(string username, string scoreType) {
        Init();

        if(userScores.ContainsKey(username) == false) {
            //We have no score record at all for this username
            return 0;
        }

        if(userScores[username].ContainsKey(scoreType) == false) {
            return 0;
        }


        return userScores[username][scoreType];
    }

    public void SetScore(string username, string scoreType, int value) {
        Init();

        changeCounter++;

        if(userScores.ContainsKey(username) == false) {
           userScores[username] = new Dictionary<string, int>();
        }
        userScores[username][scoreType] = value;
    }

    public void ChangeScore(string username, string scoreType, int amount) {
        Init();
        int currScore = GetScore(username, scoreType);
        SetScore(username, scoreType, currScore + amount);

    }

     public string[] GetUserNames(string sortingScoreType) {
        Init();

        return userScores.Keys.OrderByDescending( n => GetScore( n, sortingScoreType)).ToArray();
    }

    public int GetChangeCounter() {
        return changeCounter;
    }
}