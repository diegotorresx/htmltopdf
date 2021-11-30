using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UpdateDataTemplate.BusinessLogic
{
    public class UpdateDataLogic
    {
        public static int ReadHtmlTemplate(string pathTemplate, string pathInput, string pathSaveHtml)
        {
            
                int count = 0;
                string template = File.ReadAllText(pathTemplate);
                List<string[]> readInputData = ReadInputFile(pathInput);
                foreach (var record in readInputData)
                {
                    if (readInputData.Count > 1 && count > 0)
                    {
                        string temp = template;
                        temp = temp.Replace("value1", record[1].ToString());
                        temp = temp.Replace("value2", record[2].ToString());
                        temp = temp.Replace("value3", record[0].ToString());
                        temp = temp.Replace("value4", record[3].ToString());
                        File.WriteAllText(pathSaveHtml + "HTML-" + DateTime.Now.ToString("ddMMyyyy") + "\\" + DateTime.Now.ToString("ddMMyyyy") + count.ToString() + ".html", temp);
                    }
                    count++;
                }
                return count;
        }

        public static List<string[]> ReadInputFile(string pathInputFile)
        {
            List<string[]> readData = new List<string[]>();

            using (StreamReader readFile = new StreamReader(pathInputFile))
            {
                string line;
                string[] row;

                while ((line = readFile.ReadLine()) != null)
                {
                    row = line.Split('|');
                    readData.Add(row);
                }
            }

            return readData;
        }
    }
}
