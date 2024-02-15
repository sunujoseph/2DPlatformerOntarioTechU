using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CustomPlayerAnimator : MonoBehaviour
{
    private Dictionary<string, List<Sprite>> animationFrames = new Dictionary<string, List<Sprite>>();

    [SerializeField] private DynamicAnimationGen animationGen;

    [SerializeField] private SpriteRenderer mySpriteRenderer;

    [SerializeField]private int frameRate;
    private Coroutine currentAnimation;

   

    public void AddAnimation(string animationName, List<Texture2D> listOfTextures )
    {
        if (animationFrames.ContainsKey(animationName))
        {
            // If the animation name already exists, replace its frames
            animationFrames[animationName] = animationGen.GenerateAnimation(listOfTextures.ToArray());
        }
        else
        {
            //add a new entry to the dictionary
            animationFrames.Add(animationName, animationGen.GenerateAnimation(listOfTextures.ToArray()));
        }

        Debug.Log("Animation Frames Saved: ");
        foreach (var pair in animationFrames)
        {
            Debug.Log("Animation Name: " + pair.Key);
            Debug.Log("Frames Count: " + pair.Value.Count);

        }
    }

    public void PlayAnimation(string animationName)
    {
        if (currentAnimation!= null)
        {
           // StopCoroutine(currentAnimation);
            //currentAnimation = null;
            return;
        }
        if (animationFrames.ContainsKey(animationName))
        {
            currentAnimation = StartCoroutine(playAnimationCoroutine(animationFrames[animationName].ToArray()));
        }
        
    }
    private IEnumerator playAnimationCoroutine(Sprite[] FilePics)
    {
        for (int i = 0; i < FilePics.Length; i++)
        {
            mySpriteRenderer.sprite = FilePics[i];
            //Debug.Log(i);
            yield return new WaitForSecondsRealtime(1 / frameRate);

        }
        currentAnimation = null;
    }
}
