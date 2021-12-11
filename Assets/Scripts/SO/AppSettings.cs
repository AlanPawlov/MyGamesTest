using UnityEngine;

[CreateAssetMenu(fileName = "AppSettings", menuName = "Square/AppSettings")]
public class AppSettings : ScriptableObject
{

    [field: SerializeField, Header("Duration setting"), Tooltip("����� ������ ����������, ������� ����� ���������"), Range(1, 99)]
    public float ShowSequenceDuration { get; private set; }

    [field: SerializeField, Tooltip("��� �� ������� ����� ������ ����������, �����������")]
    public float ShowSequenceDurationStep { get; private set; }

    [field: SerializeField]
    public float MaxShowSequenceDuration { get; private set; }

    [field: SerializeField]
    public float MinShowSequenceDuration { get; private set; }
    
    [field: SerializeField, Tooltip("����� �� ���� ����������"), Range(1, 999)]
    public float MatchDuration { get; private set; }
    
    [field: SerializeField, Tooltip("���, �� ������� ����� �� ���� ����������, �����������")]
    public float MatchDurationStep { get; private set; }
    
    [field: SerializeField, Tooltip("������������ ����� �� ���� ����������")] 
    public float MaxMatchDuration { get; private set; }
    
    [field: SerializeField, Tooltip("����������� ����� �� ���� ����������")] 
    public float MinMatchDuration { get; private set; }


    [field: SerializeField, Header("Square setting"), Tooltip("����� ����������"), Range(1, 20)] 
    public int SquareSequenceLenght { get; private set; }
    
    [field: SerializeField, Tooltip("���, �� ������� ����� ����������, �������������")] 
    public int SequenceStep { get; private set; }
    
    [field: SerializeField, Tooltip("������������ ����� ����������")] 
    public int MaxSquareInSequence { get; private set; }
    
    [field: SerializeField, Tooltip("���������� ������������ ������"), Range(1, 12)] 
    public int UsableSquareCount { get; private set; }

    [field: SerializeField, Tooltip("���������� ����� ������������ ������")] 
    public int SquareTypeCount { get; private set; }
    
    [field: SerializeField, Tooltip("���, �� ������� ���������� ����� ������������ ������, �������������")]
    public int SquareTypeCountStep { get; private set; }

    [field: SerializeField, Tooltip("������� �� ���� ����������"), Header("Reward")] public int RewardScore { get; private set; }
}
