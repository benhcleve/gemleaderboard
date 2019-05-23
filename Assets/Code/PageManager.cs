using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    public GameObject leaderboardPage;
    public GameObject gemsPage;


    public void GemPageBackButton()
    {
        gemsPage.SetActive(false);
        leaderboardPage.SetActive(true);
    }

    public void GemPageOpenButton()
    {
        gemsPage.SetActive(true);
        leaderboardPage.SetActive(false);
    }
}
