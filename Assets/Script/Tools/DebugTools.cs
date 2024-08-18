using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class DebugTools
    {
        public static void DebugFixedJoint(StarShips ships)
        {
            List<ComponentSS> l = ships.GetComponents();
            foreach (var c in l)
            {
                Debug.Log("Components " + c);
                Dictionary<DirEnum, FixedJoint> j = c.Getjoints();
                Dictionary<DirEnum, GameObject> o = c.GetObj();
                foreach (var k in j)
                {
                    Debug.Log("direction" + k.Key);
                    Debug.Log("il est connecté à " + k.Value.connectedBody);
                    if (o.ContainsKey(k.Key))
                    {
                        Debug.Log(o[k.Key]);
                    }
                    else
                    {
                        Debug.LogError("manque un truc");
                    }
                }
            }
        }
    }
}
