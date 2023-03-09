using ServerHelper.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerHelper
{
    public static class FormManager
    {
        public static List<IForm> Forms { get; private set; } = new List<IForm>();

        public static void RegisterForms(List<IForm> modules)
        {
            foreach (var m in modules)
            {
                RegisterForm(m);
            }
        }
        public static void RegisterForm(IForm form)
        {
            if (Forms.Contains(form))
                throw new ArgumentException($"Форма {form} уже зарегистрирована");

            Forms.Add(form);
        }
        public static IEnumerable<Control> GetAllControls(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControls(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }


    }
}
