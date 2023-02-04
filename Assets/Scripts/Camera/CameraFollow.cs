
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform TargetCameraAlign;
    public Vector3 offset;
    public PlayerLife playerLife;

    private void Update() {
        if (playerLife.lifePlayer >0)
        {
            transform.position = TargetCameraAlign.position + offset;
        }
    }

}
