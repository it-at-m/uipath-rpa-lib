using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UiPath.CodedWorkflows;
using UiPath.CodedWorkflows.Interfaces;
using UiPath.Activities.Contracts;
using Webex_Exception_Alerting;

[assembly: WorkflowRunnerServiceAttribute(typeof(Webex_Exception_Alerting.WorkflowRunnerService))]
namespace Webex_Exception_Alerting
{
    public class WorkflowRunnerService
    {
        private readonly ICodedWorkflowServices _services;
        public WorkflowRunnerService(ICodedWorkflowServices services)
        {
            _services = services;
        }

        /// <summary>
        /// Invokes the Webex_Exception_messanger.xaml
        /// </summary>
		/// <param name="isolated">Indicates whether to isolate executions (run them within a different process)</param>
        public void Webex_Exception_messanger(System.Exception in_SystemException, System.Boolean isolated)
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"Webex_Exception_messanger.xaml", new Dictionary<string, object> { { "in_SystemException", in_SystemException } }, default, isolated, default, GetAssemblyName());
        }

        /// <summary>
        /// Invokes the Webex_Exception_messanger.xaml
        /// </summary>
        public void Webex_Exception_messanger(System.Exception in_SystemException)
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"Webex_Exception_messanger.xaml", new Dictionary<string, object> { { "in_SystemException", in_SystemException } }, default, default, default, GetAssemblyName());
        }

        private string GetAssemblyName()
        {
            var assemblyProvider = _services.Container.Resolve<ILibraryAssemblyProvider>();
            return assemblyProvider.GetLibraryAssemblyName(GetType().Assembly);
        }
    }
}