using UnityEngine;

namespace Script
{
    public class Tools
    {
        public static DirEnum InverseDir(DirEnum dir)
        {
            switch (dir)
            {
                case DirEnum.Front :
                    return DirEnum.Behind;
                case DirEnum.Behind:
                    return DirEnum.Front;
                case DirEnum.Right :
                    return DirEnum.Left;
                case DirEnum.Left:
                    return DirEnum.Right;
                case DirEnum.Up :
                    return DirEnum.Down;
                default:
                    return DirEnum.Up;
            }
        }

        public static Pair<Vector3, float> getDirVector(Transform trans, DirEnum dir)
        {
            switch (dir)
            {
                case DirEnum.Front :
                    return new Pair<Vector3, float>(trans.forward, trans.localScale.z);
                case DirEnum.Behind:
                    return new Pair<Vector3, float>(- trans.forward, trans.localScale.z);
                case DirEnum.Right :
                    return new Pair<Vector3, float>(trans.right, trans.localScale.x);
                case DirEnum.Left:
                    return new Pair<Vector3, float>(-trans.right, trans.localScale.x);
                case DirEnum.Up :
                    return new Pair<Vector3, float>(trans.up, trans.localScale.y);
                default:
                    return new Pair<Vector3, float>(-trans.up, trans.localScale.y);
            }
        }
    }
}