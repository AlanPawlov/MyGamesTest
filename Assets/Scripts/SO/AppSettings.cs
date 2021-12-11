using UnityEngine;

[CreateAssetMenu(fileName = "AppSettings", menuName = "Square/AppSettings")]
public class AppSettings : ScriptableObject
{

    [field: SerializeField, Header("Duration setting"), Tooltip("Время показа комбинации, которую нужно повторить"), Range(1, 99)]
    public float ShowSequenceDuration { get; private set; } = 3;

    [field: SerializeField, Tooltip("Шаг на который время показа комбинации, уменьшается")]
    public float ShowSequenceDurationStep { get; private set; } = 0.3f;

    [field: SerializeField]
    public float MaxShowSequenceDuration { get; private set; } = 99;

    [field: SerializeField]
    public float MinShowSequenceDuration { get; private set; } = 1.5f;

    [field: SerializeField, Tooltip("Время на сбор комбинации"), Range(1, 999)]
    public float MatchDuration { get; private set; } = 30;

    [field: SerializeField, Tooltip("Шаг, на который время на сбор комбинации, уменьшается")]
    public float MatchDurationStep { get; private set; } = 1;

    [field: SerializeField, Tooltip("Максимальное время на сбор комбинации")]
    public float MaxMatchDuration { get; private set; } = 999;

    [field: SerializeField, Tooltip("Минимальное время на сбор комбинации")]
    public float MinMatchDuration { get; private set; } = 5;


    [field: SerializeField, Header("Square setting"), Tooltip("Длина комбинации"), Range(1, 20)]
    public int SquareSequenceLenght { get; private set; } = 3;

    [field: SerializeField, Tooltip("Шаг, на который длина комбинации, увеличивается")]
    public int SequenceStep { get; private set; } = 1;

    [field: SerializeField, Tooltip("Максимальная длина комбинации")]
    public int MaxSquareInSequence { get; private set; } = 50;

    [field: SerializeField, Tooltip("Количество используемых блоков"), Range(1, 12)]
    public int UsableSquareCount { get; private set; } = 5;

    [field: SerializeField, Tooltip("Количество типов используемых блоков")]
    public int SquareTypeCount { get; private set; } = 1;

    [field: SerializeField, Tooltip("Шаг, на который количество типов используемых блоков, увеличивается")]
    public int SquareTypeCountStep { get; private set; } = 1;

    [field: SerializeField, Tooltip("Награда за сбор комбинации"), Header("Reward")] public int RewardScore { get; private set; }
}
