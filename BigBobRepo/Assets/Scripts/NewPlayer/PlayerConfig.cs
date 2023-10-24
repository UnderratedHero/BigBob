using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerConfig", menuName ="Config/PlayerConfig", order = 51)]
public class PlayerConfig : ScriptableObject
{
    [field: SerializeField] public float JumpSpeed { get; private set; } = 0f;

    [field: SerializeField] public float MoveSpeed { get; private set; } = 0f;
}
