using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Xml;

namespace MyGame
{
    public class StaticPool<T> where T : IPoolable
    {
        private List<T> objInUse = new List<T>();
        private List<T> objAvailable = new List<T>();

        public StaticPool(int cantidad, T obj) 
        {
            for (int i = 0; i < cantidad; i++)
            {
                objAvailable.Add(obj);
                obj.OnDispose += RecycleObj;
            }

        }

        public T GetObj()
        {
            T obj = default(T);

            if(objAvailable.Count > 0)
            {
                obj = objAvailable[0];
                objAvailable.Remove(obj);
                objInUse.Add(obj);
            }
            return obj;
        }

        public void AddSlot(T obj) 
        {
            objAvailable.Add(obj);
            obj.OnDispose += RecycleObj;
        }

        public void RecycleObj(IPoolable obj)
        {
            objAvailable.Remove((T)obj);
            objAvailable.Add((T)obj);
        }

        public void PrintObj()
        {
            Engine.Debug("Libres: " + objAvailable.Count);
            Engine.Debug("En uso" + objInUse.Count);
        }
    }
}