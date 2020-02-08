using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int tkP=1, tkN =1, count=0;
        string Descricao;
        List<TicketList> Ticket = new List<TicketList>();


        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            TicketList Tk = new TicketList
            {
                Tipo = "P",

                NumSeq = tkP++,

            };
            Descricao = Tk.Tipo + Tk.NumSeq;
            Ticket.Add(Tk);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Ticket;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P) {
                button2.PerformClick();
            };
            if (e.KeyCode == Keys.N)
            {
                button1.PerformClick();
            };
            if (e.KeyCode == Keys.A)
            {
                button3.PerformClick();
            };

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Ticket.Count == 0) {
                MessageBox.Show("Lista Vazia");
                return;
            }
            if (Ticket.Any(x=> x.Tipo == "P") && count < 3)
            {
                int P = Ticket.Where(x => x.Tipo == "P").Min(x => x.NumSeq);
                TicketList pri = Ticket.FirstOrDefault(x => x.Tipo == "P" && x.NumSeq == P);
                MessageBox.Show("O Ticket " +'P'+P + " foi atendito");
                Ticket.Remove(pri);
                count++;
            }
            else
            {
                int N = Ticket.Where(x => x.Tipo == "N").Min(x => x.NumSeq);
                TicketList pri = Ticket.FirstOrDefault(x => x.Tipo == "N" && x.NumSeq == N);
                MessageBox.Show("O Ticket N" + N + " foi atendito");
                Ticket.Remove(pri);
                count = 0;
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Ticket;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TicketList Tk = new TicketList {
                Tipo = "N",

                NumSeq = tkN++,            

            };
            Descricao = Tk.Tipo + Tk.NumSeq;
            Ticket.Add(Tk);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Ticket; 
        }
    }
}
