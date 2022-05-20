using UnityEngine;

public class CellarExit : SceneTransferObject
{
    private void Update()
    {
        if (!_playerInRange)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaiseActivation(SceneMovement.Backward);
        }
    }
}
