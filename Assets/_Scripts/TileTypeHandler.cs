using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TileType
{
    normal=1,
    password=3,
}

public class TileTypeHandler : MonoBehaviour
{
    public TileType type;
}
