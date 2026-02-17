using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelector : MonoBehaviour
{
    [Header("Tēlu objekti (Images ainā)")]
    public GameObject[] characterObjects;

    [Header("UI elementi")]
    public TMP_Dropdown characterDropdown;
    public TextMeshProUGUI descriptionText;

    [Header("Sliders")]
    public Slider heightSlider;
    public Slider widthSlider;

    [Header("Audio")]
    public AudioSource characterAudio;
    public AudioClip[] characterSounds; // Po vienai skaņai katram tēlam

    // Tēlu apraksti — mainī uz saviem tekstiem!
    private readonly string[] descriptions =
    {
        "Vel Parkt — spēcīgākais varonis Rīgā! Viņš ir apguvis " +
        "seno bruņinieku mākslu un prot saceļties pat pret pūķiem. " +
        "Dzimis 1990. gadā mazā ciemā pie Daugavas, Vel Parkt " +
        "sāka savu ceļu kā tirgotāja māceklis, bet likteņa pavērsieni " +
        "viņu aizveda uz lielām piedzīvojumu pasaulēm.",

        "Cietoksnis — nepievaramais sargsargs ar dzelzs gribasspēku. " +
        "Viņš nekad nav pazaudējis nevienu kauju un " +
        "nepadodas pat visnelabvēlīgākajos apstākļos. " +
        "Komanda var paļauties uz Cietoksni kā uz klinti.",

        "Zibens Maks — ātrākais varonis visās zemēs! " +
        "Viņš pārvietojas ar zibens ātrumu un prot redzēt " +
        "notikumus pirms tie notiek. Maks ir labākais taktikis " +
        "un palīdz komandai spert pareizo soli katru reizi."
    };

    private void Start()
    {
        // Abonē dropdown izmaiņas
        characterDropdown.onValueChanged.AddListener(OnCharacterChanged);

        // Slider notikumi
        if (heightSlider != null)
            heightSlider.onValueChanged.AddListener(OnHeightChanged);
        if (widthSlider != null)
            widthSlider.onValueChanged.AddListener(OnWidthChanged);

        // Sāk ar pirmo tēlu
        OnCharacterChanged(0);
    }

    private void OnCharacterChanged(int index)
    {
        // Rāda tikai izvēlēto tēlu
        for (int i = 0; i < characterObjects.Length; i++)
            characterObjects[i].SetActive(i == index);

        // Atjauno aprakstu
        if (index < descriptions.Length)
            descriptionText.text = descriptions[index];

        // Atskaņo tēla skaņu
        if (characterAudio != null && index < characterSounds.Length
            && characterSounds[index] != null)
        {
            characterAudio.clip = characterSounds[index];
            characterAudio.Play();
        }

        // Atiestatī slider vērtības uz 1
        if (heightSlider != null) heightSlider.value = 1f;
        if (widthSlider != null) widthSlider.value = 1f;

        // Atiestatī tēla mērogu
        if (index < characterObjects.Length)
        {
            characterObjects[index].transform.localScale = Vector3.one;
        }
    }

    private void OnHeightChanged(float value)
    {
        int idx = characterDropdown.value;
        if (idx >= characterObjects.Length) return;
        Vector3 s = characterObjects[idx].transform.localScale;
        s.y = value;
        characterObjects[idx].transform.localScale = s;
    }

    private void OnWidthChanged(float value)
    {
        int idx = characterDropdown.value;
        if (idx >= characterObjects.Length) return;
        Vector3 s = characterObjects[idx].transform.localScale;
        s.x = value;
        characterObjects[idx].transform.localScale = s;
    }
}
