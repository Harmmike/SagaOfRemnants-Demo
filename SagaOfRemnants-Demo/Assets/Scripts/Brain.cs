using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brain : MonoBehaviour
{
    private Player _currentPlayer;
    private SceneTransferObject[] _transferObjects;

    [SerializeField] private PlayerDataSO _playerData;
    [SerializeField] private EquipmentDisplayPanel _equipDisplayPanel;
    [SerializeField] private GameObject[] _virtualCameras;

    public GameObject PlayerPrefab;
    public Transform PlayerSpawnPoint;

    private void Start()
    {
        //Spawn player
        _currentPlayer = Instantiate(PlayerPrefab, PlayerSpawnPoint.position, Quaternion.identity).GetComponent<Player>();
        _currentPlayer.GetComponent<PlayerInventory>().ItemReceived += OnPlayerItemReceived;

        //Mock Player data from db
        _playerData.PlayerName = "Mike";
        _playerData.Level = 1;
        _playerData.MoveSpeed = 40;
        _playerData.Power = 1;

        //Initialize Player stats
        //_currentPlayer.InitializePlayerData(_playerData);

        foreach (var camera in _virtualCameras)
        {
            camera.GetComponent<CinemachineVirtualCamera>().Follow = _currentPlayer.transform;
        }

        //Subscribe to scene transfer objects' event
        _transferObjects = FindObjectsOfType<SceneTransferObject>();
        for (int i = 0; i < _transferObjects.Length; i++)
        {
            _transferObjects[i].TransferObjectActivated += OnTransferObjectActivated;
        }
    }

    private void OnPlayerItemReceived(object sender, Item item)
    {
        if(item.Type == ItemType.Equipment)
        {
            switch (item.ItemName)
            {
                case "Sword":
                    _equipDisplayPanel.DisplayEquipment(DisplayEquipment.Sword);
                    break;
            }
        }
    }

    private void OnTransferObjectActivated(object sender, (SceneMovement direction, int currentScene) sceneData)
    {
        //Unsubscribe from current scene's events
        for (int i = 0; i < _transferObjects.Length; i++)
        {
            _transferObjects[i].TransferObjectActivated -= OnTransferObjectActivated;
        }

        switch (sceneData.direction)
        {
            default:
                SceneManager.LoadScene(sceneData.currentScene + 1);
                break;

            case SceneMovement.Backward:
                SceneManager.LoadScene(sceneData.currentScene - 1);
                break;
        }
    }
}
