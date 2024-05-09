using UnityEngine;

[CreateAssetMenu(menuName = "SO/LevelFinder")]
public class LevelFinder : ScriptableObject
{
    public TextSO[] Level => _level;
    [SerializeField] private TextSO[] _level;
}
