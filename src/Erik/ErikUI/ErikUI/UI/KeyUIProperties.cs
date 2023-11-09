using ErikCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErikUI
{
    public struct KeyLetterChangedEventArgs
    {
        public char Before { get; set; }
        public char After { get; set; }
    }
    internal class KeyUIProperties : ObservableObject
    {
        public event EventHandler<KeyLetterChangedEventArgs> LetterChanged;
        public void RaiseLetterChanged(char before, char after)
        {
            LetterChanged?.Invoke(this, new KeyLetterChangedEventArgs { Before = before, After = after});
        }
        public int Index { get; set; }
        private char _character = '\0';
        public char CharacterNoChanged
        {
            set { _character = value;
                RaisePropertyChanged(nameof(Text));
            }
        }
        public char Character
        {
            get { return _character; }
            set {
                RaiseLetterChanged(_character, value);
                Set(ref _character, value);
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
                    Character = newValue[0];
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
