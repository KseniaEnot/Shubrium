using UnityEngine;

[CreateAssetMenu(menuName ="SO/TextMonologue")]
public class TextSO : ScriptableObject
{
    public StringArray[] Text => _text;
    [SerializeField] private StringArray[] _text;
}
