using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Huyn.Utils;

namespace GamepadDetection
{
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            var controllerDetector = GameControllerDetector.Instance;
            ManageGameControllerType(controllerDetector.CurrentControllerType);
            controllerDetector.GameControllerChanged += Instance_GameControllerChanged;
            this.PreviewKeyDown += MainPage_PreviewKeyDown;
        }

        private void Instance_GameControllerChanged(object sender, GameControllerDetector.GameControllerType e)
        {
            ManageGameControllerType(GameControllerDetector.Instance.CurrentControllerType);
        }

        private void ManageGameControllerType(GameControllerDetector.GameControllerType currentControllerType)
        {
            switch(currentControllerType)
            {
                case GameControllerDetector.GameControllerType.GAMEPAD:
                    GamepadTextBlock.Visibility = Visibility.Visible;
                    MediaRemoteTextBlock.Visibility = Visibility.Collapsed;
                    break;
                case GameControllerDetector.GameControllerType.MEDIAREMOTE:
                    GamepadTextBlock.Visibility = Visibility.Collapsed;
                    MediaRemoteTextBlock.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void MainPage_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            GameControllerDetector.Instance.AnalyzeKeyEvent(e);
        }

    }
}
