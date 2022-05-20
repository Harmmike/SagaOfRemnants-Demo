using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    protected bool _playerInRange = false;
    protected PlayerInventory _playerInventory = null;

    public GameObject InteractableNotificationText;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerInRange = true;
            _playerInventory = collision.GetComponent<PlayerInventory>();
            InteractableNotificationText.SetActive(true);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerInRange = false;
            _playerInventory = null;
            InteractableNotificationText.SetActive(false);
        }
    }
}
