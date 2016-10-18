using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AudioBookMH
{
    class FontStyleOptions
    {
        private Font defaultfont = new Font("Ariel", 16, FontStyle.Regular, GraphicsUnit.Pixel);

        public Font DefaultFont
        {
            get { return defaultfont; }
        }
    }
}
