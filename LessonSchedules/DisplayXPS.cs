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
        private bool _print;

        public DisplayXPS( FixedDocument fd, bool print ) {
            _fd = fd;
            InitializeComponent();
            _print = print;
        }

        private void LoadFile( object sender, EventArgs e ) {
            System.Windows.Controls.DocumentViewer dv = new System.Windows.Controls.DocumentViewer();
            dv.Document = _fd;
            elementHost1.Child = dv;

            if (_print)
                dv.Print();
        }        
    }
}
