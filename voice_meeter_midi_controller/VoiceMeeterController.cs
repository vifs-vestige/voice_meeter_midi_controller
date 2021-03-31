using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using voice_meeter_midi_controller.Enums;

namespace voice_meeter_midi_controller {
    class VoiceMeeterController : IDisposable {
        private Task VoiceMeeterConnection;
        private VoiceMeeterBase VoiceMeeterVersion;
        private DispatcherTimer Dispatcher;
        private MidiController Midi;

        public VoiceMeeterController(MidiController midi) {
            VoiceMeeterConnection = VoiceMeeter.Remote.Initialize(Voicemeeter.RunVoicemeeterParam.VoicemeeterPotato);
            VoiceMeeterVersion = new VMPotato();
            Dispatcher = new DispatcherTimer();
            Dispatcher.Tick += thingy;
            Dispatcher.Interval = new TimeSpan(0, 0, 0, 0, 5);
            Dispatcher.Start();
            Midi = midi;
        }

        public void Mute(BusType busType, int channel, bool mute) {
            VoiceMeeter.Remote.SetParameter($"{busType.GetString()}[{channel}].mute", mute ? 1 : 0);
        }

        public void SendInput(int inputChannel, VoiceMeeterChannel outputChannel, bool send) {

            VoiceMeeter.Remote.SetParameter($"strip[{inputChannel}].{outputChannel.GetName()}", send ? 1 : 0);
        }

        public void ChangeGain(BusType busType, int channel, float gain) {
            VoiceMeeter.Remote.SetParameter($"{busType.GetString()}[{channel}].gain", gain);
        }


        public float GetCurrentLevel(BusType busType, VoiceMeeterChannel channel) {
            Voicemeeter.LevelType levelType;
            List<int> indexes;
            if(busType == BusType.input) {
                levelType = Voicemeeter.LevelType.PostFaderInput;
                indexes = VoiceMeeterVersion.GetIndexesForInputChannel(channel);
            } else {
                levelType = Voicemeeter.LevelType.Output;
                indexes = VoiceMeeterVersion.GetIndexesForOutputChannel(channel);
            }
            float level = 0;
            List<float> levels = new List<float>();
            foreach (var item in indexes) {
                float temp = VoiceMeeter.Remote.GetLevel(levelType, item);
                levels.Add(temp);
                if (temp > level)
                    level = temp;
            }
            return level;

        }

        private void thingy(object sender, EventArgs e) {
            var temp = GetCurrentLevel(BusType.input, VoiceMeeterChannel.A1);
            Application.Current.Dispatcher.Invoke(new Action(() => { MainWindow.WindowStuff.MidiTest.Text = (temp*1000).ToString(); }));
            Midi.showVolumeLevel(temp);
        }

        public void Dispose() {
            VoiceMeeterConnection.Dispose();
        }




    }
}
