using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using System.IO;
using System.Linq;
using GravityWorks.Utility.Data;

namespace GravityWorks.GenericHtmlRenderer
{
    public partial class Settings : ModuleSettingsBase
    {
        public string ModuleBaseFilePath
        {
            get { return string.Format("{1}{0}DesktopModules{0}{2}{0}", Path.DirectorySeparatorChar, Request.PhysicalApplicationPath, ModuleConfiguration.DesktopModule.FolderName); }
        }

        public override void LoadSettings()
        {
            if (!Page.IsPostBack)
            {
                DirectoryInfo di = new DirectoryInfo(string.Format("{0}html/", ModuleBaseFilePath));
                var fileList = di.GetFiles("*.html").ToList().Select(a => new { Name = a.Name, FileName = a.FullName }).ToList();
                ddlFilesToRender.DataSource = fileList;
                ddlFilesToRender.DataTextField = "Name";
                ddlFilesToRender.DataValueField = "FileName";
                ddlFilesToRender.DataBind();
                ddlFilesToRender.SelectedValue = DataUtil.GetString(ModuleSettings["FileToRender"]);
            }
        }

        public override void UpdateSettings()
        {
            try
            {
                var settings = new ModuleController();

                settings.UpdateModuleSetting(ModuleId, "FileToRender", ddlFilesToRender.SelectedValue);
              
                ModuleController.SynchronizeModule(ModuleId);
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

    }

    public static class ModuleSettingNames
    {
      
    }
}