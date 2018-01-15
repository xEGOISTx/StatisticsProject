using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace WPFHelper.Controls
{
    public abstract class ItemsSortByGridViewColumnHeader<TItem> : BaseViewModel
    {
        private ObservableCollection<TItem> _sortedList = new ObservableCollection<TItem>();
        private string _currentSortPropertyName;
        private bool _isAscending = true;

        #region Properties
        public string CurrentSortPropertyName
        {
            get { return _currentSortPropertyName; }
            set
            {
                _currentSortPropertyName = string.Empty;
                OnPropertyChanged(nameof(CurrentSortPropertyName));

                _currentSortPropertyName = value;
                OnPropertyChanged(nameof(CurrentSortPropertyName));
            }
        }

        public bool IsAscending
        {
            get { return _isAscending; }
            set
            {
                _isAscending = value;              
            }
        }

        public IEnumerable<TItem> SortedList { get; private set; }

        #endregion Properties



        #region Methods
        protected void Add(TItem item)
        {
            _sortedList.Add(item);
        }

        protected void AddRange(IEnumerable<TItem> items)
        {
            foreach(TItem item in items)
            {
                _sortedList.Add(item);
            }
        }

        public virtual void Remove(TItem item)
        {
            _sortedList.Remove(item);
        }

        protected void Clear()
        {
            _sortedList.Clear();
        }

        protected void SortByPropertyName(string propertyNeme)
        {
            CurrentSortPropertyName = propertyNeme;
            Sort();
        }

        protected void Sort()
        {
            if (IsAscending)
            {
                SortedList = _sortedList.OrderBy(item => item.GetType().GetProperty(CurrentSortPropertyName).GetValue(item));
            }
            else
            {
                SortedList = _sortedList.OrderByDescending(item => item.GetType().GetProperty(CurrentSortPropertyName).GetValue(item));
            }
        }

        protected bool IsPresent(TItem item)
        {
            return _sortedList.Contains(item);
        }
        #endregion Methods

    }
}
