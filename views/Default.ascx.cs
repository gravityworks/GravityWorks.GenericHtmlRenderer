using DotNetNuke.Entities.Modules;
using GravityWorks.Utility.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace GravityWorks.GenericHtmlRenderer
{
    public partial class Default : PortalModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            var filename = DataUtil.GetString(Settings["FileToRender"]);
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    String line = sr.ReadToEnd();
                    litHtmlToShow.Text = line;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }
            
        }
    }



}