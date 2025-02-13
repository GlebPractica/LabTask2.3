﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Task1
{
    public partial class Payments : Form
    {
        private Thread th;

        public Payments()
        {
            InitializeComponent();
        }

        private void paymentTblBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.paymentTblBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.gymDbDataSet);
            MessageBox.Show("Успешно сохранено!", "Результат");
        }

        private void Payments_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "gymDbDataSet.PaymentTbl". При необходимости она может быть перемещена или удалена.
            this.paymentTblTableAdapter.Fill(this.gymDbDataSet.PaymentTbl);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "gymDbDataSet.PaymentTbl". При необходимости она может быть перемещена или удалена.
            this.paymentTblTableAdapter.Fill(this.gymDbDataSet.PaymentTbl);
        }

        private void Payments_FormClosed(object sender, FormClosedEventArgs e) => OpenMenu();

        private void OpenMenu()
        {
            th = new Thread(Menu);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void Menu() => Application.Run(new Form1());

        private void paymentTblBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.paymentTblBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.gymDbDataSet);

        }
    }
}
//ConfigurationManager.ConnectionStrings["GymDbConnectionString"].ConnectionString