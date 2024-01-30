using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuNavigation : MonoBehaviour
{
   
   
    public const string GAME_SCENE = "Main";
    public const string MENU_SCENE = "Menu";
    [SerializeField] GameObject creditsGameObj;
    [SerializeField] GameObject menuGameObj;
   
    public void OnButtonCreditsClose()
    {
        menuGameObj.SetActive(true);
        creditsGameObj.SetActive(false);
    }

    public void OnButtonClickedCredits()
    {
        menuGameObj.SetActive(false);
        creditsGameObj.SetActive(true);
    }

    public void PlayGamebtn()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }
    public void MenuGamebtn()
    {
        SceneManager.LoadScene(MENU_SCENE);
    }

}
