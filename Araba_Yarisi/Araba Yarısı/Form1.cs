using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Araba_Yarısı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        //arabaların tuşlara basılı tutup gitmesin her bir hareket için tekrar tekrar basması için bool değişkenler tanımladım.
        bool hareket1 = false;
        bool hareket2 = false;
        //Başalngıç butonuna basıldığında hem süreyi başlattım hem de tuşlara basıldığında algılamasını sağladım. 
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            this.KeyPreview = true;
        }
        //Geçen süreyi yazdırdım.
        private void timer1_Tick(object sender, EventArgs e)
        {
           int sure= Convert.ToInt32(label36.Text);
            sure++;
            label36.Text=sure.ToString();
        }
        //Tekrar başlatma butonu yaptım.
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();

        }
        //tekrar başlama butonunu başlangıçta görünmemesini sağladım.
        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Visible = false;
            
            
        }

       //S tuşuna basıldığında 1. paneli, L tuşuna basıldığında hareket etmelerini sağladım.Ve oyunun bitip bitmediğini kontrol ettim. 
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int hareketMesafesi = 10;
            if (!hareket1)
            {
                if (e.KeyCode == Keys.S) {
                panel1.Left += hareketMesafesi;
                    bittiMi();
                    hareket1 = true;
            }

            }
            if (!hareket2)
            {
                if (e.KeyCode == Keys.L)
                {
                    panel2.Left += hareketMesafesi;
                    bittiMi();
                    hareket2 = true;
                }

            }


        }

       
//tuşa basılı tutmayı engelledim.
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            hareket1 = false;
            hareket2 = false;
        }
        //Oyunun bitip bbitmediğini kontrol ettim eğer oyun biterse kareket etmeleri engelledim ,
        //süreyi durdurdum ve tekrar başla butonunu aktif ettim.
        private void bittiMi()
        {
            if (panel1.Right>label4.Left)
            {
                label37.Text = "Birinici Oynucu Kazandı";
                timer1.Enabled = false;
                this.KeyPreview = false;
                button2.Visible = true;


            }
            if (panel2.Right > label4.Left)
            {
                label37.Text = "İkinci Oynucu Kazandı";
                timer1.Enabled = false;
                this.KeyPreview = false;
                button2.Visible = true;

            }

        }
    }
}
