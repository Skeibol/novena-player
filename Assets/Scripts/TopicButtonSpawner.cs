using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
public class TopicButtonSpawner : MonoBehaviour
{
    public GameObject topicButton;
    public Transform buttonHolder;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Base.Root.TranslatedContents[Settings.languageIndex].Topics.Count; i++)
        {
            var but = Instantiate(topicButton, buttonHolder);

            but.GetComponentInChildren<TMP_Text>().text = Base.Root.TranslatedContents[Settings.languageIndex].Topics[i].Name;

            but.GetComponent<ButtonBirthCertificate>().topicIdx = Base.Root.TranslatedContents[Settings.languageIndex].Topics[i].TopicId;

        }
    }


    

// Update is called once per frame
void Update()
    {
        
    }
}
