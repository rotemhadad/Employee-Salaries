using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Employee_salaries
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        /*
         * make a bordless form move
         **/
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        ListView listView2 = new ListView();

        /*
         * end move form code
         */
        public double Tax(double sal)
        {
            if (sal < 0) return 0;
            if (sal >= 0 && sal <= 6450)
                return sal * 0.1;
            if (sal > 6450 && sal <= 9240)
                return sal * 0.14;
            if (sal > 9240 && sal <= 14840)
                return sal * 0.2;
            if (sal > 14840 && sal <= 20620)
                return sal * 0.31;
            if (sal > 20620 && sal <= 42910)
                return sal * 0.35;
            else
                return sal * 0.47;

        }

        private void clearScreen()
        {
            ///clear the textBox///
            textBox_address.Clear();
            textBox_phone.Clear();
            textBox_name.Clear();
            textBox_lastName.Clear();
            textBox_ID.Clear();
            textBox_salary.Clear();
            textBox_email.Clear();
            //clears erorr masseges
            label3.Text = "";
            label4.Text = "";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            clearScreen();
            string[] arrFirstName = { "אורטל", "רותם","יונתן","גבי" , "גדעון","גד" , "גדליהו" , "גולן","גומא","גורן" ,
                "גיורא","גילי","גלבוע" , "גמליאל","גל","גפן" , "גלעד","אמרי","אנדי" , "אסף","אפרים","אסי" , "אראל","אריה","ארתור",
                "ארנון" , "אפרים","אסיף","תמר","דב", "דביר", "דגן", "דוד", "דודו", "דודי", "דולב", "דור"," דוראל", "דורון", "דורי",
                "דותן", "דן", "דני"," דקל", "דראל", "דרור","הדר", "הללי", "הלליה", "הראל","זאב", "זבולון", "זוהר", "זיו ", "חגי",
                "חזי", "חיים", "חן", "חני", "חניאל", "חננאל", "חנניה", "חפר", "טהר", "טוביה", "טל", "טניה","גיא","תום","נחמיה",
                "ישראל","איתי","ים" , "רוני","ירין", "תהל","נטע","בר","שיר" , "מיתר","זינה","רונה" , "מירן","שני","יאיר", "יגאל", "יגיל",
                "ידידיה", "ידין", "יהב", "יהודה", "יהונתן", "יהושע", "יואב", "יובל","יוחאי", "יונתן" };
            string[] arrLastName = {"כהן","לוי","מזרחי", "פרץ", "ביטון", "פרידמן","אברהם", "דהן", "כץ",
            "אזולאי", "מלכה", "דוד", "חדד", "עמר", "אוחיון", "גבאי", "יוסף", "קליין", "לוין", "שפירא",
            "מועלם", "פריד", "גוטליב", "הירש", "ברכה", "מרדכי", "וולף", "אוזן", "שאול", "דגן" , "הורוביץ", "דויטש", "אביטבול",
            "סגל","אשכנזי","חזן","שורץ","רוזנברג","אוחנה","שטרן","גרינברג","בר","גולן","אלבז","גולדשטיין","סויסה","דיין","אטיאס",
            "שרעבי","לביא","ששון","ברוך","פלדמן","חמו","ממן","עובדיה","מימון","גולדברג","אסולין","אלון","וקנין","רובין","רבינוביץ",
            "אמסלם","שוורץ","עזרא","הרשקוביץ","ברקוביץ","סבג","קדוש","ישראל","יפרח","מילר","שמואלי","נעים","אברהמי","ברנשטיין","נוימן","פנחס","סבן",
                "עטיה","קוגן","הופמן","אילוז","קרן","בוזגלו","שקד","זינגר","צברי","יונה","גרוסמן","רובינשטיין","תורג'מן","בן סימון","אשר","שיטרית","חמו",
                "טויטו","בראון","כחלון","פרי","ארביב","ברמן","שגב","שדה","בוסקילה","אלימלך","פינטו"};
            string[] email = { "rotem@gmail.com", "ortal@gmail.com", "aa@gmail.com", "bb@gmail.com", "cc@gmail.com", "dd@gmail.com" };
            string[] address = { "Beer Sheva", "Omer", "Meitar", "Eilat", "Rishon Letzion", "Tel Aviv", "Gedera", "Lehavim" };
            string[] phone_number = { "0501234569", "0501234561", "0501234523", "0501234559", "0501234554", "0501234589", "0501234505", "0501234532" };
            Random rnd = new Random();
            for (int i = 0; i < 10000; i++)
            {
                int rndID = rnd.Next(111111111, 999999999);
                int rndSalary = rnd.Next(3000, 50000);
                int nameIndex = rnd.Next(0, arrFirstName.Length - 1);
                int lastNameIndex = rnd.Next(0, arrLastName.Length - 1);
                int emailIndex = rnd.Next(0, email.Length - 1);
                int addressIndex = rnd.Next(0, address.Length - 1);
                int phone_numberIndex = rnd.Next(0, phone_number.Length - 1);

                string rndName = arrFirstName[nameIndex];
                string rndLastName = arrLastName[lastNameIndex];
                string rndEmail = email[emailIndex];
                string rndaddress = address[addressIndex];
                string rndphone_number = phone_number[phone_numberIndex];

                string[] data = { rndName + " " + rndLastName, rndID.ToString(), rndSalary.ToString() };
                string[] data2 = { rndEmail , rndaddress , rndphone_number };
                
                ListViewItem employee = new ListViewItem(data);
                listView1.Items.Add(employee);

                ListViewItem employee2 = new ListViewItem(data2);
                listView2.Items.Add(employee2);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }


        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_showEmployees_Click(object sender, EventArgs e)
        {

        }

        private void button_calcTax_Click(object sender, EventArgs e)
        {
            clearScreen();
            try
            {
                int index = listView1.SelectedIndices[0];
                int temp;
                string text = listView1.Items[index].SubItems[2].Text;
                temp = Convert.ToInt32(text);
                double sal = (double)temp;
                text = Convert.ToString(Tax(sal));
                label2.Text = text;
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
        }


        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            //error in button1_Click
        }

        private void button_sort_Click(object sender, EventArgs e)
        {
            button_sort_Click_Call(listView1, listView2);
        }
        public void button_sort_Click_Call(ListView listView1, ListView listView2)
        {
            clearScreen();
            DateTime startTime, endTime;
            startTime = DateTime.Now;

            /**
             * this is bubble sort for employee list
             */
            //ListViewItem temp1, temp2;
            //for (int i = 0; i < listView1.Items.Count - 1; i++)
            //{
            //    for (int j = 0; j < listView1.Items.Count - i - 1; j++)
            //    {
            //        if (Convert.ToInt32(listView1.Items[j].SubItems[2].Text) > Convert.ToInt32(listView1.Items[j + 1].SubItems[2].Text))
            //        {
            //            Swap(j, j + 1, listView1);
            //        }
            //    }
            //}
            /**
             * this is QuickSr for employee list
             */
            quickSort(0, listView1.Items.Count - 1, listView1, listView2);
            endTime = DateTime.Now;
            Double sum = ((TimeSpan)(endTime - startTime)).TotalMilliseconds;
            label4.Text = "הזמן שלקח למיון : " + sum.ToString();
        }

        public void Swap(int indexA, int indexB,ListView listView1, ListView listView2) //swap 2 index
        {
            if (indexA != indexB)
            {
                ListViewItem item1 = listView1.Items[indexA];
                ListViewItem item2 = listView1.Items[indexB];
                listView1.Items.Remove(item1);
                listView1.Items.Remove(item2);
                listView1.Items.Insert(indexA, item2);
                listView1.Items.Insert(indexB, item1);

                ListViewItem item3 = listView2.Items[indexA];
                ListViewItem item4 = listView2.Items[indexB];
                listView2.Items.Remove(item3);
                listView2.Items.Remove(item4);
                listView2.Items.Insert(indexA, item4);
                listView2.Items.Insert(indexB, item3);
            }
        }
        public void quickSort(int low, int high, ListView listView1,ListView listView2)
        {
            if (low < high)
            {
                int pi = partition(low, high, listView1, listView2);
                quickSort(low, pi - 1, listView1, listView2);  // Before pivot
                quickSort(pi + 1, high, listView1, listView2); // After pivot
            }
        }
        public int partition(int low, int high,ListView listView1,ListView listView2)
        {

            ListViewItem pivot = listView1.Items[high]; // pivot
            int i = (low - 1); // Index of smaller element and indicates the right position of pivot found so far

            for (int j = low; j <= high - 1; j++)
            {
                // If current element is smaller than the pivot
                if ((Convert.ToInt32(listView1.Items[j].SubItems[2].Text) < (Convert.ToInt32(pivot.SubItems[2].Text))))
                {
                    i++;
                    Swap(i, j, listView1, listView2);
                }
            }
            Swap(i + 1, high, listView1, listView2);
            return (i + 1);
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            //close the form 
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //minimize the form
            this.WindowState = FormWindowState.Minimized;
        }

        private void button_addEmp_Click(object sender, EventArgs e)
        {

            if (textBox_name.Text != "" && textBox_lastName.Text != "" && textBox_ID.Text != "" && textBox_salary.Text != "")
            {
                if (Regex.IsMatch((textBox_salary.Text), "^[0-9]*$") && Regex.IsMatch((textBox_ID.Text), "^[0-9]*$") && Regex.IsMatch((textBox_name.Text), "^[a-zA-Zא-ת]*$") && Regex.IsMatch((textBox_lastName.Text), "^[a-zA-Zא-ת]*$"))
                {

                    string[] data = { textBox_name.Text + " " + textBox_lastName.Text, textBox_ID.Text, textBox_salary.Text };
                    ListViewItem employee = new ListViewItem(data);
                    listView1.Items.Add(employee);

                    string[] data2 = { textBox_email.Text, textBox_address.Text, textBox_phone.Text };
                    ListViewItem employee2 = new ListViewItem(data2);
                    listView2.Items.Add(employee2);
                    clearScreen();
                }
                else
                    label3.Text = "נא הזן שנית ערכים תקינים";
            }
            else
            {
                label3.Text = "נא להכניס את כל הפרטים";
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
