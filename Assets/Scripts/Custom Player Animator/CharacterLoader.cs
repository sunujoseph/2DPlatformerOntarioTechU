using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.TextCore.Text;

/*
 * Character Loader gets our CharacterSOs and loads them within a Character Select Screen
 * 
 * We take a Button Prefab with our Character Select Button Script
 * contents is our UI Layout where we will populate our Button Prefab
 * characterFiles is our CharacterSOs to be applied within our Button Prefab
 */


public class CharacterLoader : MonoBehaviour
{
    string filePath;
    [SerializeField] private CharacterSelectButton buttonPrefab;
    [SerializeField] private Transform contents;
    [SerializeField] private CharacterSO[] characterFiles;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < characterFiles.Length; i++)
        {
            CharacterSelectButton spawnedPrefab = Instantiate(buttonPrefab, contents);
            spawnedPrefab.Intialize(characterFiles[i]);
        }
    }


}
