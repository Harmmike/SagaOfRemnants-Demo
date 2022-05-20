using System;
using UnityEngine;

public enum SceneMovement
{
    Forward, Backward
}

public class SceneTransferObject : MonoBehaviour
{
    [SerializeField] private int CURRENT_SCENE_NUMBER = 0;

    protected bool _playerInRange = false;
    protected PlayerInventory _playerInventory;

    public EventHandler<(SceneMovement, int)> TransferObjectActivated;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerInRange = true;
            _playerInventory = collision.GetComponent<PlayerInventory>();
        }
    }

    protected virtual void RaiseActivation(SceneMovement sceneMovement)
    {
        var handler = TransferObjectActivated;
        if(handler != null)
        {
            TransferObjectActivated.Invoke(this, (sceneMovement, CURRENT_SCENE_NUMBER));
        }
    }
}
