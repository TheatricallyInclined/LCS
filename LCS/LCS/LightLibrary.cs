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
            string[] TenkooPar = {"Intensity", "Red", "Green", "Blue", "Strobe", "Effect", "Something" };
            string[] Source4s2Dir = {"Red", "Lime", "Amber", "Green", "Cyan", "Blue", "Indigo", "Intensity", "Strobe", "Fan Control"};
            string[] Source4s2HSI = {"Hue (coarse)", "Hue (fine)", "Saturation", "Intensity", "Strobe", "Fan Control"};
            string[] Source4s2HSIC = { "Hue (coarse)", "Hue (fine)", "Saturation", "Intensity", "Strobe", "Fan Control", "Color Point (CCT)" };
            string[] Source4s2RGB = { "Red", "Green", "Blue", "NOT USED", "Strobe", "Fan Control" };
            string[] Source4s2Stud = { "Intensity", "Color Point (CCT)", "Tint", "NOT USED", "Strobe", "Fan Control" };
            string[] D60XTIDir = { "Red", "Orange (White if Lustr+)", "Amber", "Green", "Cyan", "Blue", "Indigo", "Intensity", "Strobe" };
            string[] D60XTIHSI = { "Hue (coarse)", "Hue (fine)", "Saturation", "Intensity", "Strobe" };
            string[] D60XTIHSIC = { "Hue (coarse)", "Hue (fine)", "Saturation", "Intensity", "Strobe", "Color Point (CCT)" };
            string[] D60XTIRGB = { "Red", "Green", "Blue", "NOT USED", "Strobe" };
            string[] D60XTIStud = { "Intensity", "Color Point (CCT)", "Tint" };
            string[] R2Wash = { "Pan", "Fine Pan", "Tilt", "Fine Tilt", "Pan/Tilt Speed", "Dimmer", "Fine Dimmer", "Shutter", "Red", "Fine Red", "Green", "Fine Green", "Blue", "Fine Blue", "White", "Fine White", "Color", "Zone Selection", "Programs", "Auto Speed", "Zoom", "Control" };
            string[] IntSpot15511CH = { "Pan", "Tilt", "Fine Pan", "Fine Tilt", "Speed", "Color", "Shutter", "Dimmer", "Gobo Wheel", "Control Functions", "Movement Macros" };
            string[] IntSpot1556CH = { "Pan", "Tilt", "Color", "Shutter", "Dimmer", "Gobo Wheel" };

            lights.Add("Tenkoo Mega Par", TenkooPar);
            lights.Add("Source4 LED S2 - Direct", Source4s2Dir);
            lights.Add("Source4 LED S2 - HSI", Source4s2HSI);
            lights.Add("Source4 LED S2 - HSIC", Source4s2HSIC);
            lights.Add("Source4 LED S2 - RGB", Source4s2RGB);
            lights.Add("Source4 LED S2 - Studio", Source4s2Stud);
            lights.Add("D60XTI - Direct", D60XTIDir);
            lights.Add("D60XTI - HSI", D60XTIHSI);
            lights.Add("D60XTI - HSIC", D60XTIHSIC);
            lights.Add("D60XTI - RGB", D60XTIRGB);
            lights.Add("D60XTI - Studio", D60XTIStud);
            lights.Add("Chauvet R2 Wash - 22 CH", R2Wash);
            lights.Add("Chauvet IntSpot 155 - 11CH", IntSpot15511CH);
            lights.Add("Chauvet IntSpot 155 - 6CH", IntSpot1556CH);
        }
    }
}
