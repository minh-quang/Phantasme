using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
    public bool mute;
    public GameObject ButtonMute;
    public GameObject ButtonNonMute;

    public void ChangeScene(string Scene)
    {
        Application.LoadLevel(Scene);
    }

    public void QuitJeux()
    {
        Application.Quit();
    }

    public void Mute()
    {
        mute = true;
        ButtonMute.SetActive(false);
        ButtonNonMute.SetActive(true);
    }

    public void NonMute()
    {
        mute = false;
        ButtonMute.SetActive(true);
        ButtonNonMute.SetActive(false);
    }
}
