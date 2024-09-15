using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  Interectable 
{
    GameObject Player { get; set; }
    bool CanInteract {  get; set; }
    void Interact();
}
