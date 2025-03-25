using System;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItem : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_Text _playerName;

    private Image _backgroundIMG;

    [SerializeField]
    private Color _highlightColor;

    [SerializeField]
    private GameObject _rightArrowBTN;

    [SerializeField]
    private GameObject _leftArrowBTN;

    [Space(5)]
    private ExitGames.Client.Photon.Hashtable _playerProperties = new();

    [SerializeField]
    private Image _playerAvatar;

    [SerializeField]
    private Sprite[] _avatars;

    private Player _player;

    private void Awake()
    {
        _backgroundIMG = GetComponent<Image>();
    }

    public void SetPlayerInfo(Player player)
    {
        _player = player;
        _playerName.text = player.NickName;
        UpdatePlayerItem(player);
    }

    public void ApplyLocalChanges()
    {
        _backgroundIMG.color = _highlightColor;
        _rightArrowBTN.SetActive(true);
        _leftArrowBTN.SetActive(true);
    }

    public void OnClickRightArrow()
    {
        _playerProperties["playerAvatar"] =
            (int)_playerProperties["playerAvatar"] == _avatars.Length - 1
                ? 0
                : (int)_playerProperties["playerAvatar"] + 1;

        PhotonNetwork.SetPlayerCustomProperties(_playerProperties);
    }

    public void OnClickLeftArrow()
    {
        _playerProperties["playerAvatar"] =
            (int)_playerProperties["playerAvatar"] == 0
                ? _avatars.Length - 1
                : (int)_playerProperties["playerAvatar"] - 1;

        PhotonNetwork.SetPlayerCustomProperties(_playerProperties);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (_player == targetPlayer)
        {
            UpdatePlayerItem(targetPlayer);
        }
    }

    private void UpdatePlayerItem(Player player)
    {
        if (player.CustomProperties.ContainsKey("playerAvatar"))
        {
            _playerAvatar.sprite = _avatars[(int)player.CustomProperties["playerAvatar"]];

            player.CustomProperties["playerAvatar"] = (int)player.CustomProperties["playerAvatar"];
        }
        else
        {
            player.CustomProperties["playerAvatar"] = 0;
        }
    }
}
