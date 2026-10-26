using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    public static InteractionUI Instance;

    public TextMeshProUGUI interactionText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowInteraction(string text)
    {
        interactionText.gameObject.SetActive(true);
        interactionText.text = text;
    }

    public void HideInteraction()
    {
        interactionText.gameObject.SetActive(false);
    }
}
