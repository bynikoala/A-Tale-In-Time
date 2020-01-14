using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInGhost : StateMachineBehaviour
{

    public string GameObjectName;

    void OnStateEnter()
    {

        GameObject go = GameObject.Find(GameObjectName);


        go.GetComponent<fadeCharacter>().fadeInGhost();



    }
}
