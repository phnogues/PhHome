using OpenZWave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace PhHome.UI.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class ShuttersPage : Page
    {
        public ShuttersPage()
        {
            this.InitializeComponent();

            init();
        }

        private async void init()
        {
            var serialPortSelector = Windows.Devices.SerialCommunication.SerialDevice.GetDeviceSelector();
            var devices = await DeviceInformation.FindAllAsync(serialPortSelector);
            var serialPort = devices.First().Id; //Adjust to pick the right port for your usb stick
            ZWManager.Instance.AddDriver(serialPort); //Add the serial port (you can have multiple!)
        }
    }
}
