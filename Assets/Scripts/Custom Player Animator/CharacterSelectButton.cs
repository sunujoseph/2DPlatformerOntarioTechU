using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * This Script goes on a Button Prefab
 * Character Select Button will take our CharacterSO from our CharacterLoader Script
 * It will also take the first frame from the first animation within our CharacterSO 
 * Using it as a Thumbnail for the button
 * 
 * On Clicking the button
 * we store our CharacterSO we selected into our Character Tracker instance object
 * as well move to next scene
 */

public class CharacterSelectButton : MonoBehaviour
{
    [SerializeField] private RawImage thumbnailImage;

    CharacterSO myCharacter;


    public void Intialize(CharacterSO characterSO)
    {
        // get a thumbnail from first animation's first frame
        thumbnailImage.texture = characterSO.animationInfo[0].sprites[0].texture;

        // load CharacterSO within variable
        myCharacter = characterSO;
       
    }



    public void OnClick()
    {
        // tell character tracker the correct file path
        CharacterTracker.instance.setMyCharacter(myCharacter);


        // load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   
}
