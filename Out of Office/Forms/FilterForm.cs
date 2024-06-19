using Out_of_Office.Models.Dto_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Out_of_Office.Forms
{
    public partial class FilterForm<T, F> : Form where F : Filter<T>
    {
        protected List<T> _collection;
        protected List<T> _filteredCollection;
        protected F _filters;
        public FilterForm(List<T> collection, F filters)
        {
            _collection = collection;
            _filters = filters;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected virtual void setButton_Click(object sender, EventArgs e)
        {
            //override 
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            _filters.ClearFilters();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //TODO
        }
    }
}
