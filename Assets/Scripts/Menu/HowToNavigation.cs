using UnityEngine;

public class HowToNavigation : MonoBehaviour
{
    public GameObject[] pages;
    public GameObject ActivePage;
    private int ActivePageNr = 0;

    public void StartHowTo()
    {
        ActivePage = pages[ActivePageNr];
        ActivePage.SetActive(true);
    }

    public void GoToNextPage()
    {
        ActivePage.SetActive(false);
        ActivePageNr++;
        ActivePage = pages[ActivePageNr];
        ActivePage.SetActive(true);
    }

    public void GoToPreviousPage()
    {
        ActivePage.SetActive(false);
        ActivePageNr--;
        ActivePage = pages[ActivePageNr];
        ActivePage.SetActive(true);
    }
}
