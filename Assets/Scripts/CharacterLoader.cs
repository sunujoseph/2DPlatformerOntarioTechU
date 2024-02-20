using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CharacterLoader : MonoBehaviour
{
    string filePath;
    [SerializeField] private CharacterSelectButton buttonPrefab;
    [SerializeField] private Transform contents;

    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.dataPath+"/Characters/";
        //Debug.Log(filePath);

        string[] characterDirectories = Directory.GetDirectories(filePath);

        for (int i = 0; i < characterDirectories.Length; i++)
        {
            CharacterSelectButton spawnedPrefab = Instantiate(buttonPrefab, contents);
            spawnedPrefab.Intialize(characterDirectories[i]);

            //Debug.Log(characterDirectories[i]);
        }
    }


}
