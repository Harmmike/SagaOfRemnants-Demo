using UnityEngine;

public class CellarEntrance : SceneTransferObject
{
    private void Update()
    {
        if (!_playerInRange)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_playerInventory.HasSword)
            {
                RaiseActivation(SceneMovement.Forward);
            }
        }
    }
}
