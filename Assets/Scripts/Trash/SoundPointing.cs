using UnityEngine;
using UnityEngine.UI;

public class SoundPointing : MonoBehaviour
{
    [SerializeField] private Camera _inputCamera;

    private void Update()
    {
        var ray = _inputCamera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        var raycastHit = new RaycastHit();

        if(Physics.Raycast(ray, out raycastHit))
        {
            var interactable = raycastHit.collider.GetComponent<Button>();

            if (interactable != null)
            {
                //interactable.Action();
            }
        }
    }
}
public interface IInteractable
{
    public void Action();
}