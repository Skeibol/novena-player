using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    private List<string> clips;
    private string _path;
    private AudioSource _audio;
    public TMP_Text trackName;

    public void Shuffle()
    {
        var picker = Random.Range(0, clips.Count);
        _path = string.Format(@"{0}", Application.persistentDataPath + "/Music/RandomPlaylist/" + clips[picker]);
        print(_path);
        LoadSong(true);
        
    }
    public void startTrack()
    {
        _audio.Play();
    }
    public void stopTrack()
    {
        _audio.Pause();
    }
    public void nextTrack()
    {
        Settings.topicIndex += 1;
        if(Settings.topicIndex == Base.Root.TranslatedContents[Settings.languageIndex].Topics.Count)
        {
            Settings.topicIndex = 0;
        }
        _path = string.Format("file://{0}", Application.persistentDataPath + Base.Root.TranslatedContents[Settings.languageIndex].Topics[Settings.topicIndex].Media[1].FilePath);

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            LoadSong(true);
        }
        else
        {
            LoadSong(false);
        }
    }
    public void prevTrack()
    {
        Settings.topicIndex -= 1;
        if (Settings.topicIndex == -1)
        {
            Settings.topicIndex = Base.Root.TranslatedContents[Settings.languageIndex].Topics.Count - 1;
        }
        _path = string.Format("file://{0}", Application.persistentDataPath + Base.Root.TranslatedContents[Settings.languageIndex].Topics[Settings.topicIndex].Media[1].FilePath);
        _audio.time = 0;
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            LoadSong(true);
        }
        else
        {
            LoadSong(false);
        }
    }
    void Awake()
    {
        _audio = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            GetFilesInFolder();
            var picker = Random.Range(0, clips.Count);
            _path = string.Format(@"{0}", Application.persistentDataPath + "/Music/RandomPlaylist/" + clips[picker]);
            LoadSong(true);
        }
        else
        {
            _path = string.Format("file://{0}", Application.persistentDataPath + Base.Root.TranslatedContents[Settings.languageIndex].Topics[Settings.topicIndex].Media[1].FilePath);
            LoadSong(false);
        }
    }
    public void LoadSong(bool inPlayer)
    {
        StartCoroutine(GetAudioClip(_path, inPlayer));
    }

    IEnumerator GetAudioClip(string fullPath,bool inPlayer)
    {
        using (var uwr = UnityWebRequestMultimedia.GetAudioClip(fullPath, AudioType.MPEG))
        {
            ((DownloadHandlerAudioClip)uwr.downloadHandler).streamAudio = false;

            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                yield break;
            }

            DownloadHandlerAudioClip dlHandler = (DownloadHandlerAudioClip)uwr.downloadHandler;

            if (dlHandler.isDone)
            {
                _audio.clip = dlHandler.audioClip;

                if (_audio.clip != null)
                {
                    _audio.clip = DownloadHandlerAudioClip.GetContent(uwr);
                    _audio.Play();
                    _audio.time = 0f;
                    if (inPlayer)
                    {
                    var trackList = Path.GetFullPath(fullPath).TrimEnd(Path.DirectorySeparatorChar);
                    var track = trackList.Split(Path.DirectorySeparatorChar).Last();
                    trackName.text = track;

                    }
                    Debug.Log("Playing song using Audio Source!");
                }
                else
                {
                    Debug.Log("Couldn't find a valid AudioClip.");
                }
            }
            else
            {
                Debug.Log("The download process is not completely finished.");
            }
        }
    }
    public void GetFilesInFolder()
    {
        var _path = string.Format(@"{0}", Application.persistentDataPath + "/Music/RandomPlaylist/");
        DirectoryInfo d = new DirectoryInfo(_path); //Assuming Test is your Folder

        FileInfo[] Files = d.GetFiles("*.mp3"); //Getting Text files
        string str = "";
        clips = new List<string>();
        foreach (FileInfo file in Files)
        {
            str = file.Name;
            clips.Add(str);
        }
    }

}
