using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherCommon.Keys
{
    public class CharacterKey : Key<char>
    {
        private Dictionary<char, char> _forward = new Dictionary<char, char>();
        private Dictionary<char, char> _reverse = new Dictionary<char, char>();
        public CharacterKey(char[] values) : base(values) { }
        public char Forward(char key) { return _forward[key]; }
        public char Reverse(char key) { return _reverse[key]; }
        public void SetForward(char key, char value)
        {
            Values[key] = value;
            _forward[key] = value;
            _reverse[value] = key;
        }
        public void SetReverse(char key, char value)
        {
            Values[value] = key;
            _reverse[key] = value;
            _forward[value] = key;
        }
    }
}
