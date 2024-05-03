using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Insert()
        {

            label5.Text = String.Empty;
            Stopwatch sw = new Stopwatch();
            using (Over5000Entities db = new Over5000Entities())
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                sw.Start();

                int total = Convert.ToInt32(txt_number.Text);

                for (int i = 1; i < total + 1; i++)
                {
                    

                    

                    using (var context = new Over5000Entities())
                    {
                        var ids = db.Set<Echipamente>();
                        ids.Add(new Echipamente
                        {
                            nume_echipament = String.Format("Echipament {0}", i),
                            id_producator = int.Parse(txt_id.Text)
                        });
                    }

                    Echipamente obj2 = new Echipamente();

                    

                }
                db.SaveChanges();
                sw.Stop();
                label5.Text = string.Format("{0:hh\\:mm\\:ss\\:fff}", sw.Elapsed);
            }

        }

        public void InsertProvider()
        {
            try
            {

                label5.Text = String.Empty;
                Stopwatch sw = new Stopwatch();
                using (Over5000Entities db = new Over5000Entities())
                {
                    db.Configuration.AutoDetectChangesEnabled = false;
                    sw.Start();

                    Producatori obj1 = new Producatori();

                    obj1.nume_producator = txt_name.Text;
                    db.Producatoris.Add(obj1);

                    db.SaveChanges();
                    sw.Stop();
                    label5.Text = string.Format("{0:hh\\:mm\\:ss\\:fff}", sw.Elapsed);

                }
            }

            catch (Exception)
            {
                MessageBox.Show("Insert Failed");

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Insert();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertProvider();
        }
    }
}