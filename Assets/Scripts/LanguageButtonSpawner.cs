using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LanguageButtonSpawner : MonoBehaviour
{
    public GameObject languageButton;

    public Transform buttonHolder;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Base.Root.TranslatedContents.Count; i++)
        {
            var but = Instantiate(languageButton, buttonHolder);

            but.GetComponentInChildren<TMP_Text>().text = Base.Root.TranslatedContents[i].LanguageName;
            but.GetComponent<ButtonBirthCertificate>().langIdx = Base.Root.TranslatedContents[i].LanguageId - 1;

        }
    }

}
