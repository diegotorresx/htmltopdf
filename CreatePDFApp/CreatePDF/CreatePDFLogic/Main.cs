using System;
using System.Diagnostics;
using System.IO;
using UpdateDataTemplate.BusinessLogic;

namespace UpdateDataTemplate
{
    public class Main
    {
       public static int UpdateTemplate(string pathTemplate, string inputhData, string pahtSaveHtml)
       {
            int filesHtml = UpdateDataLogic.ReadHtmlTemplate(pathTemplate, inputhData, pahtSaveHtml);
            return filesHtml;
       }
    }
}
