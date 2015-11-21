using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

  public void ChangeScene(string Scene)
    {
        Application.LoadLevel(Scene);
    }

    public void QuitJeux()
    {
        Application.Quit();
    }
}
