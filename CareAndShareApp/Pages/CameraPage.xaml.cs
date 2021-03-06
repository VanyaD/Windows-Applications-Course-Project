﻿namespace CareAndShareApp.Pages
{
    using CareAndShareApp.ViewModels;
    using System;
    using Windows.Graphics.Imaging;
    using Windows.Media.Capture;
    using Windows.Storage;
    using Windows.Storage.Streams;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Imaging;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class CameraPage : Page
    {
        LocatorViewModel viewModel;

        public CameraPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            viewModel = e.Parameter as LocatorViewModel;
        }

        private async void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            IRandomAccessStream stream = await photo.OpenAsync(FileAccessMode.Read);
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
            SoftwareBitmap softwareBitmap = await decoder.GetSoftwareBitmapAsync(); 
            SoftwareBitmap softwareBitmapBGR8 = SoftwareBitmap.Convert(softwareBitmap, BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);
            SoftwareBitmapSource bitmapSource = new SoftwareBitmapSource();
            await bitmapSource.SetBitmapAsync(softwareBitmapBGR8);

            imageControl.Source = bitmapSource;
            this.GoToProblemDescriptionPage.Visibility = Visibility.Visible;

            viewModel.ImagePath = photo.Path;
            viewModel.ImageSource = bitmapSource;
            viewModel.ImageName = photo.DisplayName;
        }

        private void GoToProblemDescriptionPageClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ProblemDescriptionPage), viewModel);
        }

        private void AppBarHomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
