using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCreator : MonoBehaviour

{
    [Header("Teksta lauki")]
    public TMP_InputField nameInputField;
    public TMP_InputField birthYearInputField;
    public TextMeshProUGUI resultText;

    [Header("Poga un audio")]
    public AudioSource buttonClickSound;

    // Pogas 'Apstiprināt' On Click izsauc šo
    public void OnConfirmButton()
    {
        // Atskaņo skaņu
        if (buttonClickSound != null)
            buttonClickSound.Play();

        // Iegūst ievadītās vērtības
        string heroName = nameInputField.text.Trim();
        string yearText = birthYearInputField.text.Trim();

        // Pārbauda, vai lauki nav tukši
        if (string.IsNullOrEmpty(heroName))
        {
            resultText.text = "Lūdzu ievadiet tēla vārdu!";
            resultText.color = Color.red;
            return;
        }
        if (string.IsNullOrEmpty(yearText))
        {
            resultText.text = "Lūdzu ievadiet dzimšanas gadu!";
            resultText.color = Color.red;
            return;
        }

        // Konvertē tekstu uz skaitli
        if (!int.TryParse(yearText, out int birthYear))
        {
            resultText.text = "Nepareizs dzimšanas gads!";
            resultText.color = Color.red;
            return;
        }

        // Aprēķina vecumu
        int currentYear = System.DateTime.Now.Year;
        int age = currentYear - birthYear;

        // Pārbauda saprātīgu vecumu
        if (age < 0 || age > 150)
        {
            resultText.text = "Lūdzu ievadiet pareizu gadu!";
            resultText.color = Color.red;
            return;
        }

        // Parāda rezultātu
        resultText.text = $"Varonis {heroName} ir {age} gadus vecs!";
        resultText.color = Color.white;
    }
}

