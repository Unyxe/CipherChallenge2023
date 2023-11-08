using CiphersMain.Ciphers;
using CiphersMain.Keys;
using ErikCommon;
using FrequencyAnalysis;
using FrequencyAnalysis.Analysis;
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
        public IEnumerable<string> AlphabetByFrequency =>
            Utilities.ALPHABET_BY_FREQUENCY.Select(x => x.ToString());
        private ObservableCollection<FreqAnalysisLetter> _frequencyAnalysis;
        public ObservableCollection<FreqAnalysisLetter> FrequencyAnalysis
        {
            get { return _frequencyAnalysis; }
            set { Set(ref _frequencyAnalysis, value); }
        }

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
        private void _updateFrequencyAnalysis()
        {
            CustomFrequencyAnalysisResult result = FrequencyAnalyser.AnalyseText(Plaintext);
            FrequencyAnalysis.Clear();
            int c = 0;
            foreach(var letterPair in result.OrderByDescending(x => x.Value))
            {
                if (Utilities.ALPHABET.Contains(letterPair.Key[0]))
                    _frequencyAnalysis.Add(new FreqAnalysisLetter(letterPair.Key[0], letterPair.Value, Utilities.ALPHABET_BY_FREQUENCY[c++]));
            }
            RaisePropertyChanged(nameof(FrequencyAnalysis));
        }
        public void OnLoad()
        {
#if DEBUG
            Ciphertext = "The quick brown fox jumps over the lazy dog";
#endif
        }


        public void ResetKey()
        {
            KeyCharacters = new ObservableCollection<KeyUIProperties>(Enumerable.Range(0, 26).Select(i => new KeyUIProperties(i)));
            RaisePropertyChanged(nameof(KeyCharacters));
        }
        public void Decrypt()
        {
            var key = new CharacterKey(KeyCharacters.Select(x => x.Character).ToArray());
            Decrypt(key);
        }
        public void Decrypt(CharacterKey key)
        {
            Plaintext = "";
            if (_validateKey(key))
            {
                var cipher = new SubstitutionCipher(key);
                Plaintext = cipher.Decrypt(Ciphertext.ToUpper());
            }
            _updateFrequencyAnalysis();
        }
        public void GenKey()
        {
            var key = CharacterKey.CreateGoodKey(Utilities.CipherFormat(Ciphertext));
            for (int i = 0; i < key.Count; i++)
            {
                KeyCharacters[i].Character = key[Utilities.GetCharFromIndex(i)];
            }
            RaisePropertyChanged(nameof(KeyCharacters));
        }
        public MainWindowViewModel()
        {
            _frequencyAnalysis = new ObservableCollection<FreqAnalysisLetter>();
            ResetKey();
        }
    }
}
