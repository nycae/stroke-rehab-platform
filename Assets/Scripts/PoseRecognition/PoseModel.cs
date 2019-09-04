using System.IO;
using UnityEngine;
using UnityEngine.Assertions;


public class PoseModel
{
    static public int numberOfJoints = 9;

    static public int expectedFrameRate = 30;

    static public float numberOfSeconds = 3f;

    static public int numberOfFrames = (int)numberOfSeconds * expectedFrameRate;

    private Quaternion[,] rotationModel;

    public PoseModel()
    {
        rotationModel = new Quaternion[numberOfJoints, numberOfFrames];
    }

    public PoseModel(Quaternion[,] initModel)
    {
        Assert.AreEqual(initModel.GetLength(0), numberOfJoints);
        Assert.AreEqual(initModel.GetLength(1), numberOfFrames);

        rotationModel = initModel;
    }

    public double[][] GetAllComponents(char selection)
    {
        double[][] to_return = new double[numberOfJoints][];
        for (int i = 0; i < numberOfJoints; i++) to_return[i] = new double[numberOfFrames];
        for (int i = 0; i < numberOfJoints; i++)
        {
            for (int j = 0; j < expectedFrameRate; j++)
            {
                switch (selection)
                {
                    case 'x':
                        to_return[i][j] = rotationModel[i, j].x;
                        break;
                    case 'y':
                        to_return[i][j] = rotationModel[i, j].y;
                        break;
                    case 'z':
                        to_return[i][j] = rotationModel[i, j].z;
                        break;
                    case 'w':
                        to_return[i][j] = rotationModel[i, j].w;
                        break;
                }
            }
        }
        return to_return;
    }

    public double Compare(PoseModel other)
    {
        NDtw.Dtw dtw;

        double[][] firstSeries;
        double[][] secondSeries;
        double error = 0;
        char[] components = { 'x', 'y', 'z', 'w' };

        foreach (char component in components)
        { 
            firstSeries = GetAllComponents(component);
            secondSeries = other.GetAllComponents(component);

            for (int i = 0; i < numberOfJoints; i++)
            {
                dtw = new NDtw.Dtw(firstSeries[i], secondSeries[i]);
                error += dtw.GetCost();
            }
        }

        return error;
    }

    public void LoadModel(string fileName)
    {
        string[] fileInLines = BetterStreamingAssets.ReadAllLines(fileName);
        int jointIndex = 0;
        int frameIndex = 0;


        foreach (string line in fileInLines)
        {
            frameIndex = 0;
            string[] rotations = line.Substring(1, line.Length - 3).Split(';'); ; // [(...);(...)] -> [(...), (...)]

            foreach (string rotation in rotations)
            {
                string[] values = rotation.Substring(1, rotation.Length - 2).Split(','); // (1,2,3,4) -> [1, 2, 3, 4]

                rotationModel[jointIndex, frameIndex] 
                    = new Quaternion(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2]), float.Parse(values[3]));
                frameIndex++;
            }
            jointIndex++;
        }
    }

    public void SaveModel(string fileName)
    {
        FileInfo file = new FileInfo(Application.persistentDataPath + "/" + fileName);

        if (file.Exists) file.Delete();

        StreamWriter writer = file.CreateText();

        for (int jointIndex = 0; jointIndex < numberOfJoints; jointIndex++)
        {
            writer.Write("[");
            for (int frameIndex = 0; frameIndex < numberOfFrames; frameIndex++)
            {
                Quaternion frameJointRotation = rotationModel[jointIndex, frameIndex];
                writer.Write(string.Format("({0},{1},{2},{3})", frameJointRotation.x,
                    frameJointRotation.y, frameJointRotation.z, frameJointRotation.w));

                if (frameIndex < numberOfFrames + 1)
                {
                    writer.Write(";");
                }
                writer.Flush();
            }
            writer.Write("]");
            writer.Write(writer.NewLine);
        }
    }
}
