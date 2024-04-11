using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Character Tracker holds our CharacterSO we Selected within the Character Select Screen
 * The main purpose of this Script is merely to have an object Contain our CharacterSO across other game scenes
 */

public class CharacterTracker : MonoBehaviour
{
    private CharacterSO character;

    public static CharacterTracker instance;

    //Check to make sure we don't have duplicates of this instance
    // Destroy duplicates
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setMyCharacter(CharacterSO characterSO)
    {
        character = characterSO;
    }

    public CharacterSO getMyCharacter()
    {
        return character;
    }
}
