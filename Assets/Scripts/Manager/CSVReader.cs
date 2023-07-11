using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace MySystemCSVReader
{
    public class CSVReader : MonoBehaviour
    {
        public static List<string[]> ReadCSVFile(string filePaath)
        {
            List<string[]> csvData = new List<string[]>();

            using (StreamReader reader = new StreamReader(filePaath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] rowData = line.Split(',');

                    csvData.Add(rowData);
                }
            }
            return csvData;
            Debug.Log(csvData);
        }

    }
}


