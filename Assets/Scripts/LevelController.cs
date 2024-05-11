using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private GameObject _button;
    [SerializeField] private LevelFinder _levelFinder;
    [SerializeField] private Move _player;
    [SerializeField] private UnityEvent _action;
    [SerializeField] private float _secondsForSkip = 2f;

    private int level;
    private int count;
    private int _index;
    private bool[] _repeated;
    private bool _workAction = true;

    public void Awake()
    {
        Init();
    }

    public void Init()
    {
        count = 0;
        level = SceneManager.GetActiveScene().buildIndex - 1;
        _repeated = new bool[_levelFinder.Level[level].Text.Length];
        for (int i = 0; i < _repeated.Length; i++)
        {
            _repeated[i] = false;
        }
    }

    public void PutIndex(int index) => _index = index;

    public void ShowText(bool timer)
    {
        _button.SetActive(true);
        if (_repeated[_index])
        {
            Close();
            if (_workAction) _action?.Invoke();
            return;
        }

        _workAction = false;
        StringArray tempArray = _levelFinder.Level[level].Text[_index];
        if (timer)
        {
            _player.CanMove(true);
            StartCoroutine(Timer(tempArray));
            return;
        }

        if (count >= tempArray.String.Length)
        {
            count = 0;
            Close();
            _repeated[_index] = true;
            return;
        }

        ButtonText();
        _text.text = tempArray.String[count];
        count++;
    }

    private IEnumerator Timer(StringArray tempArray)
    {
        _repeated[_index] = true;
        _button.SetActive(false);
        for (int i = 0; i < tempArray.String.Length; i++)
        {
            _text.text = tempArray.String[i];
            yield return new WaitForSeconds(_secondsForSkip);
        }
        Close();
    }

    private void Close()
    {
        _player.CanMove(true);
        gameObject.SetActive(false);
    }

    private void ButtonText() => _buttonText.text = (count + 1 >= _levelFinder.Level[level].Text[_index].String.Length) ?  "Закрыть" : _buttonText.text = "Дальше";
}