﻿using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace GameOfLife
{
    internal class AdWindow : Window
    {
        private readonly DispatcherTimer _adTimer;
        private int _imgNmb;     // the number of the image currently shown
        private string _link;    // the URL where the currently shown ad leads to
    
        public AdWindow(Window owner)
        {
            var rnd = new Random();
            Owner = owner;
            Width = 350;
            Height = 100;
            ResizeMode = ResizeMode.NoResize;
            WindowStyle = WindowStyle.ToolWindow;
            Title = "Support us by clicking the ads";
            Cursor = Cursors.Hand;
            ShowActivated = false;
            MouseDown += OnClick;
            
            _imgNmb = rnd.Next(1, 3);
            ChangeAds(this, new EventArgs());

            // Run the timer that changes the ad's image 
            _adTimer = new DispatcherTimer();
            _adTimer.Interval = TimeSpan.FromSeconds(3);
            _adTimer.Tick += ChangeAds;
            _adTimer.Start();
        }

        private void OnClick(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(_link);
            Close();
        }
        
        protected override void OnClosed(EventArgs e)
        {
            //Unsubscribe();
            base.OnClosed(e);
        } 

        public void Unsubscribe()
        {
            _adTimer.Tick -= ChangeAds;
        }

        private void ChangeAds(object sender, EventArgs eventArgs)
        {
            
            var myBrush = new ImageBrush();
            
            switch (_imgNmb)
            {
                case 1:
                    myBrush.ImageSource =
                        new BitmapImage(new Uri("ad1.jpg", UriKind.Relative));
                    Background = myBrush;
                    _link = "http://example.com";
                    _imgNmb++;
                    break;
                case 2:
                    myBrush.ImageSource =
                        new BitmapImage(new Uri("ad2.jpg", UriKind.Relative));
                    Background = myBrush;
                    _link = "http://example.com";
                    _imgNmb++;
                    break;
                case 3:
                    myBrush.ImageSource =
                        new BitmapImage(new Uri("ad3.jpg", UriKind.Relative));
                    Background = myBrush;
                    _link = "http://example.com";
                    _imgNmb = 1;
                    break;
            }
            
        }
    }
}