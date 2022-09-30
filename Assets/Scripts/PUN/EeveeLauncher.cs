using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EeveeLauncher : MonoBehaviour
{
    private PlayerManager _pm;

    [SerializeField]
    private RectTransform _newGameLauncher, _loadGameLauncher;

    [SerializeField]
    private Transform _panneauTransform;

    [Header("----------Windows")]
    public Window _currentWindow;

    [Header("Window Prefabs")]
    [SerializeField]
    private Window _newGameWindow;

    [SerializeField]
    private void Start()
    {
        _pm = PlayerManager.Instance;

        CheckIfNewGame();
    }

    private void CheckIfNewGame()
    {
        if (_pm.IsThereASave())
        {
            _loadGameLauncher.gameObject.SetActive(true);
            return;
        }
        _newGameLauncher.gameObject.SetActive(true);
    }

    public void NewGame()
    {
        _currentWindow = _newGameWindow;
        _currentWindow.gameObject.SetActive(true);
        _currentWindow.CreateWindow("Nouvelle Partie", "Quel est ton nom ?");
    }

    public void CreateNewGame(string newName)
    {
        if (_pm.IsThereASave())
        {
            _pm.DeleteSave();
        }

        _pm._playerName = newName;
        _pm.Save();

        _pm.LoadRoom("Room1");
    }

    public void Continue()
    {
        //LoadRoom("Hub");
        _pm.Load();
        _pm.LoadRoom("Hub");
    }

    public void DeleteGame()
    {
        _pm.DeleteSave();
        _pm.LoadRoom(SceneManager.GetActiveScene().name);
    }

    public void Options()
    {
        Debug.Log("Cling ! C'est les paramètres !");
    }
}