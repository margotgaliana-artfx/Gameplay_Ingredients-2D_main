using UnityEngine;

public class PortalScript : MonoBehaviour
{

    bool inZone = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inZone && Input.GetKeyDown(KeyCode.R)) // Je peux supprimer le portail meme si l'interaction n'est pas la.
        {
            gameObject.SetActive(false);
            PlayerInventory.Instance.RemoveItemFromInventory("GREENKEY");
            PlayerInventory.Instance.RemoveItemFromInventory("ORANGEKEY");
            PlayerInventory.Instance.RemoveItemFromInventory("YELLOWKEY");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inZone = true;
            if (PlayerInventory.Instance.IsInInventory("GREENKEY") && PlayerInventory.Instance.IsInInventory("ORANGEKEY") && PlayerInventory.Instance.IsInInventory("YELLOWKEY"))
            {
                Debug.Log("YAY t'as les clés");
                InteractionUI.Instance.ShowInteraction("You have every keys. You can pass. Press - R."); //Les scripts d'interactions ne marchent pas dans le second niveau. Pourquoi?
            }

            else 
            {
                Debug.Log("T'as pas les clés frerot...");
                InteractionUI.Instance.ShowInteraction("You don't have every keys. Go grab them.");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inZone = false;
            InteractionUI.Instance.HideInteraction();
        }
    }
}
