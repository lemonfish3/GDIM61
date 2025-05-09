using UnityEngine;

public class CanvasSetup : MonoBehaviour
{
    public Transform target; // set this to enemy in Start()

    /*void Start()
    {
        Canvas canvas = GetComponentInChildren<Canvas>();
        if (canvas != null && canvas.renderMode == RenderMode.WorldSpace)
        {
            canvas.worldCamera = Camera.main;
        }
    }*/
    private void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + new Vector3(0, 1.5f, 0); // offset above head
            transform.forward = Camera.main.transform.forward; // face camera
        }
    }
}
