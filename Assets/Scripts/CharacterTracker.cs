using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTracker : MonoBehaviour
{
    private CharacterSO character;

    public static CharacterTracker instance;


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
