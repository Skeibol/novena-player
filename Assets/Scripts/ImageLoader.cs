using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class ImageLoader : MonoBehaviour
{
    
   
    private RawImage im;
    private int imageIdx = 0;
    public float interpolationPeriod = 0.05f;

    public void Start()
    {
        im = this.GetComponent<RawImage>();
        Texture2D tex = new Texture2D(2, 2);
        var _path = string.Format("{0}", Application.persistentDataPath + Base.Root.TranslatedContents[Settings.languageIndex].Topics[Settings.topicIndex].Media[0].Photos[imageIdx].Path);
        
        var img = LoadPNG(_path);
        im.texture = img;
        StartCoroutine(DoEveryFiveSeconds());
    }

    public void ChangeArtist()
    {
        StopAllCoroutines();
        im = this.GetComponent<RawImage>();
        Texture2D tex = new Texture2D(2, 2);
        var _path = string.Format("{0}", Application.persistentDataPath + Base.Root.TranslatedContents[Settings.languageIndex].Topics[Settings.topicIndex].Media[0].Photos[imageIdx].Path);

        var img = LoadPNG(_path);
        im.texture = img;
        StartCoroutine(DoEveryFiveSeconds());
    }


    IEnumerator DoEveryFiveSeconds()
    {

        yield return new WaitForSeconds(5f);
        DoSomething();
        StartCoroutine(DoEveryFiveSeconds());
    }


    void DoSomething()
    {
        imageIdx += 1;
        if (imageIdx == Base.Root.TranslatedContents[Settings.languageIndex].Topics[Settings.topicIndex].Media[0].Photos.Count)
        {
            imageIdx = 0;
        }
        Texture2D tex = new Texture2D(2, 2);
        var _path = string.Format("{0}", Application.persistentDataPath + Base.Root.TranslatedContents[Settings.languageIndex].Topics[Settings.topicIndex].Media[0].Photos[imageIdx].Path);
        var img = LoadPNG(_path);
        im.texture = img;
    }
    public static Texture2D LoadPNG(string filePath)
    {

        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); 
        }
        return tex;
    }
}
