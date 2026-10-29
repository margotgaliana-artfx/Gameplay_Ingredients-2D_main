using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
    bool inZoneE = false;

    public Canvas win;
    void Start()
    {
        
    }

    void Update()
    {
        if (inZoneE && Input.GetKey(KeyCode.E))
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("World 1-1"))
            {
                PlayerInventory.Instance.RemoveItemFromInventory("REDGEM");
                SceneManager.LoadScene("World 1-2");
            }

            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("World 1-2"))
                {
                PlayerInventory.Instance.RemoveItemFromInventory("REDGEM");
                PlayerInventory.Instance.RemoveItemFromInventory("GREENGEM");
                win.gameObject.SetActive(true);
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("World 1-1"))
            {
                if (PlayerInventory.Instance.IsInInventory("REDGEM"))
                {
                    inZoneE = true;
                    InteractionUI.Instance.ShowInteraction("Level finished. Press E to go to the next level.");
                }
                else if (!PlayerInventory.Instance.IsInInventory("REDGEM"))
                {
                    inZoneE = true;
                    InteractionUI.Instance.ShowInteraction("Go back to grab the gem.");
                }
            }

            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("World 1-2"))
            {
                if (PlayerInventory.Instance.IsInInventory("REDGEM") && PlayerInventory.Instance.IsInInventory("GREENGEM"))
                {
                    inZoneE = true;
                    InteractionUI.Instance.ShowInteraction("Game finished. Press E to finish the game.");//Les scripts d'interactions ne marchent pas dans le second niveau. Pourquoi?
                }
                else
                {
                    inZoneE = true;
                    InteractionUI.Instance.ShowInteraction("Go back to grab the gems.");
                }
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
