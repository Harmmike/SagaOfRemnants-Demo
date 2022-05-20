using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NotificationPanel : MonoBehaviour
{
    [SerializeField]private Text _notificationText;

    public void PushNotification(string message)
    {
        _notificationText.text = message;
        StartCoroutine(SendNotification());
    }

    private IEnumerator SendNotification()
    {
        yield return new WaitForSeconds(4);
        gameObject.SetActive(false);
    }
}
