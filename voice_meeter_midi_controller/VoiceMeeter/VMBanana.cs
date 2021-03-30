using System;
using System.Collections.Generic;
using System.Text;
using voice_meeter_midi_controller.Enums;
using Voicemeeter;

namespace voice_meeter_midi_controller {
    class VMBanana {


        public RunVoicemeeterParam GetVersion() {
            return Voicemeeter.RunVoicemeeterParam.VoicemeeterBanana;
        }

        public VoiceMeeterChannel IndexToChannel(int index) {
            return (VoiceMeeterChannel)index;
        }

        public int ChannelToIndex(VoiceMeeterChannel channel) {
            return (int)channel;
        }
    }
}
