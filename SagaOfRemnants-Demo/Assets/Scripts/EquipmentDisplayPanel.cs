using UnityEngine;
using UnityEngine.UI;

public enum DisplayEquipment
{
    Sword, Chest, Helmet
}

public class EquipmentDisplayPanel : MonoBehaviour
{
    [SerializeField] private Sprite _swordBgSprite;
    [SerializeField] private Sprite _swordFgSprite;
    [SerializeField] private Sprite _chestBgSprite;
    [SerializeField] private Sprite _chestFgSprite;
    [SerializeField] private Sprite _helmetBgSprite;
    [SerializeField] private Sprite _helmetFgSprite;

    public GameObject SwordDisplayPanel;
    public GameObject ChestDisplayPanel;
    public GameObject HelmetDisplayPanel;

    public void DisplayEquipment(DisplayEquipment equipType)
    {
        switch (equipType)
        {
            case global::DisplayEquipment.Sword:
                var image = SwordDisplayPanel.GetComponent<Image>();
                image.sprite = _swordFgSprite;
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
                break;
            case global::DisplayEquipment.Chest:
                break;
            case global::DisplayEquipment.Helmet:
                break;
        }
    }
}
