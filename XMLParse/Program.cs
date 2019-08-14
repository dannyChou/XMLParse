using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLParse.Models;

namespace XMLParse
{
    class Program
    {
        static void Main(string[] args)
        {
            string data0000 = GetXMLData("2112");
        }


        /// <summary>
        /// 取得信件的內容
        /// </summary>
        /// <param name="mailInfo"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        static string GetXMLData(string txId)
        {
            #region 取回樣版檔

            var config = new TemplateServiceConfiguration
            {
                TemplateManager = new ResolvePathTemplateManager(new[] { "XMLTemplate" }),
                DisableTempFileLocking = true
            };

            Engine.Razor = RazorEngineService.Create(config);
            string TemplateFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "XMLTemplate");

            string fileName = txId + ".cshtml";
            var emailTemplatePath = Path.Combine(TemplateFolderPath, fileName);
            #endregion

            M2112 entity = new M2112() { MyName = "Danny" };
            string MailBody = Engine.Razor.RunCompile(emailTemplatePath, null, entity);

            return MailBody;
        }
    }
}
