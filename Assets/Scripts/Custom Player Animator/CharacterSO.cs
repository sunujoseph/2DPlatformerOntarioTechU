using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/*
 * Scriptable Object holds our frames for every Animation Name for every Character within the Resources Folder
 * Resources Folder should have a folder called "Characters" within it
 * Characters Folder should have folders for each Character
 * Each Character Folder should have Animation Folders representing each animation we have for that character
 * Each Animation Folder should of contain frames(PNGs) of their animaton
 * 
 * Characters within the Character Folder can have any Name, Same goes for every animation
 * Character Folder Names are considered the name of our Characters (Ex. John, Alex, Sam)
 * Animation Folder Names are considered the name of our Animations (Ex. Walk, Run, Jump)
 * 
 * Folder Structure Example:
 * Resources
 *      - Characters
 *              - Character1
 *                  - Jump
 *                  - Walk
 *              - John
 *                  - Jump
 *                  - Walk
 *                  
 * The folder structure is important so Unity can find these folders to create our Scriptable Objects               
 */

[CreateAssetMenu(menuName = "character", fileName = "character")]
public class CharacterSO : ScriptableObject
{
    [System.Serializable]
    public class AnimationInfo
    {
        public string name;
        public List<Sprite> sprites;
    }


    public AnimationInfo[] animationInfo;

    public void BuildCharacter()
    {     
     

        for (int i = 0; i < animationInfo.Length; i++)
        {
            //Load from Resources Folder
            var loadedSprites = Resources.LoadAll("Characters/" + name + "/" + animationInfo[i].name, typeof(Sprite));
            animationInfo[i].sprites.Clear();
            foreach (var sprite in loadedSprites)
            {
                //Add animation sprites with it's corresponding animation name(animation folder name)
                //Debug.Log(sprite.name);
                animationInfo[i].sprites.Add((Sprite)sprite);
            }

        }
        
    }

}
