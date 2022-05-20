using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerDataSO _playerData;

    public void InitializePlayerData(PlayerDataSO playerData)
    {
        _playerData = playerData;
        GetComponent<PlayerMovement>().MoveSpeed = _playerData.MoveSpeed;
    }
}
