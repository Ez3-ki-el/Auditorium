using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "new ScriptableVariable", menuName = "Variable", order = 0)]
public class ScriptableVariable : ScriptableObject
{
    public int value;
    public string playerName;

    public void Test()
    {
        Debug.Log( $"je suis {playerName}" );
    }
}
