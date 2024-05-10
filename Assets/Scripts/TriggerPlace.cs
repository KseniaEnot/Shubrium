using UnityEngine;
using UnityEngine.Events;

public class TriggerPlace : MonoBehaviour
{
    [SerializeField] private UnityEvent _action;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(tag == "Monologue") other.GetComponent<Move>().CanMove(false);
            _action.Invoke();
        }
    }
}