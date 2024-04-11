using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

/*
 * Custom Player Animator
 * Gets the our animation frames from FileManagerUpdate's CharacterSO
 * Handles how our animations are played on our Character
 * 
 * This script is attached to the Player Character
 * This script also requires the Player Character's Sprite Renderer
 * 
 * To play animations
 * Create a CustomPlayerAnimator variable within this script 
 * (Ex. public CustomPlayerAnimator playerAnimator)
 * 
 * To play an animation simply use the following function:
 * playerAnimator.PlayAnimation(string "AnimationName", bool ShouldInterrupt);
 * AnimationName is the name of the animation, same name of your animation folders
 * ShouldInterrupt is whether you want to Interrupt and Stop a currently playing animation
 * to play a new animation
 * ShouldInterrupt is considered false by default
 */

public class CustomPlayerAnimator : MonoBehaviour
{
    private Dictionary<string, List<Sprite>> animationFrames = new Dictionary<string, List<Sprite>>();


    [SerializeField] private SpriteRenderer mySpriteRenderer;

    [SerializeField]private float frameRate;
    private Coroutine currentAnimation;
    private string currentAnimationName;
   
    //Add new Animation to this Character from Animation Folders
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

        //Debug to Check if animations are saved
        Debug.Log("Animation Frames Saved: ");
        foreach (var pair in animationFrames)
        {
            Debug.Log("Animation Name: " + pair.Key);
            Debug.Log("Frames Count: " + pair.Value.Count);

        }

    }

    //Play animation from Animation Frames
    //Call function to play animation
    public void PlayAnimation(string animationName, bool shouldInterrupt = false)
    {
        if(currentAnimationName == animationName)
        {
            return;
        }

        if (currentAnimation!= null)
        {
            if (shouldInterrupt)
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
