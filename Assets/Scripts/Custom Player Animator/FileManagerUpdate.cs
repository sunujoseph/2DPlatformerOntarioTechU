using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using TMPro;


/*
 *  FileManagerUpdate along with CustomPlayerAnimator helps animate our character from our CharacterSO
 *  Saves animations from CharacterTracker's current CharacterSO
 *  Sends animations to CustomCharacterAnimator
 *  
 *  Attach to an empty object within the Game Scene
 *  Requires the player character object that contains CustomPlayerAnimator Script
 */

public class FileManagerUpdate : MonoBehaviour
{
    [SerializeField] private CustomPlayerAnimator playerAnimator;

    

    // Start is called before the first frame update
    void Start()
    {
 
        CharacterSO myCharacterSO = CharacterTracker.instance.getMyCharacter();

        for (int i = 0; i < myCharacterSO.animationInfo.Length; i++)
        {
            SaveAnimationFrames(myCharacterSO.animationInfo[i].name, myCharacterSO.animationInfo[i].sprites);
        }
    }
    
    //Save frames and create an animation
    public void SaveAnimationFrames(string animationName, List<Sprite> sprites)
    {
        
        if (sprites.Count > 0)
        {
            //Debug.Log(sprites.Count);
            playerAnimator.AddAnimation(animationName, sprites);
       
        }
    }



}
