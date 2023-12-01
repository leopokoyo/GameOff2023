using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class WorldController : StateRunner<WorldController>
{
    
    public PlanetData planetData;

    private TextManager canvas;

    void Start(){

        SetState(typeof(DefaultWorldState));

        canvas = FindObjectOfType<TextManager>();

        //infoScreen.SetActive(false);
    }

    void OnMouseOver(){
        canvas.ChooseDisplay(this);
    }

    void OnMouseExit(){
        canvas.DeactivateDisplay();
    }

    private void OnEnable()
    {
        MainEventBus.NextDay += OnNewDay;
    }

   private void OnDisable()
    {
        MainEventBus.NextDay -= OnNewDay;
    }

  private void OnNewDay(object sender, int dayIndex)
    {
        _activeState.NewDay();
    }
}
