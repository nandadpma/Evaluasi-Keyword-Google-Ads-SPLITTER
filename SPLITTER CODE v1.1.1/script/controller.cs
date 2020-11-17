using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public class controller
    {
        static Form1 main_form;// = new Form1();
        //static main main_screen;
        //static second second_screen;
        //static third third_screen;
        public controller()
        {
        }

        public controller(Form1 form) {
            main_form = form;
            init();
        }

        public void slide_sidebar()
        {
            if (sidebar_uc.Instance.Width == 106)
            {
                main_form.panel_side.Size = new System.Drawing.Size(718, 275);
                //main_form.panel_side.Width = 275;
                sidebar_uc.Instance.Size = new System.Drawing.Size(718, 275);
                //slide_status = true;
                //Console.WriteLine("Width : " + sidebar_uc.Instance.Width);
                //Console.WriteLine("Width : "+ main_form.panel_side.Width+" "+ sidebar_uc.Instance.Size);
            }
            else if (sidebar_uc.Instance.Width == 275)
            {
                //main_form.panel_side.SetBounds(0, 0, 106, 718);
                main_form.panel_side.Size = new System.Drawing.Size(718, 106);
                //main_form.panel_side.Width = 106;
                sidebar_uc.Instance.Size = new System.Drawing.Size(718, 106);
                //slide_status = false;
                //Console.WriteLine("Width : " + main_form.panel_side.Width + " " + sidebar_uc.Instance.Size);
            }
        }

        public void load_main_screen()
        {
            if (!main_form.panel1.Controls.Contains(main.Instance))
            {
                main_form.panel1.Controls.Add(main.Instance);
                main.Instance.Dock = DockStyle.Fill;
                main.Instance.BringToFront();
                Console.WriteLine("menambahkan main menu");
            }
            else
            {
                main.Instance.BringToFront();
                Console.WriteLine("menampilkan main menu");
            }
        }

        public void load_second_screen()
        {
            if (!main_form.panel1.Controls.Contains(second.Instance))
            {
                main_form.panel1.Controls.Add(second.Instance);
                second.Instance.Dock = DockStyle.Fill;
                second.Instance.BringToFront();
                Console.WriteLine("menambahkan group analysis");
            }
            else
            {
                second.Instance.BringToFront();
                Console.WriteLine("menampilkan group analysis");
            }
        }

        public void load_third_screen()
        {
            if (!main_form.panel1.Controls.Contains(third.Instance))
            {
                main_form.panel1.Controls.Add(third.Instance);
                third.Instance.Dock = DockStyle.Fill;
                third.Instance.BringToFront();
                Console.WriteLine("menambahkan find keyword");
            }
            else
            {
                third.Instance.BringToFront();
                Console.WriteLine("menampilkan find keyword");
            }
        }

        public void load_fourth_screen()
        {
            if (!main_form.panel1.Controls.Contains(fourth.Instance))
            {
                main_form.panel1.Controls.Add(fourth.Instance);
                fourth.Instance.Dock = DockStyle.Fill;
                fourth.Instance.BringToFront();
                Console.WriteLine("menambahkan find keyword");
            }
            else
            {
                fourth.Instance.BringToFront();
                Console.WriteLine("menampilkan find keyword");
            }
        }

        public void init()
        {
            if (!main_form.panel_side.Controls.Contains(sidebar_uc.Instance))
            {
                main_form.panel_side.Controls.Add(sidebar_uc.Instance);
                sidebar_uc.Instance.Dock = System.Windows.Forms.DockStyle.Fill;
                sidebar_uc.Instance.BringToFront();
                Console.WriteLine("menambahkan sidebar");
            }
            else
            {
                sidebar_uc.Instance.BringToFront();
                Console.WriteLine("menampilkan sidebar");
            }

            if (!main_form.panel1.Controls.Contains(main.Instance))
            {
                main_form.panel1.Controls.Add(main.Instance);
                main.Instance.Dock = System.Windows.Forms.DockStyle.Fill;
                main.Instance.BringToFront();
                Console.WriteLine("menambahkan main menu");
            }
            else
            {
                main.Instance.BringToFront();
                Console.WriteLine("menampilkan main menu");
            }
            Console.WriteLine("Done");
        }

    }
}
