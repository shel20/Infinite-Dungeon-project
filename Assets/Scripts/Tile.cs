using UnityEngine;


[System.Serializable]
public class Tile
{

    public Transform tile;
    public Transform origin;
    public Connector connector;

    public Tile(Transform _tile, Transform _origin)
    {
        tile = _tile;
        origin = _origin;
    }
}
