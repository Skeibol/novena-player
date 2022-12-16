using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings
{
    public static int languageIndex = 0;
    public static int topicIndex = 0;
    public void SetLang(int idx)
    {
        languageIndex = idx;
    }
    public void SetTopic(int idx)
    {
        topicIndex = idx;
    }

}

