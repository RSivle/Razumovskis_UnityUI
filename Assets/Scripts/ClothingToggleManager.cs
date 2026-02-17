using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClothingToggleManager : MonoBehaviour
{
    public GameObject itemsPanel;
    public TextMeshProUGUI buttonText;
    public string categoryName = "Bikses";
    private bool isVisible = false;

    private void Start()
    {
        itemsPanel.SetActive(false);
    }

    public void ToggleCategory()
    {
        isVisible = !isVisible;
        itemsPanel.SetActive(isVisible);
        buttonText.text = isVisible ? categoryName + " ▲" : categoryName + " ▼";
    }
}