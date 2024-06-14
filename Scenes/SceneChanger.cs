using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button endButton;
    void Start()
    {
        // 버튼의 OnClick 이벤트에 리스너 추가
        startButton.onClick.AddListener(() => LoadGameScreen());
        endButton.onClick.AddListener(() => ExitGame());
    }

    public void LoadGameScreen()
    {
        SceneManager.LoadScene("GameScreen");
    }
    public void ExitGame()
    {
        // 에디터에서 게임을 종료할 때
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            // 빌드된 게임에서 종료할 때
            Application.Quit();
    #endif
    }


}