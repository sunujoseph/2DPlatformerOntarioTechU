using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicAnimationGen : MonoBehaviour
{
    

   

    public List<Sprite> GenerateAnimation(Texture2D[] textures)
    {
        List<Sprite> results = new List<Sprite>();


        for (int i = 0; i < textures.Length; i++)
        {
            results.Add(Sprite.Create(textures[i], new Rect(0, 0, textures[i].width, textures[i].height), new Vector2(0.5f, 0.5f)));
        }

        return results;
    }
}
