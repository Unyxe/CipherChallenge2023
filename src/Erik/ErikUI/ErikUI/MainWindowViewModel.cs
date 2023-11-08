using CiphersMain.Ciphers;
using CiphersMain.Keys;
using ErikCommon;
using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ErikUI
{
    internal class MainWindowViewModel : ObservableObject
    {
        private ObservableCollection<KeyUIProperties> _keyCharacters;

        public ObservableCollection<KeyUIProperties> KeyCharacters
        {
            get { return _keyCharacters; }
            set { _keyCharacters = value; }
        }
        private ICommand _decryptCommand;
        public ICommand DecryptCommand
        {
            get
            {
                return _decryptCommand ?? (_decryptCommand = new ActionCommand(() => Decrypt()));
            }
        }
        private string _ciphertext = "";
        public string Ciphertext
        {
            get { return _ciphertext; }
            set { Set(ref _ciphertext, value); }
        }
        private string _plaintext ="";
        public string Plaintext
        {
            get { return _plaintext; }
            set { Set(ref _plaintext, value); }
        }
        private bool _validateKey(CharacterKey key)
        {
            bool valid = true;
            for (int i = 0; i < 26; i++)
            {
                char letter = Utilities.GetCharFromIndex(i);
                if (!key.ContainsValue(letter))
                {
                    valid = false;
                    Plaintext += $"Key value {letter} is undefined\n";
                }
            }
            return valid;
        }
        public void Decrypt()
        {
            Plaintext = "";
            var key = new CharacterKey(KeyCharacters.Select(x => x.Character).ToArray());
            if (_validateKey(key))
            {
                var cipher = new SubstitutionCipher(key);
                Plaintext = cipher.Decrypt(Utilities.CipherFormat(Ciphertext));
            }
        }
        public MainWindowViewModel()
        {
            _keyCharacters = new ObservableCollection<KeyUIProperties>(Enumerable.Range(0,26).Select(i => new KeyUIProperties(i)));
        }
    }
}
