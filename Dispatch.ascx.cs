using System;
using System.IO;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;

namespace GravityWorks.GenericHtmlRenderer
{
    public partial class Dispatch : PortalModuleBase, IActionable
    {
        #region Properties

        protected string RequestedView
        {
            get { return Request.QueryString["view"] ?? ""; }
        }

        #endregion

        #region IActionable Members

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var moduleActions = new ModuleActionCollection();
                //moduleActions.Add(GetNextActionID(), "Administration", ModuleActionType.EditContent, "", "", UrlHelper.ViewUrl(ViewNames.AdminDefault), false, SecurityAccessLevel.Edit, true, false);

                return moduleActions;
            }
        }

        #endregion

        protected string GetCustomControlToLoad()
        {
            return String.IsNullOrEmpty(RequestedView)
                       ? "Views/Default.ascx"
                       : String.Format("Views/{0}.ascx", RequestedView);
        }

        protected new void Page_Init(Object sender, EventArgs e)
        {
            try
            {
                string control = GetCustomControlToLoad();
                LoadCustomControl(control);
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex);
            }
        }

        private void LoadCustomControl(string controlPath)
        {
            var module = (PortalModuleBase)LoadControl(controlPath);
            if (module != null)
            {
                // load the control into the placeholder
                module.ModuleConfiguration = ModuleConfiguration;
                module.ID = Path.GetFileNameWithoutExtension(controlPath);
                plhControl.Controls.Add(module);
            }
        }
    }
}