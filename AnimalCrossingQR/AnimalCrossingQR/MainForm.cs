﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnimalCrossingQR
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            byte[] rawData =
            {
                0x40, 0x26, 0xC4, 0x90, 0x07, 0x30, 0x06, 0x10, 0x06, 0x20, 0x06, 0x50, 0x06, 0xC0, 0x06, 0xC0, 
                0x06, 0x50, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0x19, 0x04, 0xE0, 
                0x06, 0x90, 0x06, 0xE0, 0x07, 0x40, 0x06, 0x50, 0x06, 0xE0, 0x06, 0x40, 0x06, 0xF0, 0x00, 0x00, 
                0x00, 0x00, 0x0B, 0x7E, 0xA4, 0xE0, 0x06, 0x90, 0x06, 0xE0, 0x07, 0x40, 0x06, 0x50, 0x06, 0xE0, 
                0x06, 0x40, 0x06, 0xF0, 0x00, 0x00, 0x00, 0x10, 0x03, 0x10, 0x07, 0x17, 0x52, 0x37, 0x04, 0xF2, 
                0x16, 0x11, 0x46, 0x3A, 0x12, 0x41, 0x30, 0xF6, 0x36, 0x2C, 0x40, 0xA0, 0x90, 0x00, 0x01, 0x99, 
                0x19, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x91, 0x91, 0x19, 0x99, 
                0x99, 0x99, 0x99, 0x99, 0x92, 0x22, 0x29, 0x29, 0x99, 0x99, 0x99, 0x99, 0x91, 0x91, 0x19, 0x99, 
                0x99, 0x99, 0x99, 0x92, 0x92, 0x22, 0x26, 0x29, 0x99, 0x99, 0x99, 0x99, 0x91, 0x91, 0x19, 0x9A, 
                0x99, 0xA9, 0x99, 0x92, 0x90, 0x20, 0x02, 0x22, 0x69, 0x29, 0x99, 0x99, 0x91, 0x91, 0x19, 0x9A, 
                0x99, 0xAA, 0xA9, 0x92, 0x90, 0x00, 0x02, 0x02, 0x22, 0x29, 0x99, 0x99, 0x99, 0x99, 0x9A, 0x9A, 
                0xA9, 0xAA, 0xA9, 0x91, 0x90, 0x00, 0x02, 0x00, 0x02, 0x09, 0x90, 0x99, 0x09, 0x99, 0x9A, 0x99, 
                0xA9, 0x9A, 0xA9, 0x91, 0x90, 0x00, 0x00, 0x00, 0x01, 0x09, 0x90, 0x99, 0x09, 0x99, 0x99, 0x99, 
                0x99, 0x99, 0x99, 0x99, 0x90, 0x10, 0x00, 0x00, 0x09, 0x10, 0x90, 0x09, 0x00, 0x09, 0x99, 0x9A, 
                0x9A, 0xA9, 0x99, 0x99, 0x99, 0x91, 0x11, 0x11, 0x19, 0x90, 0x99, 0x09, 0x90, 0x09, 0x99, 0x9A, 
                0x9A, 0xA9, 0x99, 0x99, 0x9C, 0x9B, 0x4B, 0xB9, 0xB9, 0x90, 0x99, 0x09, 0x90, 0x09, 0x99, 0x9A, 
                0x9A, 0xA9, 0x99, 0x99, 0x94, 0x97, 0x47, 0x79, 0x79, 0x99, 0x90, 0x90, 0x09, 0x99, 0x99, 0x99, 
                0x99, 0x99, 0x99, 0x90, 0x50, 0x00, 0x00, 0x00, 0x05, 0x09, 0x90, 0x90, 0x09, 0x99, 0x99, 0x99, 
                0x99, 0x99, 0x90, 0x50, 0x00, 0x00, 0x00, 0x00, 0x00, 0x05, 0x00, 0x90, 0x09, 0x99, 0x99, 0x99, 
                0x99, 0x92, 0x90, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x09, 0x29, 0x99, 0x99, 0x99, 0x99, 
                0x99, 0x90, 0x20, 0x00, 0x00, 0x01, 0x10, 0x10, 0x00, 0x10, 0x02, 0x09, 0x99, 0x99, 0x99, 0x99, 
                0x92, 0x90, 0x21, 0x00, 0x01, 0x00, 0x11, 0x10, 0x01, 0x10, 0x02, 0x09, 0x29, 0x99, 0x99, 0x99, 
                0x92, 0x20, 0x21, 0x10, 0x01, 0x10, 0x01, 0x00, 0x11, 0x10, 0x12, 0x02, 0x29, 0x99, 0x99, 0x96, 
                0x92, 0x21, 0x20, 0x11, 0x10, 0x10, 0x00, 0x01, 0x10, 0x11, 0x12, 0x12, 0x29, 0x69, 0x99, 0x92, 
                0x62, 0x22, 0x20, 0x0D, 0xD0, 0x00, 0x00, 0x00, 0x0D, 0xE0, 0x02, 0x22, 0x26, 0x29, 0x99, 0x92, 
                0x22, 0x22, 0x2E, 0x0E, 0xC0, 0x00, 0x00, 0x00, 0x0E, 0xC0, 0xD2, 0x22, 0x22, 0x29, 0x96, 0x92, 
                0x22, 0x26, 0x20, 0x0E, 0xE0, 0x00, 0x00, 0x00, 0x0E, 0xE0, 0x02, 0x22, 0x22, 0x29, 0x66, 0x92, 
                0x22, 0x26, 0x20, 0x0D, 0xE0, 0x0C, 0xCC, 0xC0, 0xCD, 0xE0, 0x02, 0xA2, 0x22, 0x29, 0x62, 0x92, 
                0x22, 0x20, 0x60, 0x00, 0x0C, 0x0E, 0xCC, 0xE0, 0xC0, 0x00, 0x0A, 0x02, 0x22, 0x29, 0x22, 0x92, 
                0x22, 0x2A, 0x00, 0xAC, 0x0C, 0xCD, 0xCC, 0xDC, 0xC0, 0x0A, 0x00, 0xA2, 0x22, 0x29, 0x26, 0x92, 
                0x22, 0x20, 0x00, 0x0C, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xC0, 0x00, 0x02, 0x22, 0x29, 0x69, 0x92, 
                0x62, 0x20, 0x00, 0x0C, 0xC8, 0xCC, 0xCC, 0xCC, 0x8C, 0xC0, 0x00, 0x02, 0x26, 0x29, 0x99, 0x99, 
                0x96, 0x60, 0x00, 0x0C, 0xCC, 0xCC, 0xEE, 0xCC, 0xCC, 0xC0, 0xC0, 0x06, 0x69, 0x99, 0x99, 0x99, 
                0x99, 0x90, 0x10, 0x0C, 0xCC, 0xCE, 0xCC, 0xEC, 0xCC, 0xC0, 0xC1, 0x09, 0x99, 0x99, 0x99, 0x19, 
                0x99, 0x91, 0x90, 0x0C, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xC0, 0xC9, 0x19, 0x99, 0x91, 0x99, 0x19, 
                0x99, 0x99, 0x91, 0x93, 0x03, 0x33, 0x33, 0x33, 0x33, 0x39, 0x19, 0x99, 0x91, 0x11, 0x99, 0x19, 
                0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x91, 0x11, 0x91, 0x99, 
                0x19, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x99, 0x90, 0xEC, 
                0x11, 0xEC, 0x11
            };

            MemoryStream ms = new MemoryStream(rawData);
            BinaryReader br = new BinaryReader(ms);

            Pattern p = new Pattern(br);
        }
    }
}