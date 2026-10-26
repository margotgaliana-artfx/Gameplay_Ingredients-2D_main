using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
    bool inZoneE = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (inZoneE && Input.GetKey(KeyCode.E))
        {
            PlayerInventory.Instance.RemoveItemFromInventory("REDGEM");
            SceneManager.LoadScene("World 1-2");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerInventory.Instance.IsInInventory("REDGEM"))
            {
                inZoneE = true;
                InteractionUI.Instance.ShowInteraction("Game finished. Press E to finish the level.");
            }
            else if (!PlayerInventory.Instance.IsInInventory("REDGEM"))
            {
                inZoneE = true;
                InteractionUI.Instance.ShowInteraction("Go back to grab the gem.");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inZoneE = false;
            InteractionUI.Instance.HideInteraction();
        }
    }
}
