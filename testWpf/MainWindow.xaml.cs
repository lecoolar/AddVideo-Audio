using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace testWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string puth = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = "Videos Files |*.mp4; *.mpeg; *.avi| Audio Files |*.mp3";//форматы видео и аудио
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == true)
            {
                puth = openFileDialog.FileName;
                if (puth != "")
                {
                    volume.Value = 0.1;
                    video.Volume = 0.1;//по умолчанию стоит 0,5 мне покозалось громко
                    video.Source = new Uri(puth);
                    video.Play();
                }
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            video.Volume = volume.Value;
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if (video.CanPause)
                video.Pause();
            else
                video.Play();
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            video.Stop();
            video.Play();
        }

        private void video_MediaEnded(object sender, RoutedEventArgs e)
        {
            video.Stop();
            video.Play();
        }
    }
}
