using System.Collections;
using System.Collections.Generic;

using UnityEngine;
[CreateAssetMenu(fileName = "new GameEvent", menuName = "Scriptables/GameEvent")]
public class GameEvent : ScriptableObject
{
    List<GameEventListener> listeners;
    public void Register(GameEventListener listener)
    {
        listeners.Add(listener);
    }
    public void Unregister(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
    public void Trigger()
    {
        foreach (GameEventListener listener in listeners)
        {
            listener.callback.Invoke();
        }
    }
}