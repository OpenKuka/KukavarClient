using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kukavar.DemoApp
{
    class IconComboBox : ComboBox
    {

        public List<(string, Image)> Data { get; private set; }

        public IconComboBox()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
            DrawMode = DrawMode.OwnerDrawFixed;
        }
        
        public void SetData(List<(string, Image)> items)
        {
            Data = items;
            Items.AddRange(items.Select(t => t.Item1).ToArray());
        }
        
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            //base.OnDrawItem(e);
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index >= 0)
            {
                var h = this.Height - 8;
                if (e.Index < Data.Count)
                {
                    Image img = new Bitmap(Data[e.Index].Item2, new Size(h, h));
                    e.Graphics.DrawImage(img, new PointF(e.Bounds.Left, e.Bounds.Top));
                }
                e.Graphics.DrawString(string.Format(Data[e.Index].Item1)
                    , e.Font, new SolidBrush(e.ForeColor)
                    , e.Bounds.Left + h, e.Bounds.Top);
            }
        }

    }
}
