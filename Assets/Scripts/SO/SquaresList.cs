using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SquareList", menuName = "Square/SquareList")]
public class SquaresList : ScriptableObject
{
    public List<SquareModel> allSquares;
}

