using UnityEngine;

public class FeetPlayer : MonoBehaviour
{
    private Move _player;

    private void Start()
    {
        _player = GetComponentInParent<Move>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _player.SetGrounded(true);
        }
    }
}
