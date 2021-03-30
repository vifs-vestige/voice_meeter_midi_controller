using System;
using System.Collections.Generic;
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
using NAudio.Midi;
using voice_meeter_midi_controller.Enums;

namespace voice_meeter_midi_controller {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MidiController Midi;
        public static MainWindow WindowStuff;

        public MainWindow() {
            InitializeComponent();
            WindowStuff = this;
            var temp = new VoiceMeeterController();
            var temp2 = temp.GetCurrentLevel(BusType.output, VoiceMeeterChannel.B3);
            MidiTest.Text = temp2.ToString();
        }
    }
}
