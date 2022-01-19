using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CameraManager : Singleton<CameraManager>
{
    
    /// <summary>
    /// responsible for controls the virtual cameras in the game
    /// </summary>
    
    #region variables
    
    [SerializeField] private List<CinemachineVirtualCamera> cmCameras = new List<CinemachineVirtualCamera>();
    public CinemachineVirtualCamera currentCamera;
    private Vector3 currentZoom;

    
    #endregion


    #region functions

    /// <summary>
    /// activating the chosen camera form the list
    /// </summary>
    /// <param name="cameraIndex"> index of the chosen camera </param>
    public void ActivateCamera(int cameraIndex)
    {
        foreach (var camera in cmCameras)
        {
            camera.gameObject.SetActive(false);
        }
        cmCameras[cameraIndex].gameObject.SetActive(true);
        currentCamera = cmCameras[cameraIndex];
    }

    #endregion

   
   
    
    
  
}
