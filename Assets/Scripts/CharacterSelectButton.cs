using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectButton : MonoBehaviour
{
    [SerializeField] private RawImage thumbnailImage;

    string myPath;


    public void Intialize(string path)
    {
        string idleFolderPath = path + "/Idle";

        myPath = path;

        string[] thumbNails = Directory.GetFiles(idleFolderPath);

        StartCoroutine(LoadThumbnailImage(thumbNails[0]));

       
    }

    IEnumerator LoadThumbnailImage(string path)
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
                thumbnailImage.texture = uwrTexture;

            }
        }
    }


    public void OnClick()
    {
        // tell character tracker the correct file path
        CharacterTracker.instance.setMyPath(myPath);


        // load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   
}
