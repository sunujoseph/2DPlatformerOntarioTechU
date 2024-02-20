using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using AnotherFileBrowser.Windows;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class FileManagerUpdate : MonoBehaviour
{
    [SerializeField] private CustomPlayerAnimator playerAnimator;

    private List<Texture2D> loadedTextures = new List<Texture2D>();
    

    // Start is called before the first frame update


    void Start()
    {
        StartCoroutine(LoadAnimations());
        //LoadAnimationsFromResources();

    }

    void LoadAnimationsFromResources()
    {
        

        string targetCharacterFolder = CharacterTracker.instance.getMyPath();
        string[] AllAnimationFolders = Directory.GetDirectories(targetCharacterFolder);

        for (int i = 0; i < AllAnimationFolders.Length; i++)
        {

            string targetAnimationFolder = AllAnimationFolders[i];
            //string[] animationPaths = Directory.GetFiles(targetAnimationFolder);
            //yield return StartCoroutine(loadImageArray(animationPaths, Path.GetFileName(targetAnimationFolder)));
            Object[] objects = Resources.LoadAll(targetAnimationFolder, typeof(Sprite));

            for (int j = 0; j < objects.Length; j++)
            {
                Debug.Log(objects[j].name);
            }

        }
    }


    IEnumerator LoadAnimations()
    {

        

        if (CharacterTracker.instance == null) {

            yield break;
        }


        string targetCharacterFolder = CharacterTracker.instance.getMyPath();
        string[] AllAnimationFolders = Directory.GetDirectories(targetCharacterFolder);

        for (int i = 0; i < AllAnimationFolders.Length; i++)
        {

            string targetAnimationFolder = AllAnimationFolders[i];
            string[] animationPaths = Directory.GetFiles(targetAnimationFolder);
            yield return StartCoroutine(loadImageArray(animationPaths, Path.GetFileName(targetAnimationFolder)));
            

        }

    }

    

    IEnumerator LoadImage(string path)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(path))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                var uwrTexture = DownloadHandlerTexture.GetContent(uwr);
                loadedTextures.Add(uwrTexture);
                
            }
        }
    }

    

    

    IEnumerator loadImageArray(string[] paths, string animationName)
    {
        Debug.Log("loading " + animationName);
        for (int i = 0; i < paths.Length; i++)
        {
            yield return StartCoroutine(LoadImage(paths[i]));
        }

        SaveAnimationFrames(animationName);
        Debug.Log("saving " + animationName);


    }

    public void SaveAnimationFrames(string animationName)
    {
        //string animationName = animationNameInput.text;
        if (loadedTextures.Count > 0)
        {
            Debug.Log(loadedTextures.Count);
            playerAnimator.AddAnimation(animationName, loadedTextures);

            // clear loadedTextures
            loadedTextures.Clear();           
        }
    }



}
