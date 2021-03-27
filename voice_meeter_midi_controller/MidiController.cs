using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using NAudio.Midi;

namespace voice_meeter_midi_controller{
    public class MidiController : IDisposable {
        private MidiIn DeviceIn;
        private MidiOut DeviceOut;

        public MidiController(int inId, int outId) {
            DeviceIn = new MidiIn(inId);
            DeviceIn.MessageReceived += midiIn_MessageReceived;
            DeviceIn.ErrorReceived += midiIn_ErrorReceived;
            DeviceIn.Start();
            DeviceOut = new MidiOut(outId);
            
        }

        public void Dispose() {
            DeviceIn.Stop();
            DeviceIn.Dispose();
        }

        private void midiIn_ErrorReceived(object sender, MidiInMessageEventArgs e) {
            MainWindow.WindowStuff.MidiTest.Text = "b";
            Application.Current.Dispatcher.Invoke(new Action(() => { MainWindow.WindowStuff.MidiTest.Text = "b"; }));
        }

        private void midiIn_MessageReceived(object sender, MidiInMessageEventArgs e) {
            //MainWindow.WindowStuff.MidiTest.Text = "b";
            Application.Current.Dispatcher.Invoke(new Action(() => { MainWindow.WindowStuff.MidiTest.Text = e.MidiEvent.ToString(); }));
        }
    }
}
