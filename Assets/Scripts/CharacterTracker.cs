using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTracker : MonoBehaviour
{
    private string myPath;

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

    public void setMyPath(string currentPath)
    {
        myPath = currentPath;
    }

    public string getMyPath()
    {
        return myPath;
    }
}
