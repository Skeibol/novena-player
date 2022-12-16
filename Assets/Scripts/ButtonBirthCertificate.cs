using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBirthCertificate : MonoBehaviour
{
    public int langIdx;
    public int topicIdx;

    public void updateLanguage()
    {
        Settings.languageIndex = langIdx;

        
    }
    public void updateTopic()
    {
        Settings.topicIndex = topicIdx;
        
    }

}
