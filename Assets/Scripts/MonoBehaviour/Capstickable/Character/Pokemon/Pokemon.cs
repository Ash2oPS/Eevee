using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pokemon : MonoBehaviour
{
    public bool CanMove;

    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private AudioListener _audioListener;

    public PlayerManager PlayerManager;

    public SpriteRenderer EeveeSpriteRenderer, HatSR, NeckSR, TailSR, EarSR;

    private void Awake()
    {
        PlayerManager = PlayerManager.Instance;
        if (PlayerManager == null)
        {
            return;
        }
        PlayerManager.GetHUD();
        PlayerManager.GetPokemon(this);
        PlayerManager.GetGameManager();
        PlayerManager.AM.WearAccessories(HatSR, NeckSR, EarSR, TailSR, EeveeSpriteRenderer);
        CanMove = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Collectable>(out Collectable col))
        {
            col.OnPickedUp(this);
            return;
        }
    }
}