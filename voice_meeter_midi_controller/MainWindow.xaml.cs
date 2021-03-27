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
            Midi = new MidiController(0, 1);
            MidiTest.Text = "a";
            //System.Diagnostics.Debug.WriteLine("test");
            //var temp = MidiIn.DeviceInfo(0);
            //var temp2 = MidiOut.DeviceInfo(1);
            //var midiIn = new MidiIn(0);
            //midiIn.MessageReceived += new EventHandler<MidiInMessageEventArgs>(midiIn_MessageReceived);
            //midiIn.ErrorReceived += midiIn_ErrorReceived;
            //midiIn.Start();

            ////this works v
            //var midiOut = new MidiOut(1);
            //var note = 12;
            //var velcoity = 1;
            //var noteOnEvent = new NoteOnEvent(0L, 1, note, velcoity, 1);
            //midiOut.Send(noteOnEvent.GetAsShortMessage());

        }

        void midiIn_ErrorReceived(object sender, MidiInMessageEventArgs e) {
            System.Diagnostics.Debug.WriteLine(String.Format("Time {0} Message 0x{1:X8} Event {2}",
                e.Timestamp, e.RawMessage, e.MidiEvent));
        }

        void midiIn_MessageReceived(object sender, MidiInMessageEventArgs e) {
            System.Diagnostics.Debug.WriteLine(String.Format("Time {0} Message 0x{1:X8} Event {2}",
                e.Timestamp, e.RawMessage, e.MidiEvent));
        }
    }
}
