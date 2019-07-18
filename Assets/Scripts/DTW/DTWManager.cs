using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DTWManager : MonoBehaviour
{
    [SerializeField]
    JointMapping riggedModel;

    [SerializeField]
    Text timerText;

    static public float secondsToWait = 3f;

    private bool isCollectingData = false;

    private bool isInCountdown = false;

    private Quaternion[,] rotations = new Quaternion[PoseModel.numberOfJoints, PoseModel.numberOfFrames];

    private int frameIndex = 0;

    private float timestamp = 0.0f;

    private void Start()
    {
        Application.targetFrameRate = PoseModel.expectedFrameRate;
    }

    private void Update()
    {
        if (isCollectingData)
        {
            if (frameIndex >= PoseModel.numberOfFrames)
            {
                OnDataCollectionStop();
            }

            Quaternion[] frameRotations = riggedModel.GetRotations();

            for (int jointIndex = 0; jointIndex < frameRotations.Length; jointIndex++)
            {
                rotations[jointIndex, frameIndex] = frameRotations[jointIndex];
            }
            frameIndex++;
        }
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnCaptureStart()
    {
        timestamp = Time.time;
        isInCountdown = true;
        Invoke("StartCapture", secondsToWait);
    }

    private void StartCapture()
    {
        isCollectingData = true;
        isInCountdown = false;
        timestamp = Time.time;
    }

    private void OnDataCollectionStop()
    {
        isCollectingData = false;

        PoseModel model = new PoseModel(rotations);

        model.SaveModel("output.txt");
        timerText.text = "Todo fué correcto";
    }

    public float GetTimestamp()
    {
        return timestamp;
    }

    public bool IsCollectingData()
    {
        return isCollectingData;
    }

    public bool IsInCountdown()
    {
        return isInCountdown;
    }
}
