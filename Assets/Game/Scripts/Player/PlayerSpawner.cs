using Photon.Pun;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _playerPrefabs;

    [SerializeField]
    private Transform[] _spawnPoints;

    private void Start()
    {
        int rand = Random.Range(0, _spawnPoints.Length);
        Transform spawnPoint = _spawnPoints[rand];
        
        GameObject playerToSpawn = _playerPrefabs[
            (int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]
        ];

        PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, Quaternion.identity);
    }
}
