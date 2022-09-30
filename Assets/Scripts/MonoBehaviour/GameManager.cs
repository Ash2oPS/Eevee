using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerManager _pm;

    private void Awake()
    {
        _pm = PlayerManager.Instance;
    }

    private void ChangeLevel(string lvl)
    {
        _pm.RemoveReferences();
        _pm.Save();
        SceneManager.LoadScene(lvl);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}