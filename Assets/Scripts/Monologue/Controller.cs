using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _text;
    [SerializeField] protected LevelFinder _levelFinder;
    [SerializeField] protected UnityEvent _action;
    [SerializeField] protected GameObject _panel;

    protected StringArray tempArray;
    protected int level;
    protected int count;
    protected int _index;
    protected bool[] _repeated;

    public void Awake()
    {
        count = 0;
        level = SceneManager.GetActiveScene().buildIndex - 1;
        _repeated = new bool[_levelFinder.Level[level].Text.Length];
        for (int i = 0; i < _repeated.Length; i++)
        {
            _repeated[i] = false;
        }
    }

    public virtual void ShowText(int index)
    {
        _index = index;
        if (_repeated[_index])
        {
            return;
        }
        _panel.SetActive(true);
        tempArray = _levelFinder.Level[level].Text[_index];
    }
}
