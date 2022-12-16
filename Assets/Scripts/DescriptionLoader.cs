using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DescriptionLoader : MonoBehaviour
{

    void Start()
    {
        this.GetComponent<TMP_Text>().text = Base.Root.TranslatedContents[Settings.languageIndex].Topics[Settings.topicIndex].Description;
    }

    public void SetDescription()
    {
        this.GetComponent<TMP_Text>().text = Base.Root.TranslatedContents[Settings.languageIndex].Topics[Settings.topicIndex].Description;
    }
}
