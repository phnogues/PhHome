using PhHome.UI.Services.Icons;
using PhHome.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhHome.UI.ViewModels
{
    internal class ShellViewModel : ViewModelBase
    {
        public ShellViewModel()
        {
            //// Build the menus

            //Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("HouseIcon"), Text = "Home", NavigationDestination = typeof(HomePage) });
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("BirdIcon"), Text = "Shutters", NavigationDestination = typeof(ShuttersPage) });
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("DonkeyIcon"), Text = "Cameras", NavigationDestination = typeof(CamerasPage) });
            

            SecondMenu.Add(new MenuItem() { Glyph = Icon.GetIcon("GearIcon"), Text = "Settings", NavigationDestination = typeof(SettingsPage) });
            SecondMenu.Add(new MenuItem() { Glyph = Icon.GetIcon("InfoIcon"), Text = "About", NavigationDestination = typeof(AboutPage) });
        }
    }
}