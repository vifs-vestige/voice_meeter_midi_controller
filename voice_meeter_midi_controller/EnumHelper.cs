using System;
using System.Collections.Generic;
using System.Text;
using voice_meeter_midi_controller.Enums;

namespace voice_meeter_midi_controller {
    public static class EnumHelper {
        public static string GetString(this BusType bt) {
            if (bt == BusType.input)
                return "strip";
            return "bus";
        }

        public static string GetName<T>(this T genericEnum) where T : System.Enum {
            return Enum.GetName(typeof(T), genericEnum);
        }
    }
}
