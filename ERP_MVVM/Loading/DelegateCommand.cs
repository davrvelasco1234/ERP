using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace ERP_MVVM.Loading
{
    internal class DelegateCommand : ICommand
    {
        #region Fields
        private readonly Action _executeMethod;
        private readonly Func<bool> _canExecuteMethod;
        private List<WeakReference> _canExecuteChangedHandlers;
        #endregion


        #region Constructors
        public DelegateCommand(Action executeMethod) : this(executeMethod, null)
        {
        }
        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException("executeMethod");
            }

            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        #endregion


        #region Events
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManagerHelper.AddWeakReferenceHandler(ref _canExecuteChangedHandlers, value);
            }
            remove
            {
                CommandManagerHelper.RemoveWeakReferenceHandler(_canExecuteChangedHandlers, value);
            }
        }
        #endregion


        #region ICommand
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        void ICommand.Execute(object parameter)
        {
            Execute();
        }

        #endregion


        #region Methods
        public bool CanExecute()
        {
            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod();
            }

            return true;
        }

        public void Execute()
        {
            if (_executeMethod != null)
            {
                _executeMethod();
            }
        }

        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }

        protected virtual void OnCanExecuteChanged()
        {
            CommandManagerHelper.CallWeakReferenceHandlers(_canExecuteChangedHandlers);
        }
        #endregion
    }
}
