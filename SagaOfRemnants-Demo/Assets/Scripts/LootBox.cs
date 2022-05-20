using System.Collections.Generic;
using UnityEngine;

public class LootBox : InteractableObject
{
    private Animator _animator;

    public bool IsLocked = true;
    public List<Item> Items;

    public NotificationPanel NotificationPanel;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _playerInRange)
        {
            if (IsLocked)
            {
                if (_playerInventory.HasKey)
                {
                    IsLocked = false;
                    PlayerInteraction();
                }
                else
                {
                    IsLocked = true;
                    PlayerInteraction();
                }
            }
            else
            {
                PlayerInteraction();
            }
        }
    }

    private void PlayerInteraction()
    {
        if (IsLocked)
        {
            NotificationPanel.gameObject.SetActive(true);
            NotificationPanel.PushNotification("The chest is locked. You need to find a key!");
        }
        else
        {
            if(Items.Count == 0)
            {
                NotificationPanel.gameObject.SetActive(true);
                NotificationPanel.PushNotification("This chest is empty.");
            }
            else
            {
                string message = "The chest contained ";
                string contents = string.Empty;
                foreach (var item in Items)
                {
                    _playerInventory.AddItem(item);
                    contents = contents + $"\n{item.ItemName}";
                }

                _animator.SetTrigger("Open");

                NotificationPanel.gameObject.SetActive(true);
                NotificationPanel.PushNotification(message + contents);

                Items.Clear();
            }
        }
    }
}
