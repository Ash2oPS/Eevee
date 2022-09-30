using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

#region PlayerManager

public class PlayerManager : MonoBehaviour
{
    #region Variables

    public static PlayerManager Instance;

    #region References

    [Header("----------DEBUG")]
    public bool DEBUG = false;

    [Header("----------References")]
    [SerializeField]
    private Pokemon _myPoke;

    [SerializeField]
    public HUD _currentHUD;

    public Transition TransitionPrefab;

    private GameManager _gm;

    public AccessoryManager AM;

    public BagOfNuggets HeldBagOfNuggets;

    #endregion References

    #region Stats

    [Header("----------Stats")]
    public string _playerName;

    public int _nuggets;
    public bool IsHoldingBagOfNugs;

    #endregion Stats

    #region Others

    private string _basePath;
    private string _assetPath;
    private string _savePath;

    #endregion Others

    #endregion Variables

    #region Initialization

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);

        _basePath = Application.dataPath;

        _assetPath = _basePath + "/StreamingAssets/Data/";

        _savePath = _basePath + "/StreamingAssets/Save/save.sav";
    }

    private void Start()
    {
        if (!DEBUG)
        {
            TransitionAnim(true);
        }
    }

    #endregion Initialization

    #region Reference Getters

    public void GetHUD()
    {
        _currentHUD = FindObjectOfType<HUD>();
    }

    public void GetPokemon(Pokemon poke)
    {
        _myPoke = poke;
    }

    public void GetGameManager()
    {
        _gm = FindObjectOfType<GameManager>();
    }

    public void RemoveReferences()
    {
        _currentHUD = null;
        _myPoke = null;
        _gm = null;
    }

    #endregion Reference Getters

    #region Nuggets

    public void SetNuggets(int value)
    {
        _nuggets = value;
        NuggetsHUDUpdate();
    }

    public void AddNuggets(int value)
    {
        _nuggets += value;
        NuggetsHUDUpdate();
    }

    private void NuggetsHUDUpdate()
    {
        if (_currentHUD != null)
        {
            _currentHUD.UpdateNuggets(_nuggets);
        }
    }

    #endregion Nuggets

    #region SceneManagement

    private Transition TransitionAnim(bool entrant)
    {
        Camera cam = FindObjectOfType<Camera>();
        Transition trans = Instantiate(TransitionPrefab, cam.transform);
        trans.transform.position = new Vector3(0, 0, 10);
        trans.PlayTransition(entrant);
        return trans;
    }

    public void LoadRoom(string scene)
    {
        StartCoroutine(SceneTransition(scene));
    }

    private IEnumerator SceneTransition(string scene)
    {
        Transition trans = TransitionAnim(false);
        yield return new WaitForSeconds(0.5f);
        trans.transform.parent = this.transform;
        trans.transform.localScale = Vector3.one * 2;
        SceneManager.LoadScene(scene);
        yield return new WaitForSeconds(0.15f);
        trans.transform.localScale = Vector3.one;
        trans.transform.parent = FindObjectOfType<Camera>().transform;
        yield return new WaitForSeconds(0.2f);
        trans.PlayTransition(true);
    }

    public void QuitGame()
    {
        StartCoroutine(Quit());
    }

    private IEnumerator Quit()
    {
        Transition trans = TransitionAnim(false);
        trans.sr.color = Color.black;
        yield return new WaitForSeconds(0.5f);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#endif
        Application.Quit();
    }

    #endregion SceneManagement

    #region Save&Load

    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(_savePath, FileMode.Create);

        PlayerData data = new PlayerData(this);

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("Saved at: " + _savePath);
    }

    public void Load()
    {
        PlayerData data = RawLoad(_savePath);

        _nuggets = data.Nugs;
        _playerName = data.PlayerName;

        if (data.itemIDs.Length == 0)
            return;

        foreach (int i in data.itemIDs)
        {
            AM.GainReward(AM.Items.ObtainedItems[i].ItemObject as Accessory, false);
        }
    }

    private PlayerData RawLoad(string path)
    {
        if (!File.Exists(path))
        {
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        PlayerData data = formatter.Deserialize(stream) as PlayerData;
        stream.Close();

        Debug.Log("Loaded from: " + path);

        return data;
    }

    public bool IsThereASave()
    {
        if (!File.Exists(_savePath))
        {
            return false;
        }

        return true;
    }

    public void DeleteSave()
    {
        if (IsThereASave())
        {
            File.Delete(_savePath);

            Debug.Log("Save deleted from: " + _savePath);
        }
    }

    #endregion Save&Load
}

#endregion PlayerManager

#region PlayerData

[System.Serializable]
public class PlayerData
{
    public int Nugs;
    public string PlayerName;
    public int[] itemIDs;

    public PlayerData(PlayerManager pm)
    {
        Nugs = pm._nuggets;
        PlayerName = pm._playerName;
        itemIDs = pm.AM.ItemIDs.ToArray();
    }
}

#endregion PlayerData