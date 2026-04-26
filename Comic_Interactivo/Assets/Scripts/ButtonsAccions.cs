using UnityEngine;

public class ButtonsAccions : MonoBehaviour
{

    public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }
}
