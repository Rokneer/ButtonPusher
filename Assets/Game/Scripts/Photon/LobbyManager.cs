using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_InputField _roomInput;

    [SerializeField]
    private GameObject _lobbyPanel;

    [SerializeField]
    private GameObject _roomPanel;

    [SerializeField]
    private TMP_Text _roomName;

    [Space(5)]
    [SerializeField]
    private RoomItem _roomItemPrefab;
    private List<RoomItem> _roomItemList = new();

    [SerializeField]
    private Transform _roomItemContainer;

    [Space(5)]
    [SerializeField]
    private PlayerItem _playerItemPrefab;

    [SerializeField]
    private Transform _playerItemContainer;
    private List<PlayerItem> _playerItemsList = new();

    [Space(5)]
    [SerializeField]
    private GameObject _playButton;

    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            _playButton.SetActive(true);
        }
        else
        {
            _playButton.SetActive(false);
        }
    }

    public void OnClickCreate()
    {
        if (_roomInput.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(
                _roomInput.text,
                new RoomOptions() { MaxPlayers = 2, BroadcastPropsChangeToAll = true }
            );
        }
    }

    public override void OnJoinedRoom()
    {
        _lobbyPanel.SetActive(false);
        _roomPanel.SetActive(true);
        _roomName.text = $"Room name: {PhotonNetwork.CurrentRoom.Name}";

        UpdatePlayerList();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
    }

    private void UpdateRoomList(List<RoomInfo> roomList)
    {
        foreach (RoomItem item in _roomItemList)
        {
            Destroy(item.gameObject);
        }
        _roomItemList.Clear();

        foreach (RoomInfo room in roomList)
        {
            RoomItem newRoom = Instantiate(_roomItemPrefab, _roomItemContainer);
            newRoom.SetRoomName(room.Name);
            _roomItemList.Add(newRoom);
        }
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        _roomPanel.SetActive(false);
        _lobbyPanel.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    private void UpdatePlayerList()
    {
        foreach (PlayerItem item in _playerItemsList)
        {
            Destroy(item.gameObject);
        }
        _playerItemsList.Clear();

        if (PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItem newPlayerItem = Instantiate(_playerItemPrefab, _playerItemContainer);
            newPlayerItem.SetPlayerInfo(player.Value);

            if (player.Value == PhotonNetwork.LocalPlayer)
            {
                newPlayerItem.ApplyLocalChanges();
            }

            _playerItemsList.Add(newPlayerItem);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }

    public void OnClickPlay()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }
}
