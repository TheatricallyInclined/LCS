using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LCS.Lib
{
    class LightLibrary
    {
        public static Hashtable lights;

        static LightLibrary()
        {
            lights = new Hashtable();
            string[] light1 = {"Intensity", "Red", "Green", "Blue", "Strobe", "Effect", "Something" };
            string[] light2 = {"1", "2", "3", "4", "5"};
            lights.Add("Light1", light1);
            lights.Add("Light2", light2);
        }
    }
}
