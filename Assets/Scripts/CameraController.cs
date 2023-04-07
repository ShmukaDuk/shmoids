using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
public class CameraController : NetworkBehaviour
{
    [SerializeField] private GameObject cameraHolder;
    [SerializeField] private Vector3 offset = new Vector3(0f, 2f, -10f);
    [SerializeField] private float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (!IsOwner)
        {
            cameraHolder.SetActive(false);
            return;
        }
        cameraHolder.transform.position = transform.position + offset;
    }
}