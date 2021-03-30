using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;
using voice_meeter_midi_controller.Enums;
using Voicemeeter;

namespace voice_meeter_midi_controller {
    public class VMPotato : VoiceMeeterBase {

        public RunVoicemeeterParam GetVersion() {
            return Voicemeeter.RunVoicemeeterParam.VoicemeeterPotato;
        }

        public VoiceMeeterChannel IndexToChannel(int index) {
            return (VoiceMeeterChannel)index;
        }

        public int ChannelToIndex(VoiceMeeterChannel channel) {
            return (int)channel;
        }

        public List<int> GetIndexesForInputChannel(VoiceMeeterChannel channel) {
            List<int> indexes = null;
            switch (channel) {
                case VoiceMeeterChannel.A1:
                    indexes = new List<int>() { 0, 1 };
                    break;
                case VoiceMeeterChannel.A2:
                    indexes = new List<int>() { 2, 3 };
                    break;
                case VoiceMeeterChannel.A3:
                    indexes = new List<int>() { 3, 4 };
                    break;
                case VoiceMeeterChannel.A4:
                    indexes = new List<int>() { 5, 6 };
                    break;
                case VoiceMeeterChannel.A5:
                    indexes = new List<int>() { 7, 8 };
                    break;
                case VoiceMeeterChannel.B1:
                    indexes = new List<int>() { 9, 10, 11, 12};
                    break;
                case VoiceMeeterChannel.B2:
                    indexes = new List<int>() { 13,14,15,16 };
                    break;
                case VoiceMeeterChannel.B3:
                    indexes = new List<int>() { 17,18,19,20 };
                    break;
            }
            return indexes;
        }

        public List<int> GetIndexesForOutputChannel(VoiceMeeterChannel channel) {
            List<int> indexes = null;
            switch (channel) {
                case VoiceMeeterChannel.A1:
                    indexes = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
                    break;
                case VoiceMeeterChannel.A2:
                    indexes = new List<int>() { 8, 9, 10, 11, 12, 13, 14, 15 };
                    break;
                case VoiceMeeterChannel.A3:
                    indexes = new List<int>() { 16, 17, 18, 19, 20, 21, 22, 23 };
                    break;
                case VoiceMeeterChannel.A4:
                    indexes = new List<int>() { 24,25,26,27,28,29,30,31 };
                    break;
                case VoiceMeeterChannel.A5:
                    indexes = new List<int>() { 32,33,34,35,36,37,38,39 };
                    break;
                case VoiceMeeterChannel.B1:
                    indexes = new List<int>() { 40,41,42,43,44,45,46,47 };
                    break;
                case VoiceMeeterChannel.B2:
                    indexes = new List<int>() { 48,49,50,51,52,53,54,55 };
                    break;
                case VoiceMeeterChannel.B3:
                    indexes = new List<int>() { 56,57,58,59 };
                    break;
            }
            return indexes;
        }
    }
}
