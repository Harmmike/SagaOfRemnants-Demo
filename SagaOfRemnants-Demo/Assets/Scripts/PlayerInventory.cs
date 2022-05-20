using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<Item> _allItems;

    public EventHandler<Item> ItemReceived;

    public bool HasKey => _allItems.FirstOrDefault(i => i.Type == ItemType.Consumable && i.GetType() == typeof(Key));
    public bool HasSword => _allItems.FirstOrDefault(i => i.Type == ItemType.Equipment && i.GetType() == typeof(Sword));

    private void Start()
    {
        _allItems = new List<Item>();
    }

    public void AddItem(Item item)
    {
        _allItems.Add(item);
        var handler = ItemReceived;
        if(handler != null)
        {
            ItemReceived?.Invoke(this, item);
        }
    }
}
