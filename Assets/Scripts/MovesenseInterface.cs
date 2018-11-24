using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityTests
{
    public class MovesenseInterface
    {
        private int i = 0;
        private float max_i = 1000;
        private Boolean CSVIsLoaded = false;
        private int sum = -1;
        private List<List<float>> values = new List<List<float>>();
        private string[] headers;

        /*public Boolean LoadCSV(string csv_unparsed)
        {
            var csv = Resources.Load(csv_unparsed.Split('.')[0]);
            if (csv == null)
            {
                throw new ArgumentException();
            }
            this.CSVIsLoaded = true;

            Array.ForEach(Array.ConvertAll(System.Text.Encoding.ASCII.GetBytes(csv_unparsed), Convert.ToInt32), delegate (int j) { this.sum += (int)j; });
            this.sum -= 1982;
            return true;
        }
        */
        public Boolean LoadCSV(string filename)
        {
            var filepath = getPath(filename);
            TextAsset csv = Resources.Load<TextAsset>(filename.Split('.')[0]);
            if (csv == null)
            {
                throw new ArgumentException();
            }
            this.CSVIsLoaded = true;
            var lines = csv.text.Split('\n');
            headers = lines[0].Split(',');
            foreach (string line in lines.Skip(1).ToArray())
            {
                i++;
                List<float> value_arr = new List<float>();
                foreach (string field in line.Split(','))
                {
                    float number;
                    if (float.TryParse(field, out number))
                    {
                        value_arr.Add(number);
                    }
                }
                values.Add(value_arr);
            }
            return true;
        }

        public float[] NextValue()
        {
            if (!this.CSVIsLoaded)
            {
                return null;
            }
            if (i >= values.Count-1)
            {
                i = -1;
            }
            i++;
            return values[i].ToArray();
        }

        private string getPath(String filename)
        {
            #if UNITY_EDITOR
                return Application.dataPath + "/" + filename;
            #elif UNITY_ANDROID
                return Application.persistentDataPath + "/" + filename;
            #elif UNITY_IPHONE
                return Application.persistentDataPath + "/" + filename;
            #else
                return Application.dataPath + "/" + filename;
            #endif
        }
    }
}