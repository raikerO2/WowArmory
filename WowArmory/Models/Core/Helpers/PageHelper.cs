using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Models;
using WowArmory.Models.Core.Helpers;

namespace WowArmory.Factory
{
    public sealed class PageHelper
    {
        public int Start { get => _start; }
        public int End { get => _end; }
        public int Page { get => _page; }
        public int Pages { get => _pages; }
        public int NumberOfItems { get => _numberOfItems; }

        private int _skippedItems = 0;
        private bool _pressedSearch = false;

        private int _numberOfItems = 0;
        private int _pages = 0;
        private int _page = 1;
        private int _pageLimit = 20;
        private int _offset = 0;
        private int _start = 0;
        private int _end = 0;

        public PageHelper() { }
        public PageHelper(int pageLimit) { _pageLimit = pageLimit; }
        public void Startup<TDataType>(List<TDataType> items) where TDataType : class
        {
            Dispose();
            FirstResult<TDataType>(items);
            _numberOfItems = items.Count();
        }

        public void MoveToPage<TDataType>(List<TDataType> numberOfItems) where TDataType : class
        {
            _offset = (_page - 1) * _pageLimit;

            _start = _offset + 1;
            _end = Math.Min((_offset + numberOfItems.Count()), _numberOfItems);
        }

        public void Dispose()
        {
            _numberOfItems = 0;
            _pages = 0;
            _page = 1;
            _offset = 0;

            _start = 0;
            _end = 0;
        }

        private void FirstResult<TDataType>(List<TDataType> items) where TDataType : class
        {
            _pages = (int)Math.Ceiling(items.Count() / (double)_pageLimit);
            _offset = (_page - 1) * _pageLimit;

            _start = _offset + 1;
            _end = Math.Min((_offset + _pageLimit), items.Count());
        }

    }
}
