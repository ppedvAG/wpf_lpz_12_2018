using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Books.Helper
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        //http://openbook.rheinwerk-verlag.de/visual_csharp_2012/1997_05_001.html#dodtp3fff44b2-cd1b-47b7-9a94-fbcb259a84b9
        Action<object> _execLogic;
        Func<object, bool> _canExecLogic;

        public DelegateCommand(Action<object> execLogic, Func<object, bool> canExecLogic = null)
        {
            _execLogic = execLogic;
            _canExecLogic = canExecLogic;
        }

        public bool CanExecute(object parameter)
        {
            if(_canExecLogic != null)
            {
                return _canExecLogic(parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            _execLogic?.Invoke(parameter);
        }
    }
}
