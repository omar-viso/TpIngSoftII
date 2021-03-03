using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Escritorio.Interfaces;
using SimpleInjector;

namespace Escritorio.Entities
{
    public class FormOpener : IFormOpener
    {
        private readonly Container container;
        private readonly Dictionary<Type, Form> openedForms;

        public FormOpener(Container container)
        {
            this.container = container;
            this.openedForms = new Dictionary<Type, Form>();
        }

        //public DialogResult ShowModalForm<TForm>() where TForm : Form
        //{
        //    using (var form = this.GetForm<TForm>())
        //    {
        //        return form.ShowDialog();
        //    }
        //}
        public void ShowModelessForm<TForm>() where TForm : Form
        {
            Form form;
            if (this.openedForms.ContainsKey(typeof(TForm)))
            {
                // a form can be held open in the background, somewhat like 
                // singleton behavior, and reopened/reshown this way
                // when a form is 'closed' using form.Hide()   
                form = this.openedForms[typeof(TForm)];
            }
            else
            {
                form = this.GetForm<TForm>();
                this.openedForms.Add(form.GetType(), form);
                // the form will be closed and disposed when form.Closed is called
                // Remove it from the cached instances so it can be recreated
                form.Closed += (s, e) => this.openedForms.Remove(form.GetType());
            }

            form.Show();
        }

        private Form GetForm<TForm>() where TForm : Form
        {
            return this.container.GetInstance<TForm>();
        }
    }
}
