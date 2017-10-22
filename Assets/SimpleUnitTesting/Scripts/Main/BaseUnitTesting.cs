using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

namespace SimpleUnitTesting
{
    public abstract class BaseUnitTesting : MonoBehaviour
    {
        private void Start()
        {
            
        }


        public UnitTestingData[] GetUnitTestingData<T>() where T : System.Attribute
        {
            List<UnitTestingData> unitTestingData = new List<UnitTestingData>();

            System.Type type = GetType();
            foreach (MethodInfo method in type.GetMethods())
            {
                foreach (System.Attribute attribute in method.GetCustomAttributes(true))
                {
                    T test = attribute as T;

                    if(null == test)
                    {
                        continue;
                    }

                    unitTestingData.Add(new UnitTestingData(method.Name, test));
                }

            }

            return unitTestingData.ToArray();
        }


        public void RunTestMethod(string testMethodName, object[] data = null)
        {
            System.Type type = this.GetType();
            MethodInfo method = type.GetMethod(testMethodName);

            if(null == method)
            {
                Debug.LogError("[TestMethod] : no such test method " + testMethodName);
                return;
            }

            method.Invoke(this, data);
        }
    }
}