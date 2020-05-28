using GeneralLibrary.Commands;
using GeneralLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomButtonCommand.ViewModels
{
	public class CalculationViewModel : ViewModelBase
	{
		private int _number1;
		private int _number2;
		private int _total;
		private int _add10;
		public DelegateCommand FindTotalCmd { get; set; }

		public int Number1
		{
			get { return _number1; }
			set
			{
				_number1 = value;
				OnPropertyChanged();
			}
		}

		public int Number2
		{
			get { return _number2; }
			set
			{
				_number2 = value;
				OnPropertyChanged();
			}
		}

		public int Total
		{
			get { return _total; }
			set
			{
				_total = value;
				OnPropertyChanged();
			}
		}

		public int Add10
		{
			get { return _add10; }
			set
			{
				_add10 = value;
				OnPropertyChanged();
			}
		}

		public CalculationViewModel()
		{
			Add10 = 10;
			FindTotalCmd = new DelegateCommand(obj => FindTotal(obj));

			//FindSum = new DelegateCommand(obj => FindTotal(obj));

		}

		private void FindTotal(object obj)
		{
			Total = Number1 + Number2 + (int)obj;
		}




	}
}
