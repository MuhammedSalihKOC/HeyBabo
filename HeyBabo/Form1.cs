using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using System.Net;

namespace HeyBabo
{
    public partial class Form1 : Form
    {
        int satir = 0;
        string a;
        int q = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Wikipedia araması için önce bilgi yazıp sonra aramak istediğiniz konuyu boşluksuz yazınız.(Örn: +bilgi +DünyanınŞekli)");
        }

        private void Gonder_Click(object sender, EventArgs e)
        {            
            MessageBoxER.Focus();
            button1_Click(button1,e);
            yukari(satir);
            label1.Text = MessageBoxER.Text;
            satir++;
            NeDedim(MessageBoxER.Text);
        }
        void yaziyor()
        {
            label12.Visible = true;
            Application.DoEvents();
            Thread.Sleep(1000);
            for (int i = 0; i < 3; i++)
            {
                label12.Text = "Yazıyor.";
                Application.DoEvents();
                Thread.Sleep(250);
                label12.Text = "Yazıyor..";
                Application.DoEvents();
                Thread.Sleep(250);
                label12.Text = "Yazıyor...";
                Application.DoEvents();
                Thread.Sleep(250);
            }
            label12.Visible = false;
        }
        void yukari(int satir)
        {
            switch (satir)
            {
                case 0:
                    pictureBox1.Visible = true;
                    break;
                case 1:
                    pictureBox2.Visible = true;
                    label2.Text = label1.Text;
                    break;
                case 2:
                    pictureBox3.Visible = true;
                    label3.Text = label2.Text;
                    label2.Text = label1.Text;
                    break;
                case 3:
                    pictureBox4.Visible = true;
                    label4.Text = label3.Text;
                    label3.Text = label2.Text;
                    label2.Text = label1.Text;
                    break;
                case 4:
                    pictureBox5.Visible = true;
                    label5.Text = label4.Text;
                    label4.Text = label3.Text;
                    label3.Text = label2.Text;
                    label2.Text = label1.Text;
                    break;
                case 5:
                    pictureBox6.Visible = true;
                    label6.Text = label5.Text;
                    label5.Text = label4.Text;
                    label4.Text = label3.Text;
                    label3.Text = label2.Text;
                    label2.Text = label1.Text;
                    break;
                case 6:
                    pictureBox7.Visible = true;
                    label7.Text = label6.Text;
                    label6.Text = label5.Text;
                    label5.Text = label4.Text;
                    label4.Text = label3.Text;
                    label3.Text = label2.Text;
                    label2.Text = label1.Text;
                    break;
                case 7:
                    pictureBox8.Visible = true;
                    label8.Text = label7.Text;
                    label7.Text = label6.Text;
                    label6.Text = label5.Text;
                    label5.Text = label4.Text;
                    label4.Text = label3.Text;
                    label3.Text = label2.Text;
                    label2.Text = label1.Text;
                    break;
                case 8:
                    pictureBox9.Visible = true;
                    label9.Text = label8.Text;
                    label8.Text = label7.Text;
                    label7.Text = label6.Text;
                    label6.Text = label5.Text;
                    label5.Text = label4.Text;
                    label4.Text = label3.Text;
                    label3.Text = label2.Text;
                    label2.Text = label1.Text;
                    break;
                case 9:
                    pictureBox10.Visible = true;
                    label10.Text = label9.Text;
                    label9.Text = label8.Text;
                    label8.Text = label7.Text;
                    label7.Text = label6.Text;
                    label6.Text = label5.Text;
                    label5.Text = label4.Text;
                    label4.Text = label3.Text;
                    label3.Text = label2.Text;
                    label2.Text = label1.Text;
                    break;
                case 10:
                    pictureBox11.Visible = true;
                    label11.Text = label10.Text;
                    label10.Text = label9.Text;
                    label9.Text = label8.Text;
                    label8.Text = label7.Text;
                    label7.Text = label6.Text;
                    label6.Text = label5.Text;
                    label5.Text = label4.Text;
                    label4.Text = label3.Text;
                    label3.Text = label2.Text;
                    label2.Text = label1.Text;
                    break;
                default:
                    label11.Text = label10.Text;
                    label10.Text = label9.Text;
                    label9.Text = label8.Text;
                    label8.Text = label7.Text;
                    label7.Text = label6.Text;
                    label6.Text = label5.Text;
                    label5.Text = label4.Text;
                    label4.Text = label3.Text;
                    label3.Text = label2.Text;
                    label2.Text = label1.Text;
                    break;
            }
        }
        void NeDedim(string dedim)
        {
            MessageBoxER.Text = "";
            if (dedim == "x" || dedim == "X")
            {
                q = 0;
                yaziyor();
                yukari(satir);
                label1.Text = "Peki.";
                satir++;
            }
            if (q == 1)
            {
                try
                {
                    WebClient client = new WebClient();
                    string htmlString = client.DownloadString("https://tr.wikipedia.org/wiki/" + label1.Text);
                    HtmlAgilityPack.HtmlDocument htmlBelgesi = new HtmlAgilityPack.HtmlDocument();
                    htmlBelgesi.OptionFixNestedTags = true;
                    htmlBelgesi.LoadHtml(htmlString);
                    HtmlAgilityPack.HtmlNodeCollection secilenler = htmlBelgesi.DocumentNode.SelectNodes("//*[@id='mw-content-text']/div[1]/p[1]");

                    if (secilenler != null)
                    {
                        richTextBox1.Visible = true;
                        button1.Visible = true;
                        a = StringReplace(secilenler[0].InnerText);
                        richTextBox1.Text = a;
                    }
                    q = 0;
                    yaziyor();
                }
                catch
                {
                    yaziyor();
                    yukari(satir);
                    label1.Text = "Yanlış yada eksik yazmış olabilir misin?";
                    satir++;
                    yaziyor();
                    yukari(satir);
                    label1.Text = "Tekrar dene veya 'x' yazarak çık.";
                    satir++;
                }

            }
            if (dedim.IndexOf("Hey Babo") > -1 || dedim.IndexOf("hey babo") > -1)
            {
                yaziyor();
                yukari(satir);
                label1.Text = "Hey, Nabün Cano!";
                satir++;
            }
            if (dedim.IndexOf("Selam") > -1 || dedim.IndexOf("selam") > -1)
            {
                yaziyor();
                yukari(satir);
                label1.Text = "Aleykum Selam";
                satir++;
            }
            if (dedim.IndexOf("Nasılsın") > -1 || dedim.IndexOf("nasılsın") > -1)
            {
                yaziyor();
                yukari(satir);
                label1.Text = "İyiyim. Sen nasılsın?";
                satir++;
            }        
            if (dedim.IndexOf("İyiyim") > -1 || dedim.IndexOf("iyiyim") > -1)
            {
                yaziyor();
                yukari(satir);
                label1.Text = "Allah iyilik versin.";
                satir++;
            }
            if (dedim.IndexOf("Merhaba") > -1 || dedim.IndexOf("merhaba") > -1)
            {
                yaziyor();
                yukari(satir);
                label1.Text = "Merhaba";
                satir++;
            }
            if (dedim.IndexOf("Naber") > -1 || dedim.IndexOf("naber") > -1)
            {
                yaziyor();
                yukari(satir);
                label1.Text = "İyidir. Senden naber?";
                satir++;
            }
            if (dedim.IndexOf("Dolar") > -1 || dedim.IndexOf("dolar") > -1)
            {
                yaziyor();
                yukari(satir); string bugun = "http://www.tcmb.gov.tr/kurlar/today.xml";
                var xmldoc = new XmlDocument();
                xmldoc.Load(bugun);
                string USD = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod= 'USD']/BanknoteSelling").InnerXml;
                label1.Text = "Dolar şuan tam olarak " +USD.ToString()+".";
                satir++;
            }
            if (dedim.IndexOf("Euro") > -1 || dedim.IndexOf("euro") > -1)
            {
                yaziyor();
                yukari(satir); 
                string bugun = "http://www.tcmb.gov.tr/kurlar/today.xml";
                var xmldoc = new XmlDocument();
                xmldoc.Load(bugun);
                string EUR = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod= 'EUR']/BanknoteSelling").InnerXml;
                label1.Text = "Euro şuan tam olarak " + EUR.ToString() + ".";
                satir++;
            }
            if (dedim.IndexOf("Kolay gel") > -1 || dedim.IndexOf("kolay gel") > -1)
            {
                yaziyor();
                yukari(satir);
                label1.Text = "EyvAllah ciğerim.";
                satir++;
            }
            if (dedim.IndexOf("Sterlin") > -1 || dedim.IndexOf("sterlin") > -1)
            {
                yaziyor();
                yukari(satir);
                string bugun = "http://www.tcmb.gov.tr/kurlar/today.xml";
                var xmldoc = new XmlDocument();
                xmldoc.Load(bugun);
                string GBP = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod= 'GBP']/BanknoteSelling").InnerXml;
                label1.Text = "Sterlin şuan tam olarak " + GBP.ToString() + ".";
                satir++;
            }
            if (dedim.IndexOf("Bilgi") > -1 || dedim.IndexOf("bilgi") > -1)
            {
                yaziyor();
                yukari(satir);
                label1.Text = "Aradığını tek kelime olarak söyle.";
                q = 1;
                satir++;
            }            

        }
        string StringReplace(string text)
        {
            text = text.Replace("İ", "İ");
            text = text.Replace("Ä±", "ı");
            text = text.Replace("Ğ", "Ğ");
            text = text.Replace("ÄŸ", "ğ");
            text = text.Replace("Ã–", "Ö");
            text = text.Replace("Ã¶", "ö");
            text = text.Replace("Ü", "Ü");
            text = text.Replace("Ã¼", "ü");
            text = text.Replace("Ş", "Ş");
            text = text.Replace("ÅŸ", "ş");
            text = text.Replace("Ã‡", "Ç");
            text = text.Replace("Ã§", "ç");
            text = text.Replace("&#160;", "");
            text = text.Replace("&#91;1&#93;", "");
            return text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = false;
            button1.Visible = false;
        }
    }
}
