using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "new " + nameof( IntVariable ), menuName = ScriptableUtils.VARIABLE_PATH + nameof( IntVariable ) )]
public class IntVariable : BaseVariable<int>
{
}
