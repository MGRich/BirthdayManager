using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BirthdayFormat;
using Microsoft.Win32;
using System.Reflection;
using System.IO;

namespace BirthdayManager
{
    public partial class BirthdayManager : Form
    {
        private BirthdayFile file = null;
        private string path = null;
        private Timer t = new Timer();
        private DateTime day = DateTime.Today;

        private Dictionary<int, bool> notif = new Dictionary<int, bool>();

        public BirthdayManager()
        {
            InitializeComponent();
            Console.WriteLine(Environment.GetCommandLineArgs()[1]);
            if (Environment.GetCommandLineArgs()[1] == "s")
            {
                Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
                startCheck.Checked = true;
                notifyIcon.ShowBalloonTip(3000, "BirthdayManager", "BirthdayManager is running!", ToolTipIcon.None);
                hide(this, new EventArgs());
            }
            Console.WriteLine(Directory.GetCurrentDirectory());
            if (File.Exists("default.bdf")) open(this, new EventArgs());
            t.Interval = 10000;
            t.Tick += checkNotif;
        }

        private void checkNotif(object sender, EventArgs e)
        {
            if (DateTime.Today != day)
            {
                foreach (var x in notif.Keys)
                {
                    notif[x] = false;
                }
                day = DateTime.Today;
            }
            int i = 0;
            foreach (Person p in file.people)
            {
                if (day.Month == p.date.Month && day.Day == p.date.Day && !notif[i])
                {
                    int age = day.Year - p.date.Year;
                    if (p.date > day.AddYears(-age)) age--;
                    notifyIcon.ShowBalloonTip(10000, "BirthdayManager", "It's " + p.name + "'s birthday today! They're now " + age + " years old!", ToolTipIcon.None);
                    notif[i] = true;
                }
                i++;
            }
        }

        private void open(object sender, EventArgs e)
        {
            nameList.Items.Clear();
            t.Stop();
            if (sender == this)
            {
                file = new BirthdayFile("default.bdf");
                path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\default.bdf";
                Console.WriteLine(path);
            }
            else
            {
                OpenFileDialog open = new OpenFileDialog
                {
                    Filter = "BirthdayManager File|*.bdf"
                };
                if (open.ShowDialog() != DialogResult.OK) return;
                file = new BirthdayFile(open.FileName);
                path = open.FileName;
            }
            int i = 0;
            foreach (Person p in file.people)
            {
                nameList.Items.Add(p.name);
                notif.Add(i++, false);
            }
            t.Start();
        }

        private void select(object sender, EventArgs e)
        {
            if (nameList.SelectedIndex == -1) return;
            dateShow.Value = file.people[nameList.SelectedIndex].date;
            nameText.Text = file.people[nameList.SelectedIndex].name;
            calculateAge(file.people[nameList.SelectedIndex].date);
        }

        private void dateChange(object sender, EventArgs e)
        {
            if (nameList.SelectedItem == null) return;
            file.people[nameList.SelectedIndex].date = dateShow.Value;
            calculateAge(file.people[nameList.SelectedIndex].date);
        }

        private void save(object sender, EventArgs e)
        {
            if (path == null) path = "default.bdf";
            file.write(path);
        }

        private void saveAs(object sender, EventArgs e)
        {
            SaveFileDialog open = new SaveFileDialog
            {
                Filter = "BirthdayManager File|*.bdf"
            };
            if (open.ShowDialog() != DialogResult.OK) return;
            file.write(open.FileName);
        }

        private void nameChange(object sender, EventArgs e)
        {
            if (nameList.SelectedItem == null) return;
            bool x = notif[nameList.SelectedIndex];
            notif.Remove(nameList.SelectedIndex);
            notif.Add(nameList.SelectedIndex, x);
            file.people[nameList.SelectedIndex].name = nameText.Text;
            nameList.Items[nameList.SelectedIndex] = nameText.Text;
        }

        private void hide(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            if (sender != this) notifyIcon.ShowBalloonTip(1000, "BirthdayManager", "BirthdayManager has been hidden.", ToolTipIcon.None);
            Hide();
        }

        private void show(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Show();
        }

        private void startChecked(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (startCheck.Checked)
            {
                key.SetValue("BirthdayManager", Assembly.GetEntryAssembly().Location + " s");
            }
            else
            {
                key.DeleteValue("BirthdayManager", false);
            }
        }

        private void calculateAge(DateTime date)
        {
            int age = DateTime.Today.Year - date.Year;
            if (date > DateTime.Today.AddYears(-age)) age--;
            int days = (DateTime.Today - date).Days;
            days -= age * 365;
            yearLabel.Text = age + " years old";
            dayLabel.Text = "+ " + days + " days";
        }

        private void add(object sender, EventArgs e)
        {
            file.people.Add(new Person());
            nameList.Items.Add("New Person");
            notif.Add(nameList.Items.Count - 1, false);
        }

        private void remove(object sender, EventArgs e)
        {
            if (nameList.SelectedItem == null || MessageBox.Show("Are you sure you want to delete " + file.people[nameList.SelectedIndex].name + "?", "Delete Warning", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            file.people.RemoveAt(nameList.SelectedIndex);
            nameList.Items.RemoveAt(nameList.SelectedIndex);
            notif.Remove(nameList.SelectedIndex);
        }
    }
}