using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string _playerName;

    [SerializeField]
    private TMP_Text _nameTXT;

    public void SetPlayerName()
    {
        _nameTXT.text = _playerName;
    }
}
