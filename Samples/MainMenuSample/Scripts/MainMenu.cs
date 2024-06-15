/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using RTDK.LoadingScreen;
using RTDK.MainMenu;
using UnityEngine;

public class MainMenu : MainMenuBase
{
    public void LoadScene(string name)
    {
        SceneLoader.Instance.LoadScene(name);
    }

    public override void OpenView(MenuViewBase view)
    {
        base.OpenView(view);
    }

    public override void OpenURL(string url)
    {
        base.OpenURL(url);
    }

    public override void QuitBtn()
    {
        base.QuitBtn();
    }
}
