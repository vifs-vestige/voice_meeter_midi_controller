using System;
using System.Collections.Generic;
using System.Text;
using voice_meeter_midi_controller.Enums;
using Voicemeeter;

namespace voice_meeter_midi_controller {
    public interface VoiceMeeterBase {

        public RunVoicemeeterParam GetVersion();

        public VoiceMeeterChannel IndexToChannel(int index);

        public int ChannelToIndex(VoiceMeeterChannel channel);

        public List<int> GetIndexesForInputChannel(VoiceMeeterChannel channel);

        public List<int> GetIndexesForOutputChannel(VoiceMeeterChannel channel);
    }
}
