using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TrackName : MonoBehaviour
{
    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TMP_Text>().text = Base.Root.TranslatedContents[Settings.languageIndex].Topics[Settings.topicIndex].Media[1].Name;

    }
}
