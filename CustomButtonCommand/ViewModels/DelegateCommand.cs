using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GeneralLibrary.Commands
{
	public class DelegateCommand : ICommand
	{
		private Action<object> _action;
		private bool _canExecute = true;
		private Predicate<object> _canExecutePredicate;

		public DelegateCommand(Action<object> executeAction)
		{
			_action = executeAction;
		}

		public DelegateCommand()
		{
			//_action = true;
		}

		public DelegateCommand(Action<object> executeAction, Predicate<object> canExecutePredicate)
		{
			_action = executeAction;
			_canExecutePredicate = canExecutePredicate;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return _canExecutePredicate != null ? _canExecutePredicate.Invoke(parameter) && _canExecute : _canExecute;
		}

		public void Execute(object parameter)
		{
			_action(parameter);
		}
	}
}
