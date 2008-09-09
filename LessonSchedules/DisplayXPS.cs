using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Documents;

namespace LessonSchedules {
    public partial class DisplayXPS : Form {
        private FixedDocument _fd;

        public DisplayXPS( FixedDocument fd ) {
            _fd = fd;
            InitializeComponent();
        }

        private void LoadFile( object sender, EventArgs e ) {
            //XPSViewer.Url = new Uri( _fileName );
            System.Windows.Controls.DocumentViewer dv = new System.Windows.Controls.DocumentViewer();
            dv.Document = _fd;
            elementHost1.Child = dv;
        }        
    }
}
