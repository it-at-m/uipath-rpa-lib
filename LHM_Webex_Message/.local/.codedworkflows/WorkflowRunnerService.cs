using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UiPath.CodedWorkflows;
using UiPath.CodedWorkflows.Interfaces;
using UiPath.Activities.Contracts;
using LHM_Webex_Message;

[assembly: WorkflowRunnerServiceAttribute(typeof(LHM_Webex_Message.WorkflowRunnerService))]
namespace LHM_Webex_Message
{
    public class WorkflowRunnerService
    {
        private readonly ICodedWorkflowServices _services;
        public WorkflowRunnerService(ICodedWorkflowServices services)
        {
            _services = services;
        }

        /// <summary>
        /// Invokes the LHM_Webex_Messenger.xaml
        /// </summary>
		/// <param name="isolated">Indicates whether to isolate executions (run them within a different process)</param>
        public void LHM_Webex_Messenger(System.Security.SecureString in_secure_webexToken, string in_str_Webex_Message, System.Security.SecureString in_secure_Webex_Room_Id, System.Boolean isolated)
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"LHM_Webex_Messenger.xaml", new Dictionary<string, object> { { "in_secure_webexToken", in_secure_webexToken }, { "in_str_Webex_Message", in_str_Webex_Message }, { "in_secure_Webex_Room_Id", in_secure_Webex_Room_Id } }, default, isolated, default, GetAssemblyName());
        }

        /// <summary>
        /// Invokes the LHM_Webex_Messenger.xaml
        /// </summary>
        public void LHM_Webex_Messenger(System.Security.SecureString in_secure_webexToken, string in_str_Webex_Message, System.Security.SecureString in_secure_Webex_Room_Id)
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"LHM_Webex_Messenger.xaml", new Dictionary<string, object> { { "in_secure_webexToken", in_secure_webexToken }, { "in_str_Webex_Message", in_str_Webex_Message }, { "in_secure_Webex_Room_Id", in_secure_Webex_Room_Id } }, default, default, default, GetAssemblyName());
        }

        private string GetAssemblyName()
        {
            var assemblyProvider = _services.Container.Resolve<ILibraryAssemblyProvider>();
            return assemblyProvider.GetLibraryAssemblyName(GetType().Assembly);
        }
    }
}