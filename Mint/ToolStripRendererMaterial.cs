using System.Drawing;
using System.Windows.Forms;

namespace Mint
{
    internal class ToolStripRendererMaterial : ToolStripProfessionalRenderer
    {
        internal ToolStripRendererMaterial() : base(new ColorsMaterial())
        {

        }


        //protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        //{
        //    var tsMenuItem = e.Item as ToolStripMenuItem;
        //    if (tsMenuItem != null)
        //        e.TextColor = Color.GhostWhite;
        //    base.OnRenderItemText(e);
        //}

        //protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        //{
        //    var tsMenuItem = e.Item as ToolStripMenuItem;
        //    if (tsMenuItem != null)
        //        e.Graphics.bru
        //    base.OnRenderSeparator(e);
        //}

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            var tsMenuItem = e.Item as ToolStripMenuItem;
            if (tsMenuItem != null)
                e.ArrowColor = Color.GhostWhite;
            base.OnRenderArrow(e);
        }
    }

    internal class ColorsMaterial : ProfessionalColorTable
    {
        public override Color ToolStripDropDownBackground
        {
            get
            {
                return Options.BackgroundColor;
            }
        }

        public override Color ImageMarginGradientBegin
        {
            get
            {
                return Options.BackgroundColor;
            }
        }
        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return Options.BackgroundColor;
            }
        }
        public override Color ImageMarginGradientEnd
        {
            get
            {
                return Options.BackgroundColor;
            }
        }

        public override Color ToolStripBorder
        {
            get
            {
                return Options.BackgroundColor;
            }
        }

        public override Color MenuBorder
        {
            get
            {
                return Options.ForegroundAccentColor;
            }
        }

        public override Color MenuItemSelected
        {
            get
            {
                return Options.ForegroundAccentColor;
            }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return Options.ForegroundAccentColor;
            }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return Options.ForegroundAccentColor;
            }
        }

        public override Color MenuItemBorder
        {
            get
            {
                return Options.ForegroundAccentColor;
            }
        }
    }
}
