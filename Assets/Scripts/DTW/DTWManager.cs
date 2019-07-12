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

    static private int numberOfJoints = 11;

    static public float numberOfSeconds = 3f;

    static private int expectedFrameRate = 30;

    static private int numberOfFrames = (int)numberOfSeconds * expectedFrameRate;

    private bool isCollectingData = false;

    private Quaternion[,] rotations = new Quaternion[numberOfJoints, numberOfFrames];

    private int frameIndex = 0;

    private float timestamp;

    private void Start()
    {
        Application.targetFrameRate = expectedFrameRate;
    }

    private void Update()
    {
        if (isCollectingData)
        {
            if ((Time.time - timestamp) >= numberOfSeconds)
            {
                OnDataCollectionStop();
            }

            Quaternion[] frameRotations = riggedModel.GetRotations();
            for (int jointIndex = 0; jointIndex < numberOfJoints; jointIndex++)
            {
                rotations[jointIndex, frameIndex] = frameRotations[jointIndex];
                frameIndex++;
            }
        }
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnCaptureStart()
    {
        timestamp = Time.time;
        Invoke("StartCapture", numberOfSeconds);
    }

    private void StartCapture()
    {
        isCollectingData = true;
        timestamp = Time.time;
    }

    private void OnDataCollectionStop()
    {
        isCollectingData = false;
        SaveData();
    }

    private void SaveData()
    {

        FileInfo file = new FileInfo(Application.persistentDataPath + "/" + "output.txt");

        if (file.Exists) file.Delete();

        StreamWriter writer = file.CreateText();

        for (int jointIndex = 0; jointIndex < numberOfJoints; jointIndex++)
        {
            writer.Write("[");
            for (int frameIndex = 0; frameIndex < numberOfFrames; frameIndex++)
            {
                Quaternion frameJointRotation = rotations[jointIndex, frameIndex];
                writer.Write(string.Format("({0}, {1}, {2} ,{3})", frameJointRotation.x,
                    frameJointRotation.y, frameJointRotation.z, frameJointRotation.w));
            }
            writer.Write("]");
            writer.Write(writer.NewLine);
        }
        timerText.text = "Todo fue con forme a lo planteado";
    }

    public float GetTimestamp()
    {
        return timestamp;
    }
}
