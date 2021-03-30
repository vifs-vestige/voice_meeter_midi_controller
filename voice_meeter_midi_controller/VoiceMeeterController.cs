using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using voice_meeter_midi_controller.Enums;

namespace voice_meeter_midi_controller {
    class VoiceMeeterController : IDisposable {
        private Task VoiceMeeterConnection;
        private VoiceMeeterBase VoiceMeeterVersion;

        public VoiceMeeterController() {
            VoiceMeeterConnection = VoiceMeeter.Remote.Initialize(Voicemeeter.RunVoicemeeterParam.VoicemeeterPotato);
            VoiceMeeterVersion = new VMPotato();
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

        public void Dispose() {
            VoiceMeeterConnection.Dispose();
        }




    }
}
