using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Models;
using WowArmory.Models.Core.Helpers;

//Fix namescape issue
namespace WowArmory.Factory
{
    public sealed class PageHelper
    {
        public int Start { get => _start; }
        public int End { get => _end; }
        public int Page { get => _page; }
        public int Pages { get => _pages; }
        public int NumberOfItems { get => _numberOfItems; }
        public int PageLimit { get => _pageLimit; }
        public bool PressedNext { get => _pressedNext; }
        public string Name { get => _name; }
        public int SkippedItems { get => _skippedItems; }

        private static int _skippedItems = 0;
        private static bool _pressedNext = false;

        private static int _numberOfItems = 0;
        private static int _pages = 0;
        private static int _page = 1;
        private static int _pageLimit = 20;
        private static int _offset = 0;
        private static int _start = 0;
        private static int _end = 0;
        private static string _name = null;

        public PageHelper() { }
        public PageHelper(int pageLimit) { _pageLimit = pageLimit; }

        public void Startup<TDataType>(List<TDataType> allItems, string contains) where TDataType : class
        {
            Dispose(DisposeComponent.Search);
            FirstResult<TDataType>(allItems);
            _numberOfItems = allItems.Count();
            _name = contains;
            _pressedNext = false;
        }

        public void Startup<TDataType>(List<TDataType> items) where TDataType : class
        {
            Dispose(null);
            FirstResult<TDataType>(items);
            _numberOfItems = items.Count();
        }

        public bool PreviousPage<TDataType>(List<TDataType> items) where TDataType : class
        {
            if (_skippedItems > 0)
                _skippedItems -= _pageLimit;

            if (_skippedItems > 0)
            {
                _skippedItems -= _pageLimit;
                _pressedNext = true;

                if(_page > 1)
                {
                    _page--;
                    MoveToPage<TDataType>(items);
                }
                return true;
            }
            else
            {
                _pressedNext = false;
                MoveToPage<TDataType>(items);
                return false;
            }
        }

        public void NextPage<TDataType>(List<TDataType> items) where TDataType : class
        {
            _skippedItems += _pageLimit;
            _pressedNext = true;

            if(items.Count() == 0)
            {
                _skippedItems -= _pageLimit;
            }
            else
            {
                if(_page < _pages)
                {
                    _page++;
                    MoveToPage<TDataType>(items);
                }
            }

        }

        public void MoveToPage<TDataType>(List<TDataType> numberOfItems) where TDataType : class
        {
            _offset = (_page - 1) * _pageLimit;

            _start = _offset + 1;
            _end = Math.Min((_offset + numberOfItems.Count()), _numberOfItems);
        }
        
        public void Dispose(DisposeComponent? disposer)
        {
            switch(disposer)
            {
                case DisposeComponent.Search:
                     _numberOfItems = 0;
                    _pages = 0;
                    _page = 1;
                    _offset = 0;
                    _pressedNext = false;
                    break;
                case DisposeComponent.Pagination:
                    _pressedNext = false;
                    _name = null;
                    break;
                default:
                    _numberOfItems = 0;
                    _pages = 0;
                    _page = 1;
                    _offset = 0;
                    _start = 0;
                    _end = 0;
                    _pressedNext = false;
                    _name = null;
                    _skippedItems = 0;
                    break;
            }
        }

        private void FirstResult<TDataType>(List<TDataType> items) where TDataType : class
        {
            _pages = (int)Math.Ceiling(items.Count() / (double)_pageLimit);
            _offset = (_page - 1) * _pageLimit;

            _start = _offset + 1;
            _end = Math.Min((_offset + _pageLimit), items.Count());
        }

        private void SetItemName(string name)
        {
            _name = name;
        }

    }
    public enum DisposeComponent
    {
        Search,
        Pagination
    }
}
