using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.TextCore.Text;


public class CharacterLoader : MonoBehaviour
{
    string filePath;
    [SerializeField] private CharacterSelectButton buttonPrefab;
    [SerializeField] private Transform contents;
    [SerializeField] private CharacterSO[] characterFiles;

    // Start is called before the first frame update
    void Start()
    {
        //filePath = Application.dataPath + "/Characters/";
        //filePath = Path.Combine(Application.streamingAssetsPath) + "/Characters/";
        
        //Debug.Log(filePath);

        //string[] characterDirectories = Directory.GetDirectories(filePath);

        for (int i = 0; i < characterFiles.Length; i++)
        {
            CharacterSelectButton spawnedPrefab = Instantiate(buttonPrefab, contents);
            spawnedPrefab.Intialize(characterFiles[i]);
        }
    }


}
