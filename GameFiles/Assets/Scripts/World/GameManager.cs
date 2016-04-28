using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    #region Public Variables
    public GameTime mGameTime;
    public float TimeModifier;
    public const string IngameSpriteFileEnding = ".PNG";
    public const string EditorFilePathEnding = "/MapFiles/";
    #endregion

    #region Private Variables
    private float modifiedSeconds;
    private int Counter;
    #endregion


    void Start() {
        mGameTime = new GameTime(00, 00, 00, 00);
        modifiedSeconds = .0f;
        Counter = 60;
    }


    void Update() {
        UpdateTime();
    }

    //Everything in here is in Seconds or based on. Careful if you redo this.
    private void UpdateTime() {
        if(modifiedSeconds > Counter) {
            Counter += 60;
            mGameTime.AddMinutes(1);
        }
        modifiedSeconds = (Time.time * TimeModifier);
        mGameTime.UpdateTime();
        Debug.Log(mGameTime);
    }
}
