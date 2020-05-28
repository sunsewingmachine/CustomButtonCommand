
using SharedLibrary.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace CustomButtonWithMvvmCommand.Views.Usercontrols.BtnCust2
{

    public sealed partial class ButtonCust2 : ButtonBase, INotifyPropertyChanged
    {
        public event RoutedEventHandler ButtonClick;
        public int Result { get; set; }

        private object _additionalContent;
        public object AdditionalContent
        {
            get { return _additionalContent; }
            set
            {
                _additionalContent = value;
                OnPropertyChanged();
            }
        }

        public static readonly DependencyProperty AdditionalContentProperty =
            DependencyProperty.Register("AdditionalContent", typeof(object), typeof(ButtonCust2),
              new PropertyMetadata(null));


        private Symbol _mySymbol;
        public Symbol MySymbol
        {
            get
            {
                //{StaticResource SymbolIcon}
                return _mySymbol;
            }

            set
            {
                _mySymbol = value;
                OnPropertyChanged();
            }
        }

        private Visibility _showSymbol = Visibility.Visible;
        public Visibility ShowSymbol
        {
            get
            {
                return _showSymbol;
            }

            set
            {
                _showSymbol = value;
                OnPropertyChanged();
            }
        }

        private Visibility _showTextMsg = Visibility.Visible;
        public Visibility ShowTextMsg
        {
            get
            {
                return _showTextMsg;
            }

            set
            {
                _showTextMsg = value;
                OnPropertyChanged();
            }
        }

        //return @"C:\Users\Public\Pictures\Sample Pictures\Chrysanthemum.jpg";
        private string _displayedImageUrl;
        public string DisplayedImageUrl
        {
            get
            {
                return _displayedImageUrl;
            }

            set
            {
                // = "Assets/BtnRound.png";
                // = "ms-appx:///" + "Assets/BtnRound.png";

                _displayedImageUrl = "ms-appx:///" + value;
                DisplayedImage = new BitmapImage(new Uri(_displayedImageUrl, UriKind.RelativeOrAbsolute));
                OnPropertyChanged();
            }
        }


        private BitmapImage _displayedImage;
        public BitmapImage DisplayedImage
        {
            get
            {
                return _displayedImage;
            }

            set
            {
                _displayedImage = value;
                OnPropertyChanged();
            }
        }

        private SolidColorBrush _foreground;
        public SolidColorBrush Foregrounds
        {
            get
            {
                return _foreground;
            }

            set
            {
                _foreground = value;
                TxtBlockMsg.Foreground = value;
                OnPropertyChanged();
            }
        }

        private string _txtMsg;
        public string TxtMsg
        {
            get => _txtMsg;
            set
            {
                _txtMsg = value;
                OnPropertyChanged();
            }
        }

        public ButtonCust2()
        {
            this.InitializeComponent();

            //GrdBase.AddHandler(PointerPressedEvent, new PointerEventHandler(ImgBack_OnPointerReleased), true);
            //GrdBase.PointerReleased += GrdBase_PointerReleased;
            //ImgBack.PointerReleased += ImgBack_PointerReleased;
        }

        private void ButtonBase_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            //e.Handled = true;
            if (StoryPointerDown3.GetCurrentState() == ClockState.Active) return;
            StoryPointerDown3.Stop();
            StoryPointerDown3.Begin();
        }

        private void ButtonBase_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            e.Handled = true;
            if (StoryPointerUp3.GetCurrentState() == ClockState.Active) return;
            StoryPointerUp3.Stop();
            StoryPointerUp3.Begin();
        }


        private void GrdBase_PointerCanceled(object sender, PointerRoutedEventArgs e)
        {
            //e.Handled = true;

        }

        private void GrdBase_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
        {
            //e.Handled = true;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ImgBack_OnPointerEntered(object sender, PointerRoutedEventArgs e)
        {
            if (StoryPointerEntered3.GetCurrentState() == ClockState.Active) return;
            StoryPointerEntered3.Stop();
            StoryPointerEntered3.Begin();
            return;

        }

        private void ImgBack_OnPointerExited(object sender, PointerRoutedEventArgs e)
        {
            if (StoryPointerExited3.GetCurrentState() == ClockState.Active) return;
            StoryPointerExited3.Stop();
            StoryPointerExited3.Begin();
            return;
        }

        private void GrdBase_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                double gh = GrdBase.ActualWidth / 2;
                Control2.Height = gh;
                Control2.Width = gh;
            }
            catch (Exception ex)
            {
                //throw;
            }
        }


        private void GrdBase_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            ButtonClick?.Invoke(this, new RoutedEventArgs());
        }

    }
}
