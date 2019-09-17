using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QUANTRO
{

    /*
     * Làm ơn sử lại lỗi dân >1 là không thể nhập tên dân. Lỗi lại chổ bắt submit gặp dân là dừng.
     * Kiểm tra coi phải dân cuối cùng ko
     * 
     * 
     * 
     */
     
    public partial class txt : Form
    {

        int slDan = 0;
        int [] slNguoichoi;
        int slSoi = 0;
        public string[] verb;
        int Night = 1;
        int maxNV = 7;
        public string [] listNhanVat;
        public int[] listLife;
        public int [] numDownList;
        List<Player> playerlist;


        public int thuocdoc;
        public int thuoccuunguoi;
        public int turnphuthuy;
        public string thosanTarget;
        public string namethosan ="";
        public txt()
        {
            listNhanVat = new string[50];
            numDownList = new int[50];
            playerlist = new List<Player>();
            verb = new string[50];
            listLife = new int[50];

            InitializeComponent();
            turn = 0;
            slNguoichoi = new int[50];
            thuoccuunguoi = 1;
            thuocdoc = 1;
            turnphuthuy = 0;

            initNhanVat();
        }

        void takemaxNV()
        {
            int max = 1;
            for (int i = 0; i < 50; i++)
                if (slNguoichoi[i] > max)
                    max = slNguoichoi[i];
            maxNV = max;
        }

        void initNhanVat()
        {
            for (int i = 0; i < 50; i++)
            {
                listNhanVat[i] = "";
                listLife[i] = -2;
                verb[i] = "";
                slNguoichoi[i] = -1;
            }
        }
        private void chkMS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMS.Checked)
            {
                listNhanVat[0] = "Mời ma sói";
                slNguoichoi[0] = 1;
                numericUpDown1.Value = 1;
                verb[0] = "Cắn";
            }
            else
            {
                listNhanVat[0] = "";
                slNguoichoi[0] = -1;
                numericUpDown1.Value = 0;
                verb[0] = "Cắn";
            }

        }

        private void chkSoiTrum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSoiTrum.Checked)
            {
                listNhanVat[1] = "Mời sói trùm";
                slNguoichoi[1] = 2;
                numericUpDown8.Value = 1;
                verb[1] = "Cắn";
            }
            else
            {
                listNhanVat[1] = "";
                slNguoichoi[1] = -1;
                numericUpDown8.Value = 0;
                verb[1] = "Cắn";
            }

        }

        private void chkPT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPT.Checked)
            {
                listNhanVat[2] = "Mời phù thủy";
                slNguoichoi[2] = 3;
                numericUpDown2.Value = 1;
            }
            else
            {
                listNhanVat[2] = "";
                slNguoichoi[2] = -1;
                numericUpDown2.Value = 0;
            }
   
        }

        private void chkTS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTS.Checked)
            {
                listNhanVat[3] = "Mời thợ săn";
                slNguoichoi[3] = 4;
                numericUpDown3.Value = 1;
                verb[3] = "Ghim";
            }
            else
            {
                listNhanVat[3] = "";
                slNguoichoi[3] = -1;
                numericUpDown3.Value = 0;
                verb[3] = "Ghim";
            }

        }

        private void chkbv_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBV.Checked)
            {
                listNhanVat[4] = "Mời bảo vệ";
                slNguoichoi[4] = 5;
                numericUpDown4.Value = 1;
                verb[4] = "Bảo vệ";
            }
            else
            {
                listNhanVat[4] = "";
                slNguoichoi[4] = -1;
                numericUpDown4.Value = 0;
                verb[4] = "Bảo vệ";
            }
       
        }

        private void chkTT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTT.Checked)
            {
                listNhanVat[5] = "Mời tiên tri";
                slNguoichoi[5] = 6;
                numericUpDown5.Value = 1;
                verb[5] = "Soi";
            }
            else
            {
                listNhanVat[5] = "";
                slNguoichoi[5] = -1;
                numericUpDown5.Value = 0;
                verb[5] = "Soi";
            }

        }

        private void chkHoLy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHoLy.Checked)
            {
                listNhanVat[6] = "Mời hồ ly";
                slNguoichoi[6] = 7;
                numericUpDown9.Value = 1;
                verb[6] = "Soi";
            }
            else
            {
                listNhanVat[6] = "";
                slNguoichoi[6] = -1;
                numericUpDown9.Value = 0;
                verb[6] = "Soi";
            }

        }

        private void chkD_CheckedChanged(object sender, EventArgs e)
        {
            if (chkD.Checked)
            {
                listNhanVat[8] = "Mời dân";
                slNguoichoi[8] = 9;
                numericUpDown6.Value = 1;
            }
            else
            {
                listNhanVat[8] = "";
                slNguoichoi[8] = -1;
                numericUpDown6.Value = 0;
            }

        }

        private void chkKeNgoc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKeNgoc.Checked)
            {
                listNhanVat[7] = "Mời kẻ ngốc";
                slNguoichoi[7] = 8;
                numericUpDown7.Value = 1;
            }
            else
            {
                listNhanVat[7] = "";
                slNguoichoi[7] = -1;
                numericUpDown7.Value = 0;
            }
  
        }



        private void takeNoList()
        {
            numDownList[0] = Convert.ToInt16(numericUpDown1.Value.ToString());
            numDownList[1] = Convert.ToInt16(numericUpDown8.Value.ToString());
            numDownList[2] = Convert.ToInt16(numericUpDown2.Value.ToString());
            numDownList[3] = Convert.ToInt16(numericUpDown3.Value.ToString());
            numDownList[4] = Convert.ToInt16(numericUpDown4.Value.ToString());
            numDownList[5] = Convert.ToInt16(numericUpDown5.Value.ToString());
            numDownList[6] = Convert.ToInt16(numericUpDown9.Value.ToString());
            numDownList[7] = Convert.ToInt16(numericUpDown7.Value.ToString());
            numDownList[8] = Convert.ToInt16(numericUpDown6.Value.ToString());
        }

        private int stt;
        private int turn;
        private void btnBatDau_Click(object sender, EventArgs e)
        {
            takemaxNV();
            slSoi = Convert.ToInt16(numericUpDown1.Value);
            slDan = Convert.ToInt16(numericUpDown6.Value);
            takeNoList();
            stt = 0;
            turn = 0;
            lbthoai.Text = listNhanVat[stt];
            panel1.Visible = true;
            btnBatDau.Hide();
            panel2.Visible = true;
            panel3.Visible = true;
            DisableChar();

            pnFunc.Visible = true;
            pnChar.Visible = false;
        }

        private void DisableChar()
        {
            if(chkMS.CheckState == CheckState.Unchecked)
            {
                panel4.Visible = false;
                
            }
            if (chkPT.CheckState == CheckState.Unchecked)
            {
               panel5.Visible = false;
            }
            if (chkTS.CheckState == CheckState.Unchecked)
            {
               panel6.Visible = false;
            }
            if (chkBV.CheckState == CheckState.Unchecked)
            {
                panel7.Visible = false;
            }
            if (chkTT.CheckState == CheckState.Unchecked)
            {
               panel8.Visible = false;
            }
            if (chkD.CheckState == CheckState.Unchecked)
            {
               panel9.Visible = false;
            }
            if (chkKeNgoc.CheckState == CheckState.Unchecked)
            {
                panel15.Visible = false;
            }
        }


        

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = lbthoai.Text.Substring(4, lbthoai.Text.Length - 4).Trim();
            Player nc = new Player(txtTen.Text, name);
            playerlist.Add(nc);
            if (name.Equals("thợ săn"))
            {
                namethosan = txtTen.Text + "\t   " + name;
            }

            //Mới code hôm qua mà cái wtf gì thế này???
            listLife[playerlist.Count - 1] = 1;
             //Đoạn này làm cái mẹ gì đó mình không nhớ
            if (turn < numDownList[stt]-1)
                turn++; // Biến này có lẽ là một biến cờ gì đó
            else
            {
                // Ủa biến turn là gì????
                turn = 0; // Wtf???? sao reset???
                stt++;
                while (stt<50 && listNhanVat[stt].Equals(""))
                    stt++;
                if (stt < 50) 
                lbthoai.Text = listNhanVat[stt];
            }
            //THÔI ĐÉO CODE NỮA

            txtTen.ResetText();
            takeInfortoList();
            if (maxNV < stt)
            {
               
                lbthoai.Text = "TRÒ CHƠI BẮT ĐẦU";
                panel3.Visible = false;
                takeInfortoList();
                comboBox1.DataSource = temp;
                comboBox1.Text = "Không ai cả";
                lbnight.Text = "Đêm thứ " + Night.ToString();
                dieTemp = new List<string>();
                stt = 0;
                timer1.Start();
                timer2.Start();
                start =DateTime.Now;
            }
        }




        List<string> temp;
        private void takeInfortoList()
        {

            temp = new List<string>();

            for(int  i = 0; i<playerlist.Count; i++)
            {
                if (listLife[i] ==1)
                {
                    string nameAndChar = playerlist[i].playerName + "\t   " + playerlist[i].vaiTro;
                    temp.Add(nameAndChar);
                }
            }
            listBox1.ResetText();
            listBox1.DataSource = temp;
            temp.Add("Không ai cả");
            comboBox2.DataSource = temp;
            comboBox1.DataSource = temp;
        }

        private void txt_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
           panel10.Visible = false;
            btndemtiep.Visible = false;
            panel13.Visible = false;
            pnFunc.Visible = false;

        }

        private void txtTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSubmit_Click(null, null);
        }


        List<String> dieTemp;

        int findIndex(string key)
        {
            int i;
            for (i = 0; i < temp.Count; i++)
            {
                if (temp[i].Equals(key))
                    break;
            }
            if (i == temp.Count)
                return -1;
            return i;
        }

        

        private void soiCan()
        {
            string key = comboBox1.SelectedValue.ToString();
            int k = findIndex(key);
            if (k != -1)
            {
                listLife[k] = 0;

            }
        }

        private void thoSandie()
        {
            string key = thosanTarget;
            int k = findIndex(key);
            if (k != -1 )
            {
                listLife[k] = -1;
            }
        }

        private void baovegiup(string name)
        {
            int k = findIndex(name);
            if(k!=-1)
            {
                if(listLife[k]!=-1)
                    listLife[k] = 1;
            }
        }

        void loadWhoDie()
        {


            int index = findIndex(namethosan);
            if(index!=-1)
            {
                if (listLife[index] == 0 || listLife[index] == -1)
                    thoSandie();
            }


            dieTemp = new List<string>();

            for(int i = 0; i<temp.Count-1; i++)
            {
                if (listLife[i] == -1 || listLife[i] == 0)
                    dieTemp.Add(temp[i]);
            }
            listBox2.ResetText();
            if (dieTemp.Count == 0)
                dieTemp.Add("Không ai chết");
            listBox2.DataSource = dieTemp;
           
                
            takeInfortoList();
        }




        private void loadAva()
        {
            if (stt == 0)
                picDienBien.Image = pictureBox1.Image;
            if (stt == 1)
                picDienBien.Image = pictureBox8.Image;
            if (stt == 2)
                picDienBien.Image = pictureBox2.Image;
            if (stt == 3)
                picDienBien.Image = pictureBox3.Image;
            if (stt == 4)
                picDienBien.Image = pictureBox4.Image;
            if (stt == 5)
                picDienBien.Image = pictureBox5.Image;
            if (stt == 6)
                picDienBien.Image = pictureBox9.Image;

        }

  

        int xTimer = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            xTimer++;
            
            if (xTimer == 1)
            {
                lbthoai.Text = listNhanVat[stt];
                
                panel10.Visible = true;

                loadAva();
                lbcuu.Text = "Cắn";
                richTextBox1.Text += "\n ************************* \n Đêm thứ " + Night.ToString() + " \n";
                timer1.Stop();
            }
        }

        
        private void btnThucThi_Click(object sender, EventArgs e)
        {

            comboBox1.Visible = true;
         
            string Blog = "";
            string thisChar = lbthoai.Text.Substring(4, lbthoai.Text.Length - 4).Trim();
            Blog = Blog + thisChar + "\t " + lbcuu.Text + "\t" + comboBox1.SelectedValue.ToString() + '\n';
            richTextBox1.Text += Blog;
            lbcuu.ResetText();


            if(!isAvlive(thisChar.Trim()))
            {
                comboBox1.Text = "Không ai cả";   
            }

           

            if (thisChar == "ma sói")
                soiCan();
            if (thisChar == "sói trùm")
                soiCan();
            if (thisChar == "thợ săn")
            {
                thosanTarget = comboBox1.SelectedValue.ToString();
            }
            if (thisChar == "bảo vệ")
            {
                baovegiup(comboBox1.SelectedValue.ToString());
            }

            if(thisChar == "phù thủy")
            {
                if(turnphuthuy==1)
                {
                    if (thuoccuunguoi == 1)
                    {
                        string t = comboBox1.SelectedValue.ToString();
                        if (!t.Equals("Không ai cả"))
                        {
                            int index = findIndex(t);
                            listLife[index] = 1;
                            thuoccuunguoi--;
                        }
                    }
                    else
                    {
                        comboBox1.Text = "Không ai cả";
                        comboBox1.Visible = false;
                    }
                }
                if(turnphuthuy == 2)
                {
                    if (thuocdoc == 1)
                    {
                        string t = comboBox1.SelectedValue.ToString();
                        if (!t.Equals("Không ai cả"))
                        {
                            int index = findIndex(t);
                            listLife[index] = -1;
                            thuocdoc--;
                        
                        }
                      
                    }
                    else
                    {
                        comboBox1.Text = "Không ai cả";
                        comboBox1.Visible = false;
                    }

                }
                comboBox1.Visible = true;
            }





            stt++;
            while (stt < 50 && listNhanVat[stt].Equals(""))
            {
                stt++;
            }

            if (stt < 50 && !listNhanVat[stt].Equals("Mời dân") && !listNhanVat[stt].Equals("Mời kẻ ngốc") )
            {
                loadAva();
                lbthoai.Text = listNhanVat[stt];
                lbcuu.Text = verb[stt];

                if (listNhanVat[stt].Equals("Mời phù thủy"))
                {
                   
                    if (turnphuthuy == 0)
                    {
                        turnphuthuy++;
                        stt--;
                        lbcuu.Text = "Cứu";
                        if (thuoccuunguoi == 0)
                        {
                            comboBox1.Text = "Không ai cả";
                            comboBox1.Visible = false;
                           
                        }
                     
                    }
                    else
                    {
                        if (turnphuthuy == 1)
                        {
                            turnphuthuy++;
                            lbcuu.Text = "Giết";
                            if (thuocdoc == 0)
                            {
                                comboBox1.Visible = false;
                            }
                        }
                    }
                  
                }
                else
                {

                }
              
                }
            else
            {
                picDienBien.Image = null;
                MessageBox.Show(lbnight.Text +" kết thúc" );
                turnphuthuy = 0;
                stt = 0;
                loadWhoDie();
                panel13.Visible = true;
                panel10.Visible = false;
                button1.Visible = true;
                button2.Visible = false;
                checkWin();
            }





        }

        private void button1_Click(object sender, EventArgs e)
        {
            btndemtiep.Visible = true;
            string key = comboBox2.SelectedValue.ToString();
            int k = findIndex(key);
            if(k!=-1)
            {
                listLife[k] = 0;
                MessageBox.Show("Đã treo cổ " + key);
            }
            button1.Visible = false;
            button2.Visible = true;
            lbcuu.Text = "Cắn";
            stt = 0;
            comboBox1.Text = "Không ai cả";
        }

        private void btndemtiep_Click(object sender, EventArgs e)
        {
            btndemtiep.Visible = false;
            initLife();
            takeInfortoList();
            stt = 0;
            loadAva();
            lbcuu.Text = "Cắn";
            Night++;
            lbnight.Text = "Đêm thứ " + Night.ToString();
            richTextBox1.Text += "\n ************************* \n Đêm thứ "+Night.ToString() +" \n";
            panel10.Visible = true;
            lbthoai.Text = listNhanVat[stt];

        }

        void initLife()
        {
            for(int i = 0;i <50; i++)
            {
                if (listLife[i] != 1)
                    listLife[i] = -2;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btndemtiep.Visible = true;
            string key = comboBox2.SelectedValue.ToString();
            int k = findIndex(key);
            if (k != -1)
            {
                listLife[k] = 1;
                MessageBox.Show("Đã cứu cổ " + key);
            }
            button2.Visible = false;
            btndemtiep.Visible = true;
            checkWin();
        }


        public void checkWin()
        {
            bool isSoiDie = false;
            int count = 0;
            for(int i = 0; i<slSoi; i++)
            {
                if (listLife[i] == 1)
                {
                    count++;
                    isSoiDie = true;
                }
            }


            if (!isSoiDie)
            {

                MessageBox.Show("DÂN THẮNG");

            }
            else
            {
                int count1 = 0;
                for (int i = 0; i < temp.Count - 1; i++)
                {
                    if (listLife[i] == 1)
                    {
                        count1++;
                    }
                }

                if(count1 == (count-count1))
                {
                    MessageBox.Show("SÓI THẮNG");
                }
            }
        }
        DateTime start;
        private void timer2_Tick(object sender, EventArgs e)
        {
            string a = (DateTime.Now - start).ToString();
            DateTime passTime = DateTime.Parse(a);
            string b = passTime.ToLongTimeString().ToString();

            b = b.Substring(3, b.Length - 3);
            b = b.Substring(0, b.Length - 2);

            lbtimer.Text = b;
 
        }

        bool isWordInWORD(string word, string WORD)
        {
            WORD = WORD.ToLower();
            word = word.ToLower();
            for (int i = 0; i <= WORD.Length - word.Length; i++)
                if (WORD.Substring(i, word.Length) == word)
                    return true;
            return false;
        }

        bool isAvlive(string Charac)
        {
            for(int i = 0; i<temp.Count-1; i++)
            {
                if (isWordInWORD(Charac, temp[i]))
                    return true;
            }
            return false;
        }


    }
}
