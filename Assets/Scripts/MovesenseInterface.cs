using System;
using UnityEngine;

namespace UnityTests
{
    public class MovesenseInterface
    {
        private float i = -1.0F;
        private float max_i = 1000;
        private Boolean CSVIsLoaded = false;
        private int sum = 0;

        public Boolean LoadCSV(string csv_unparsed)
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.dataPath);
            var found = false;
            foreach (var fi in di.GetFiles())
            {
                Debug.Log(fi.Name);
                if (fi.Name == csv_unparsed)
                {
                    found = true;
                }
            }
            if (found == false)
            {
                throw new ArgumentException();
            }
            this.CSVIsLoaded = true;
            Array.ForEach(Array.ConvertAll(System.Text.Encoding.ASCII.GetBytes(csv_unparsed), Convert.ToInt32), delegate (int j) { this.sum += (int)j; });
            this.sum -= 1982;
            return true;
        }

        public float[] NextValue()
        {
            if (!this.CSVIsLoaded)
            {
                return null;
            }
            i++;
            if (i > max_i)
            {
                i = -1.0F;
            }
            return new float[] { 7.987527F+i+(float)this.sum, 2.148831F, 5.470188F };
        }
    }
}