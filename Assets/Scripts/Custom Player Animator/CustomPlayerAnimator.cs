using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CustomPlayerAnimator : MonoBehaviour
{
    private Dictionary<string, List<Sprite>> animationFrames = new Dictionary<string, List<Sprite>>();

    //[SerializeField] private DynamicAnimationGen animationGen;

    [SerializeField] private SpriteRenderer mySpriteRenderer;

    [SerializeField]private float frameRate;
    private Coroutine currentAnimation;
    private string currentAnimationName;
   

    public void AddAnimation(string animationName, List<Sprite> listOfTextures )
    {
        if (animationFrames.ContainsKey(animationName))
        {
            // If the animation name already exists, replace its frames
            animationFrames[animationName] = new List<Sprite>(listOfTextures);
        }
        else
        {
            //add a new entry to the dictionary
            animationFrames.Add(animationName, new List<Sprite>(listOfTextures));
        }

        Debug.Log("Animation Frames Saved: ");
        foreach (var pair in animationFrames)
        {
            Debug.Log("Animation Name: " + pair.Key);
            Debug.Log("Frames Count: " + pair.Value.Count);

        }
    }

    public void PlayAnimation(string animationName, bool shouldInterupt = false)
    {
        if(currentAnimationName == animationName)
        {
            return;
        }

        if (currentAnimation!= null)
        {
            if (shouldInterupt)
            {
                StopCoroutine(currentAnimation);
                currentAnimation = null;
            }
            else
            {
                return;
            }

        }
        if (animationFrames.ContainsKey(animationName))
        {
            currentAnimation = StartCoroutine(playAnimationCoroutine(animationFrames[animationName].ToArray()));
            currentAnimationName = animationName;
        }
        
    }
    private IEnumerator playAnimationCoroutine(Sprite[] FilePics)
    {
        for (int i = 0; i < FilePics.Length; i++)
        {
            mySpriteRenderer.sprite = FilePics[i];
            //Debug.Log(i);
            yield return new WaitForSecondsRealtime(1f / frameRate);

        }
        currentAnimation = null;
        currentAnimationName = "";
    }
}
