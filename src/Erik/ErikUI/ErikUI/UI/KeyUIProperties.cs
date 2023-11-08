using ErikCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErikUI
{
    internal class KeyUIProperties : ObservableObject
    {
        public int Index { get; set; }
        private char _character = '\0';

        public char Character
        {
            get { return _character; }
            set { Set(ref _character, value);
                RaisePropertyChanged(nameof(Text));
            }
        }

        public string Header { get => $"{Index}:{Utilities.GetCharFromIndex(Index)}"; }
        public string Text
        {
            get { 
                return Character.ToString(); 
            }
            set 
            {
                string newValue = Utilities.CipherFormat(value.Substring(value.Length - 1));
                if (!string.IsNullOrEmpty(newValue))
                {
                    Set(ref _character, newValue[0]);
                    RaisePropertyChanged(nameof(Character));
                }
            }
        }
        public KeyUIProperties(int index)
        {
            Index = index;
            Character = Utilities.GetCharFromIndex(index);
        }
    }
}
