﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Interop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            IFactory fac = new Factory();
            var factory = Marshal.GetIUnknownForObject(fac);
            var iid = new Guid("E40FFD0D-3019-4ADF-AC48-800F3ACFA360");
            IntPtr ifac;
            var hr = Marshal.QueryInterface(factory, ref iid, out ifac);
            var oo = Marshal.GetObjectForIUnknown(ifac);
            Build(ifac);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        [DllImport("driver.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Frob(int n);


        [DllImport("driver.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Build([In] IntPtr var);

    }
}
