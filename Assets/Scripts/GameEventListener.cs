using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
public class GameEventListener : MonoBehaviour
{
    public GameEvent myEvent;
    public UnityEvent callback;
    private void OnEnable()
    {
        //myEvent.Register(this);
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnDisable()
    {
        myEvent.Unregister(this);
    }
}