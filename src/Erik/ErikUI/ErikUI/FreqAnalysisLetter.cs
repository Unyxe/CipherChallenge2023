using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErikUI
{
    internal class FreqAnalysisLetter : ObservableObject
    {
		private double _value;

		public double Value
		{
			get { return _value; }
			set { Set(ref _value, value); }
		}
		private string _letter = "";
		public string Letter
		{
			get { return _letter; }
			set { _letter = value; }
		}
	}
}
