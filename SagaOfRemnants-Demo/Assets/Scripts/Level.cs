using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public GameObject VirtualCamera;
    public GameObject LevelNameDialogBox;
    public string LevelName = "Missing LevelName";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            StartCoroutine(DisplayLevelNameCo());
            VirtualCamera.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            VirtualCamera.SetActive(false);
        }
    }

    private IEnumerator DisplayLevelNameCo()
    {
        LevelNameDialogBox.GetComponentInChildren<Text>().text = LevelName;
        LevelNameDialogBox.SetActive(true);
        yield return new WaitForSeconds(4);
        LevelNameDialogBox.SetActive(false);
    }
}
