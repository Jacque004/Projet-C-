﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppGMmatos
{
    public partial class Formclient : Form
    {
        public Formclient()
        {
            InitializeComponent();
        }

        private void Clients_Click(object sender, EventArgs e)
        {
            Formclient dlg = new Formclient();
            dlg.ShowDialog();
        }
    }
}
