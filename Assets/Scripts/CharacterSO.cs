using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

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
        //string filePath = Application.dataPath + "/Characters/" + name;
        //string[] animationDirectories = Directory.GetDirectories(filePath);


        for (int i = 0; i < animationInfo.Length; i++)
        {
            var loadedSprites = Resources.LoadAll("Characters/" + name + "/" + animationInfo[i].name, typeof(Sprite));
            animationInfo[i].sprites.Clear();
            foreach (var sprite in loadedSprites)
            {
                Debug.Log(sprite.name);
                animationInfo[i].sprites.Add((Sprite)sprite);
            }

        }
        
    }

    /*IEnumerator buildCorotine()
    {
        for (int i = 0; i < animationDirectories.Length; i++)
        {

            string targetAnimationFolder = animationDirectories[i];
            string[] animationPaths = Directory.GetFiles(targetAnimationFolder);
            yield return StartCoroutine(loadImageArray(animationPaths, Path.GetFileName(targetAnimationFolder)));


        }
    }*/


}
