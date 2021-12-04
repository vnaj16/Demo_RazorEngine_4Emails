using RazorEngine;
using RazorEngine.Templating;
using System;
using System.IO;

namespace Demo_RazorEngine_4Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Simple way
            //string template = "Hello @Model.Name!";
            //var result = Engine
            //    .Razor
            //    .RunCompile(template,
            //        "templateKey",
            //        null,
            //        new
            //        {
            //            Name = "Arthur"
            //        });
            //            Console.WriteLine(result);
            #endregion


            #region With Object type way
            //const string template = "Hello @Model.FirstName!";
            //const string key = "templateKey";

            //var one =
            //    Engine.Razor
            //        .RunCompile(template,
            //            key,
            //            typeof(CartaAuditoriaViewModel),
            //            new CartaAuditoriaViewModel { FirstName = "Arthur" });

            //Console.WriteLine(one);
            #endregion

            #region My Demo with Email Template
            //La mecanica de trabajo seria trabajar la vista con Razor normal desde ASP.NET Core MVC,
            //una vez ya esté, se eliminaria cualquier cosa que sea diferente a @Model a un archivo para que este lo lea y genera el HTML,
            //porque practicamente lo que hace es Reemplazar los valores del Model con sus properties adecuadas
            string FilePath = Environment.CurrentDirectory + @"\views\index.cshtml";
            string OriginalEmailTemplateText = File.ReadAllText(FilePath);

            string template = OriginalEmailTemplateText;
            const string key = "templateKey";

            var one =
                Engine.Razor
                    .RunCompile(template,
                        key,
                        typeof(CartaAuditoriaViewModel),
                        new CartaAuditoriaViewModel { FirstName = "Arthur", EmployeeName = "Carlos Nole", EmployeeRole="Engineer" });

            File.WriteAllText(Environment.CurrentDirectory + @"\email.html", one);  
            Console.WriteLine(one);
            #endregion

            Console.ReadLine();
        } //REFERENCE: https://khalidabuhakmeh.com/generate-outputs-with-razor-engine-in-dotnet-core
    }
}
