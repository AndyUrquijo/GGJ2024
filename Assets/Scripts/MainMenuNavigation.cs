using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuNavigation : MonoBehaviour
{
   
   
    public const string GAME_SCENE = "Main";
    [SerializeField] GameObject creditsGameObj;
    [SerializeField] GameObject menuGameObj;
   
    private void OnButtonCreditsClose()
    {
        
    }

    private void OnButtonClickedCredits()
    {
        
    }

    public void PlayGamebtn()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }
}
