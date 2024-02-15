using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneManagerON : MonoBehaviour
{

    FileManagerUpdate fileManagerUpdate = new FileManagerUpdate();
    RawImage newRawImage;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene()
    {
       

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
