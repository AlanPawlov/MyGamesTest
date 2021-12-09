using UnityEngine;

[CreateAssetMenu(fileName = "Square", menuName = "Square/Square")]
public class SquareModel : ScriptableObject
{
    [field: SerializeField] public Color MyColor { get; private set; }
}
