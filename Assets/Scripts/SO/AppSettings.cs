using UnityEngine;

[CreateAssetMenu(fileName = "AppSettings", menuName = "Square/AppSettings")]
public class AppSettings : ScriptableObject
{

    [field: SerializeField, Header("Duration setting"), Tooltip("����� ������ ����������, ������� ����� ���������"), Range(1, 99)]
    public float ShowSequenceDuration { get; private set; } = 3;

    [field: SerializeField, Tooltip("��� �� ������� ����� ������ ����������, �����������")]
    public float ShowSequenceDurationStep { get; private set; } = 0.3f;

    [field: SerializeField]
    public float MaxShowSequenceDuration { get; private set; } = 99;

    [field: SerializeField]
    public float MinShowSequenceDuration { get; private set; } = 1.5f;

    [field: SerializeField, Tooltip("����� �� ���� ����������"), Range(1, 999)]
    public float MatchDuration { get; private set; } = 30;

    [field: SerializeField, Tooltip("���, �� ������� ����� �� ���� ����������, �����������")]
    public float MatchDurationStep { get; private set; } = 1;

    [field: SerializeField, Tooltip("������������ ����� �� ���� ����������")]
    public float MaxMatchDuration { get; private set; } = 999;

    [field: SerializeField, Tooltip("����������� ����� �� ���� ����������")]
    public float MinMatchDuration { get; private set; } = 5;


    [field: SerializeField, Header("Square setting"), Tooltip("����� ����������"), Range(1, 20)]
    public int SquareSequenceLenght { get; private set; } = 3;

    [field: SerializeField, Tooltip("���, �� ������� ����� ����������, �������������")]
    public int SequenceStep { get; private set; } = 1;

    [field: SerializeField, Tooltip("������������ ����� ����������")]
    public int MaxSquareInSequence { get; private set; } = 50;

    [field: SerializeField, Tooltip("���������� ������������ ������"), Range(1, 12)]
    public int UsableSquareCount { get; private set; } = 5;

    [field: SerializeField, Tooltip("���������� ����� ������������ ������")]
    public int SquareTypeCount { get; private set; } = 1;

    [field: SerializeField, Tooltip("���, �� ������� ���������� ����� ������������ ������, �������������")]
    public int SquareTypeCountStep { get; private set; } = 1;

    [field: SerializeField, Tooltip("������� �� ���� ����������"), Header("Reward")] public int RewardScore { get; private set; }
}
