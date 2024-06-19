using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Helpers
{
    public static class ExceptionHelper
    {
        public static void HandleException(Action action, string errorMessage)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{errorMessage}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
