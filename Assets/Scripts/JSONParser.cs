using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class JSONParser : MonoBehaviour
{
    
    private string _path = "/data.json";

    private void Awake()
    {
        _path = Application.persistentDataPath + _path;
        var json = File.ReadAllText(_path);
        Root _root = JsonConvert.DeserializeObject<Root>(json);

        //Root _root = JsonUtility.FromJson<Root>(json);
        Base.Root = _root;
        Base.Root = _root;
    }
}
