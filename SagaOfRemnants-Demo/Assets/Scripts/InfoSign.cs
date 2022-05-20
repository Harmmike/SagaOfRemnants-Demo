using UnityEngine;
using UnityEngine.UI;

public class InfoSign : InteractableObject
{
    public string SignText = "Missing Text.";
    public GameObject DialogBox;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _playerInRange)
        {
            //Set correct text for sign.
            var signText = DialogBox.GetComponentInChildren<Text>();
            signText.text = SignText;

            //Enable/Disable Dialog box and notification
            InteractableNotificationText.SetActive(false);
            if (DialogBox.activeInHierarchy)
            {
                DialogBox.SetActive(false);
            }
            else
            {
                DialogBox.SetActive(true);
            }
        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        DialogBox.SetActive(false);
    }
}
