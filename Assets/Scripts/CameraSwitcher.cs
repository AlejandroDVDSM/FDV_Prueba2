using Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineBrain _cinemachineBrain;
    
    [SerializeField] private CinemachineVirtualCamera _playerVcam;
    [SerializeField] private CinemachineVirtualCamera _treeVcam;
    
    private void Update()
    {
        
        // Transition to the player camera when the specified key is pressed
        if (Input.GetKeyDown(KeyCode.C) && !_playerVcam.gameObject.activeSelf)
        {
            _cinemachineBrain.ActiveVirtualCamera.VirtualCameraGameObject.SetActive(false);
            _playerVcam.gameObject.SetActive(true);
        } else if (Input.GetKeyDown(KeyCode.C) && !_treeVcam.gameObject.activeSelf)
        { // Transition to the tree camera when the specified key is pressed
            _cinemachineBrain.ActiveVirtualCamera.VirtualCameraGameObject.SetActive(false);
            _treeVcam.gameObject.SetActive(true);            
        }
    }
}
