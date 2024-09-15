using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;


public class DoorTriggerInteraction : TriggerInteractionBase
{

    [SerializeField] private Object _sceneToLoad;
    [SerializeField] private string _sceneTransitionName;
    public override void Interact()
    {

        //Debug.Log(SceneSwapManager.Instance);
        SwapSceneManager.Instance.ChangeScene(_sceneToLoad.name);
        SwapSceneManager.Instance.SetTransitionName(_sceneTransitionName);


    }
}
