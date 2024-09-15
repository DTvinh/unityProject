using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Entrace : MonoBehaviour
{
    [SerializeField] private string transitionName;
    private void Start()
    {
        if (transitionName == SwapSceneManager.Instance.sceneTransitionName)
        {
            PlayerController.Instance.transform.position = this.transform.position;
        }
    }
}
