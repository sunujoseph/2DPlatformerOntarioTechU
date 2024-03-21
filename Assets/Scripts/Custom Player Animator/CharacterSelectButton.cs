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

    CharacterSO myCharacter;


    public void Intialize(CharacterSO characterSO)
    {
        //Non-WebGL Code
        //string idleFolderPath = path + "/Idle";
        //myPath = path;
        //string[] thumbNails = Directory.GetFiles(idleFolderPath);
        //StartCoroutine(LoadThumbnailImage(thumbNails[0]));

        thumbnailImage.texture = characterSO.animationInfo[0].sprites[0].texture;
        myCharacter = characterSO;
       
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
        CharacterTracker.instance.setMyCharacter(myCharacter);


        // load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   
}
