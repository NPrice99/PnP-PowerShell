﻿using Microsoft.SharePoint.Client;
using System.Management.Automation;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.Lists
{
    [Cmdlet(VerbsLifecycle.Request, "SPOReIndexList")]
    [CmdletHelp("Marks the list for full indexing during the next incremental crawl",
        Category = CmdletHelpCategory.Lists)]
    public class RequestReIndexList : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, HelpMessage = "The ID, Title or Url of the list.")]
        public ListPipeBind Identity;

        protected override void ExecuteCmdlet()
        {
            var list = Identity.GetList(SelectedWeb);

            if (list != null)
            {
                list.ReIndexList();
            }
         
        }
    }
}
