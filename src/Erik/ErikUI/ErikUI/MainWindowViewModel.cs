using CiphersMain.Ciphers;
using CiphersMain.Keys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ErikUI
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
		private string _ciphertext;
		public string Ciphertext
		{
			get { return _ciphertext; }
			set { _ciphertext = value; RaisePropertyChanged(); }
		}
		private string _plaintext;
        public string Plaintext
		{
			get { return _plaintext; }
			set { _plaintext = value; RaisePropertyChanged(); }
		}
        public event PropertyChangedEventHandler? PropertyChanged;
		public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}


		public void Decrypt(char[] keyChars)
		{
			var key = new CharacterKey(keyChars);
			var cipher = new SubstitutionCipher(key);
			Plaintext = cipher.Decrypt(Ciphertext);
		}
    }
}
