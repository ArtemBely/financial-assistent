using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Utilities
{
    public class ListViewItemComparer : IComparer
    {
        private readonly int _colIndex;
        private readonly SortOrder _order;

        public ListViewItemComparer(int columnIndex, SortOrder order)
        {
            _colIndex = columnIndex;
            _order = order;
        }

        public int Compare(object x, object y)
        {
            int returnVal = -1;
            returnVal = String.Compare(
                ((ListViewItem)x).SubItems[_colIndex].Text,
                ((ListViewItem)y).SubItems[_colIndex].Text
            );
            if (_order == SortOrder.Descending)
                returnVal *= -1;
            return returnVal;
        }
    }

}
