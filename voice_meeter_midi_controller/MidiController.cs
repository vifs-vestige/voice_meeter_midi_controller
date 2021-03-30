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

        private void turnLightOn() {


            ////this works v
            //var midiOut = new MidiOut(1);
            //var note = 12;
            //var velcoity = 1;
            //var noteOnEvent = new NoteOnEvent(0L, 1, note, velcoity, 1);
            //midiOut.Send(noteOnEvent.GetAsShortMessage());
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

            var temp = e.MidiEvent.CommandCode;
            if(e.MidiEvent.CommandCode == MidiCommandCode.NoteOn) {
                var temp2 = (NoteOnEvent)e.MidiEvent;
                var temp3 = temp2.NoteNumber;
            } else if(e.MidiEvent.CommandCode ==  MidiCommandCode.NoteOff) {
                var temp2 = (NoteEvent)e.MidiEvent;
                var temp3 = temp2.NoteNumber;
            } else if(e.MidiEvent.CommandCode == MidiCommandCode.ControlChange) {
                //slider
            }
            Application.Current.Dispatcher.Invoke(new Action(() => { MainWindow.WindowStuff.MidiTest.Text = e.MidiEvent.ToString(); }));
        }
    }
}
