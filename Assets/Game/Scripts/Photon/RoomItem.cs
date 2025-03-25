using TMPro;
using UnityEngine;

public class RoomItem : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _roomName;

    private LobbyManager _lobbyManager;

    private void Start()
    {
        _lobbyManager = FindAnyObjectByType<LobbyManager>();
    }

    public void SetRoomName(string roomName)
    {
        _roomName.text = roomName;
    }

    public void OnClickItem()
    {
        _lobbyManager.JoinRoom(_roomName.text);
    }
}
