using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GameObject bridge;
    public Sprite repairedLever;

    bool inZone = false;
    bool repaired = false;
    bool activated = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inZone == true && Input.GetKeyDown(KeyCode.R))
        {
            if (!repaired)
            {
                Debug.Log("tu as réparé le levier");
                GetComponent<SpriteRenderer>().sprite = repairedLever;
                PlayerInventory.Instance.RemoveItemFromInventory("LEVERHANDLE");
                InteractionUI.Instance.ShowInteraction("Use the lever - R");
                repaired = true;
                GetComponent<Animator>().SetTrigger("repaired");
            }
            else
            {
                Debug.Log("ggwp");
                InteractionUI.Instance.HideInteraction();
                gameObject.GetComponent<Animator>().SetTrigger("using");
                activated = true;
                GetComponent<Animator>().SetTrigger("used");
                bridge.GetComponent<Animator>().SetTrigger("Down");
            }

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (PlayerInventory.Instance.IsInInventory("LEVERHANDLE")||repaired)
            {
                Debug.Log("Tu as le levier");            
                inZone = true;
                InteractionUI.Instance.ShowInteraction("Press R to interact");                
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
