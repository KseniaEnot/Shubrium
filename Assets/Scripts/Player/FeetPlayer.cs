using UnityEngine;

public class FeetPlayer : MonoBehaviour
{
    private Move _player;

    private void Start()
    {
        _player = GetComponentInParent<Move>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _player.ChangeGround(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _player.ChangeGround(false);
        }
    }
}
