using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWorkCarpet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }
        
        string Name;
        string Phone;
        string Address;

        int Amount;
        int Area;
        DateTime EntryDate;
        DateTime DeliveryDate;
        int Price;

        

        //Adet Bilgisi
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Amount = (int)numericUpDown1.Value;
            DateTime Date = Calculator.CalculateDeliveryDate(DateTime.Now,Amount);
            dateTimePicker2.Value = Date;
        }

        //Alan Bilgisi
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Area = (int)numericUpDown2.Value;
            Price = Calculator.CalculatePrice(Area);
            textBox5.Text = Price.ToString()+"₺";
        }

        //Alım Tarihi
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime Date = Calculator.CalculateDeliveryDate(dateTimePicker1.Value, Amount);
            dateTimePicker2.Value = Date;
        }
       

        //Giriş Butonu
        //-------------
        //-------------
        //-------------
        //Giriş Butonu

        private void button1_Click(object sender, EventArgs e)
        {
            if (isValidFields())
            {
                return;
            }
            //Müşteri Bilgileri
            Name = textBox1.Text;
            Phone = textBox2.Text;
            Address = textBox3.Text;

            Amount = (int)numericUpDown1.Value;
            Area = (int)numericUpDown2.Value;
            EntryDate = dateTimePicker1.Value;
            DeliveryDate = dateTimePicker2.Value;
            Price = Calculator.CalculatePrice(Area);
            int Id=FileOperations.CountLines();

            Carpet carpet = new Carpet(Amount, Area, EntryDate, DeliveryDate, Price);
            Person person = new Person(Id,Name, Phone, Address, Amount, Area, Price, carpet);
            
            string PersonInfo = $"Id: {person.Id},0, Name: {person.Name}, Phone: {person.Phone}, Address: {person.Address}, Amount: {carpet.Amount}, Area: {carpet.Area}, EntryDate: {carpet.OrderDate.ToShortDateString()}, DeliveryDate: {carpet.DeliveryDate.ToShortDateString()}, Price: {carpet.Price}₺";
            
            FileOperations.WriteToFile(PersonInfo);
            //textBox6.Text += $"{person.Name} {person.Phone} {person.Address} {carpet.DeliveryDate} {carpet.Price}₺ \n \n";
            MessageBox.Show($"Müşteri Bilgileri Kaydedildi\n Müşteri No: {person.Id}");
            fieldClear();
        }
        //Dosya Temizleme
        private void button2_Click(object sender, EventArgs e)
        {
            FileOperations.ClearFile();
            MessageBox.Show("Dosya Temizlendi");
        }
        //Müşteri sorgula
        private void button5_Click(object sender, EventArgs e)
        {
           string line=FileOperations.FindCustomer((int)numericUpDown3.Value);
            if (line == null)
            {
                MessageBox.Show("Müşteri Bulunamadı");
                textBox4.Clear();
                textBox7.Clear();
                textBox4.BackColor = Color.White;
                textBox4.Text = "?";
            }
            else
            {
                string [] information = line.Split(',');
                string txt =
                   " "+information[0] + "\r\n" + information[2] + "\r\n"
                    + information[3] + "\r\n" + information[4] + "\r\n"
                    + information[5] + "\r\n" + information[8] + "\r\n"
                    + information[9];
                int status = FileOperations.StatusControl((int)numericUpDown3.Value);
                if (status == 0)
                {
                    textBox4.Text = "Yıkamada";
                    textBox4.BackColor = Color.Red;
                }
                else
                {
                    textBox4.Text = "Yıkandı";
                    textBox4.BackColor = Color.Green;
                }
                textBox7.Text =txt;
            }

        }
       

        //yıkandı listele
        private void button3_Click(object sender, EventArgs e)
        {
            string txt =FileOperations.ReadWashed();
            if (txt == null || txt == "")
            {
                MessageBox.Show("Yıkanmış Halı Bulunamadı!");
            }
            else
            {
                textBox6.Text = txt;
                MessageBox.Show("Yıkanmış Halılar Listelendi");
            }
        }
        //yıkanmadı
        private void button4_Click(object sender, EventArgs e)
        {
            string txt=FileOperations.ReadUnwashed();
            if (txt == null || txt=="")
            {
                MessageBox.Show("Yıkamada Halı Bulunamadı!");
            }
            else
            {
                textBox6.Text = txt;
                MessageBox.Show("Yıkamadaki Halılar Listelendi");
            }
        }

      

        private void button6_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
        }
        //Müşteri Güncelle
        private void button7_Click(object sender, EventArgs e)
        {
            string line=FileOperations.FindCustomer((int)numericUpDown3.Value);
            if (line == null)
            {
                MessageBox.Show("Müşteri Bulunamadı");
                return;
            }
            else
            {
                FileOperations.StatusUpdate((int)numericUpDown3.Value);
                textBox4.BackColor = Color.Green;
                textBox4.Text = "Yıkandı";
                MessageBox.Show("Halı Yıkaması Bitirildi");
            }
        }
       
       

        //Telefonun hepsi rakam mı
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void fieldClear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            dateTimePicker1.Value = DateTime.Now;
        }


        private bool isValidFields()
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                numericUpDown1.Value == 0 ||
                numericUpDown2.Value == 0)
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz");
                return true;
            }
            else
                return false;
        }

      
    }
}
    

    


