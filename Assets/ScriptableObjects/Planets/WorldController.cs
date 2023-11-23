using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class WorldController : StateRunner<WorldController>
{
    
    public PlanetData planetData;

    void Start(){

        SetState(typeof(DefaultWorldState));

        //infoScreen.SetActive(false);
    }

    void OnMouseOver(){
        //infoScreen.SetActive(true);
    }

    void OnMouseExit(){
        //infoScreen.SetActive(false);
    }
}
