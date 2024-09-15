using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapSceneManager : Singleton<SwapSceneManager>
{
    // Start is called before the first frame update
    [SerializeField] public string sceneTransitionName { get; set;}
    public void SetTransitionName(string transitionName)
    {
        sceneTransitionName = transitionName;
    }

    protected override void Awake()
    {
        base.Awake();

    }

    public void ChangeScene( string nameScene)
    {
        SceneManager.LoadScene(nameScene);
        //StartCoroutine(SwapScene(nameScene));    
    } 


    IEnumerator SwapScene(string nameScene)
    {
        yield return null;
        SceneManager.LoadScene(nameScene);
    }

    
}
