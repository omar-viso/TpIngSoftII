using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escritorio.Interfaces
{
    interface IFormOpener
    {
        void ShowModelessForm<TForm>() where TForm : Form;
    }
}
