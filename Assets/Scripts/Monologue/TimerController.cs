using UnityEngine;
using System.Collections;

public class TimerController : Controller
{
    [SerializeField] private float _secondsForSkip = 2f;
    private Coroutine _coroutine;
    public override void ShowText(int index)
    {
        base.ShowText(index);
        if (_repeated[_index])
        {
            return;
        }
        _coroutine = StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _repeated[_index] = true;
        for (int i = 0; i < tempArray.String.Length; i++)
        {
            _text.text = tempArray.String[i];
            yield return new WaitForSeconds(_secondsForSkip);
        }
        _panel.SetActive(false);
    }
}
