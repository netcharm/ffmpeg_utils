using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFmpegConvertGUI
{
    public partial class ParamsForm : Form
    {
        public ParamsForm()
        {
            InitializeComponent();
        }

        internal void SetParams(string args)
        {
            edParams.Text = args;
        }

        internal string GetParams()
        {
            return ( edParams.Text );
        }

        private void edParams_KeyUp( object sender, KeyEventArgs e )
        {
            if ( e.Control && e.KeyCode == Keys.A )
            {
                edParams.SelectAll();
            }
        }
    }
}
