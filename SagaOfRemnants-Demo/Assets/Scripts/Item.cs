using UnityEngine;

public enum ItemType
{
    Equipment, Consumable
}

public class Item : MonoBehaviour
{
    public string ItemName = "Missing item name.";
    public ItemType Type;
    public NotificationPanel NotificationPanel;
}
