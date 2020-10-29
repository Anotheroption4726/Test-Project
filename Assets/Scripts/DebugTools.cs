using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public static class DebugTools
    {
        public static void Log(string msg)
        {
            Debug.Log("[" + Time.frameCount + "]" + msg);
        }
    }
}
