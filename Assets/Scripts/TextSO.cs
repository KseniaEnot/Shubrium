using UnityEngine;

[CreateAssetMenu(menuName ="SO/TextMonologue")]
public class TextSO : ScriptableObject
{
    public string Text => _text;
    [SerializeField] private string _text;
}
