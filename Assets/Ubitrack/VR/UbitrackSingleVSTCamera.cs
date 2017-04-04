using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FAR;
public class UbitrackSingleVSTCamera : MonoBehaviour {
    
    public CameraProjectionMatrixFrom3x3Matrix Eye;
    public Transform eyeOffset;

    public Texture CameraImage;
    
    public Material ARMaterial;
    public string ARMaterialTexName = "_MainTex";

    protected Camera cam;

    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        updateVRSettings();

    }

    public void updateVRSettings()
    {


    }

    void OnPreRender()
    //void OnRenderObject()
    {
        StereoTargetEyeMask currentEye = cam.stereoTargetEye;

        Matrix4x4 camPose = cam.worldToCameraMatrix;

        Matrix4x4 viewOffset = new Matrix4x4();
        viewOffset.SetTRS(eyeOffset.transform.localPosition, eyeOffset.transform.localRotation, Vector3.one);

        

        cam.projectionMatrix = Eye.projectionMatrix * viewOffset;
        ARMaterial.SetTexture(ARMaterialTexName, CameraImage);

        switch (currentEye)
        {
            case StereoTargetEyeMask.None:
            case StereoTargetEyeMask.Both:
            case StereoTargetEyeMask.Left:
                
                //cam.SetStereoProjectionMatrix(Camera.StereoscopicEye.Left, Eye.projectionMatrix);
                

                //Matrix4x4 viewLeft = new Matrix4x4();
                //viewLeft.SetTRS(Eye.transform.localPosition, Eye.transform.localRotation, Vector3.one);
                //cam.SetStereoViewMatrix(Camera.StereoscopicEye.Left, viewLeft * camPose);
                break;
            case StereoTargetEyeMask.Right:
                break;
            
        }
        

        




    }

    void OnPostRender()
    {
        cam.ResetStereoViewMatrices();
        //cam.ResetStereoProjectionMatrices();
    }

}
