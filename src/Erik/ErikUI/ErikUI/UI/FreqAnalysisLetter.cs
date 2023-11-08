using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErikUI
{
    internal class FreqAnalysisLetter : ObservableObject, IComparable<FreqAnalysisLetter>
    {
		private double _value;
		public double Value
		{
			get { return _value; }
			set { Set(ref _value, value); }
		}

		public double Length
        {
			get => Value * 80;
        }

		public string Value3 {
			get => string.Format("{0:0.###}",Value);
		}

        private char _correspondingChar;

        public char CorrespondingChar
        {
            get { return _correspondingChar == '\0'?Char:_correspondingChar; }
            set { _correspondingChar = value; }
        }


        private char _char = '\0';
		public char Char
        {
			get { return _char; }
			set { 
				Set(ref _char, value); 
			}
        }
        public FreqAnalysisLetter(char letter, double frequency)
        {
			Char = letter;
			Value = frequency;
        }
        public FreqAnalysisLetter(char letter, double frequency, char correspondingLetter)
        {
            Char = letter;
            Value = frequency;
            CorrespondingChar = correspondingLetter;
        }
        public int CompareTo(FreqAnalysisLetter? other)
        {
			if (other == null)
				return 1;
            if (other.Value < Value)
				return -1;
			else if (other.Value > Value)
				return 1;
			else
				return 0;
        }
    }
}
