using IronPdf;
using Syncfusion.HtmlConverter;
using System;
using System.Diagnostics;
using System.IO;

namespace CreatePDF
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string pathInput = AppDomain.CurrentDomain.BaseDirectory + "Input\\InputData.csv";
                string pathTemplate = AppDomain.CurrentDomain.BaseDirectory + @"Template\Template.html";
                int filesHtml = UpdateDataTemplate.Main.UpdateTemplate(pathTemplate, pathInput, AppDomain.CurrentDomain.BaseDirectory);
                string path = AppDomain.CurrentDomain.BaseDirectory + @"wkhtmltopdf\bin\wkhtmltopdf.exe";
                
                for (int i = 1; i < filesHtml; i++)
                {
                    string pathHtmlFiles = AppDomain.CurrentDomain.BaseDirectory + "HTML-" + DateTime.Now.ToString("ddMMyyyy") + "\\" + DateTime.Now.ToString("ddMMyyyy") + i.ToString() + ".html";
                    string pathPdfFile = AppDomain.CurrentDomain.BaseDirectory + "PDF-" + DateTime.Now.ToString("ddMMyyyy") + "\\" + DateTime.Now.ToString("ddMMyyyy") + i.ToString() + ".pdf";
                    string arguments = string.Format("{0} {1}", pathHtmlFiles, pathPdfFile);
                    ProcessStartInfo oProcessStartInfo = new ProcessStartInfo();
                    oProcessStartInfo.UseShellExecute = false;
                    oProcessStartInfo.FileName = path;
                    oProcessStartInfo.Arguments = arguments;

                    using (Process oProcess = Process.Start(oProcessStartInfo))
                    {
                        oProcess.WaitForExit();
                    }
                }
            }
            catch (Exception e)
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Error\\LogError.txt", e.Message);
            }
            
        }
    }
}
