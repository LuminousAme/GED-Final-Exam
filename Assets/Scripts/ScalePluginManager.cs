using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public static class ScalePluginManager
{
    ///DLL INTERFACE///

    //make the struct to pass vector3 between each other
    public struct V3
    {
        public float x, y, z;
    }

    //Import the functions I need
    [DllImport("ScaleManager")]
    private static extern V3 ChangeScale(V3 originalScale);

    //get the scale of the object from the dll
    public static Vector3 GetObjectScale(Vector3 originalScale)
    {
        Vector3 newScale = Vector3.zero;
        //if the dll exists, make each value a random number from the dll
        try
        {
            V3 tempIn;
            tempIn.x = originalScale.x;
            tempIn.y = originalScale.y;
            tempIn.z = originalScale.z;

            V3 tempOut = ChangeScale(tempIn);

            newScale.x = tempOut.x;
            newScale.y = tempOut.y;
            newScale.z = tempOut.z;
        }
        //if it does not, just leave it on the existing pos
        catch
        {
            newScale = originalScale;
        }

        return newScale;
    }
}

