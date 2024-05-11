
using UnityEngine;

public class LevelController : Controller
{
    [SerializeField] private Move _player;
    public override void ShowText(int index)
    {
        base.ShowText(index);
        if (_repeated[_index])
        {
            return;
        }
        if (count >= tempArray.String.Length)
        {
            count = 0;
            _player.CanMove(true);
            _repeated[_index] = true;
            _panel.SetActive(false);
            return;
        }
        
        _player.CanMove(false);
        _text.text = tempArray.String[count];
        count++;
    }

    public void ButtonSkip()
    {
        ShowText(_index);
    }
}