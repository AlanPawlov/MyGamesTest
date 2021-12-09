using UnityEngine;

[CreateAssetMenu(fileName = "GameRules", menuName = "Square/GameRules")]
public class GameRules : ScriptableObject
{
    [field: SerializeField, Header("Duration setting"), Range(1, 99)] public float ShowSequenceDuration { get; private set; }
    [field: SerializeField] public float ShowSequenceDurationStep { get; private set; }
    [field: SerializeField, Range(1, 999)] public float MatchDuration { get; private set; }
    [field: SerializeField] public float MatchDurationStep { get; private set; }

    [field: SerializeField, Header("Controlls setting"), Range(1, 20)] public int SquareSequenceLenght { get; private set; }
    [field: SerializeField] public int SequenceStep { get; private set; }
    [field: SerializeField, Range(1, 12)] public int UsableSquareCount { get; private set; }
    [field: SerializeField] public int UsableSquareCountStep { get; private set; }
}
