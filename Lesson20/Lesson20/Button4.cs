using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson20
{
    delegate void ClickedDelegate();

    class Button4
    {
        public event ClickedDelegate clicked;

        public string text { get; set; }
        public int color { get; set; }
        public int poition { get; set; }

        public void detectClick()
        {
            clicked();
        }
    }
}
