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

        public MidiController(string productName) {
            for (int i = 0; i < MidiIn.NumberOfDevices; i++) {
                var temp = MidiIn.DeviceInfo(i);
                if (temp.ProductName == productName) {
                    DeviceIn = new MidiIn(i);
                    break;
                }
            }

            for (int i = 0; i < MidiOut.NumberOfDevices; i++) {
                var temp = MidiOut.DeviceInfo(i);
                if (temp.ProductName == productName) {
                    DeviceOut = new MidiOut(i);
                    break;
                }
            }

            DeviceIn.MessageReceived += midiIn_MessageReceived;
            DeviceIn.ErrorReceived += midiIn_ErrorReceived;
            DeviceIn.Start();
        }

        public void showVolumeLevel(float level) {
            //1 = green
            //3 = red
            //5 = yellow
            level = level * 1000;
            int numberOfButtons = 8;
            int numberOfColors = 3;
            int volumeResolution = numberOfButtons * numberOfColors;
            var MaxedOutLevel = 1500;
            var levelPerBar = MaxedOutLevel / volumeResolution;
            int barsFiled = 0;
            if (level < MaxedOutLevel) {
                barsFiled = (int)Math.Round(level / levelPerBar);
            }
            else {
                barsFiled = volumeResolution;
            }

            List<int> stuff = new List<int>() { 0, 8, 16, 24, 32, 40, 48, 56 };
            for (int i = 0; i < numberOfButtons; i++) {
                int color = 0;

                if (barsFiled > 0) {
                    var temp = (barsFiled - i + 0.0) / numberOfButtons;
                    var value = (int)Math.Ceiling(((barsFiled - i + 0.0) / numberOfButtons)+0.0);
                    if (value == 1) {
                        color = 1;
                    }
                    else if (value == 2) {
                        color = 5;
                    }
                    else if (value == 3) {
                        color = 3;
                    }
                }
                turnLightOn(stuff[i], color);
            }
        }

        public void turnLightOn(int noteNumber, int velcoity) {
            var noteOnEvent = new NoteOnEvent(0L, 1, noteNumber, velcoity, 1);
            DeviceOut.Send(noteOnEvent.GetAsShortMessage());
        }


        private void midiIn_ErrorReceived(object sender, MidiInMessageEventArgs e) {
            MainWindow.WindowStuff.MidiTest.Text = "b";
            Application.Current.Dispatcher.Invoke(new Action(() => { MainWindow.WindowStuff.MidiTest.Text = "b"; }));
        }

        private void midiIn_MessageReceived(object sender, MidiInMessageEventArgs e) {

            if(e.MidiEvent.CommandCode == MidiCommandCode.NoteOn) {
                var temp = (NoteOnEvent)e.MidiEvent;
                NoteDown(temp.NoteNumber);
            } else if(e.MidiEvent.CommandCode ==  MidiCommandCode.NoteOff) {
                var temp2 = (NoteEvent)e.MidiEvent;
                var temp3 = temp2.NoteNumber;
            } else if(e.MidiEvent.CommandCode == MidiCommandCode.ControlChange) {
                var temp = (ControlChangeEvent)e.MidiEvent;
                SliderChange((int)temp.Controller, temp.ControllerValue);
            }
            Application.Current.Dispatcher.Invoke(new Action(() => { MainWindow.WindowStuff.MidiTest.Text = e.MidiEvent.ToString(); }));
        }

        private void NoteDown(int noteNumber) {

        }

        private void NoteUp(int noteNumber) {

        }

        private void SliderChange(int slider, int value) {
            Console.WriteLine("a");
        }

        public void Dispose() {
            DeviceIn.Stop();
            DeviceIn.Dispose();
        }
    }
}
