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
            //var temp2 = temp.GetCurrentLevel(BusType.input, VoiceMeeterChannel.A1);
            //MidiTest.Text = temp2.ToString();

            Midi = new MidiController("APC MINI");
            //var temp = new VoiceMeeterController(Midi);
            Midi.turnLightOn(0, 0);
            Midi.turnLightOn(0, 0);
            Midi.turnLightOn(8, 0);
            Midi.turnLightOn(16, 0);
            Midi.turnLightOn(24, 0);
            Midi.turnLightOn(32, 0);
            Midi.turnLightOn(40, 0);
            Midi.turnLightOn(48, 0);
            Midi.turnLightOn(56, 0);
        }



    }
}
