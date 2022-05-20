public class Key : Item
{
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<PlayerInventory>();
            player.AddItem(this);
            NotificationPanel.gameObject.SetActive(true);
            NotificationPanel.PushNotification("You found a key!");
            gameObject.SetActive(false);
        }
    }
}
