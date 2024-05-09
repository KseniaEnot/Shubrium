using UnityEngine;
using UnityEngine.Events;

public class Monologue : MonoBehaviour
{
    [SerializeField] private UnityEvent _action;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Move>().CanMove(false);
            _action.Invoke();
        }
    }
}