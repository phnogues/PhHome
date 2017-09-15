using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.ApplicationModel.VoiceCommands;

namespace PhHome.BackgoundTask
{
    public sealed class PhHomeVoiceCommandService : IBackgroundTask
    {
        BackgroundTaskDeferral _serviceDeferral;

        private VoiceCommandServiceConnection _voiceCommandServiceConnection;


        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            _serviceDeferral = taskInstance.GetDeferral();

            // If cancelled, set deferal
            // Mets le déféral si annulation
            taskInstance.Canceled += (sender, reason) => _serviceDeferral?.Complete();

            // Get the details of the event trat trigered the service
            // Obtient les détails de l'évenement qui à démarré le service
            var triggerDetails = taskInstance.TriggerDetails as AppServiceTriggerDetails;

            // Check if it is service name set in VCD
            // Regarde si c'est le nom du service qui est mis dans le VCD
            if (triggerDetails?.Name == "PhHome.BackgoundTask")
            {
                _voiceCommandServiceConnection = VoiceCommandServiceConnection.FromAppServiceTriggerDetails(triggerDetails);
                // Set deferal when voice command is completed
                // Mets le deferal quand la commande vocale est terminée
                _voiceCommandServiceConnection.VoiceCommandCompleted += (sender, args) => _serviceDeferral?.Complete();
                // Get voice command
                // Obtient la commande vocale
                var voicecommand = await _voiceCommandServiceConnection.GetVoiceCommandAsync();

                switch (voicecommand.CommandName)
                {
                    case "openShutter":

                        break;
                }
            }
        }
    }
}
