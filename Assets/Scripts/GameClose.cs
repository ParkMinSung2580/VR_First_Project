using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClose : MonoBehaviour
{
    [SerializeField] private Button GameCloseButton;

    private void OnEnable()
    {
        GameCloseButton.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
        GameCloseButton.onClick.RemoveListener(ExitGame);
    }

    public void ExitGame()
    {
        Debug.Log("게임 종료!");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
