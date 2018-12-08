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
            if (Environment.GetCommandLineArgs().Length == 2)
            {
                if (Environment.GetCommandLineArgs()[1] == "s")
                {
                    Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
                    notify("BirthdayManager is running!");
                    hide(this, new EventArgs());
                }
            }
            Console.WriteLine(Directory.GetCurrentDirectory());
            if (!File.Exists("default.bdf")) File.Create("default.bdf").Dispose();
            open(this, new EventArgs());
            if (Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run").GetValue("BirthdayManager") != null) startCheck.Checked = true;
            t.Interval = 600000;
            t.Tick += checkNotif;
            checkNotif(this, new EventArgs());
        }

        private void checkNotif(object sender, EventArgs e)
        {
            if (DateTime.Today != day)
            {
                foreach (var x in notif.Keys.ToArray())
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
                    if (p.yearless)
                    {
                        notify("It's " + p.name + "'s birthday today!");
                    }
                    else
                    {
                        int age = day.Year - p.date.Year;
                        if (p.date > day.AddYears(-age)) age--;
                        notify("It's " + p.name + "'s birthday today! They're now " + age + " years old!");
                    }
                    notif[i] = true;
                }
                i++;
            }
        }

        private void open(object sender, EventArgs e)
        {
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
                saveButton.Text = "Save";
                file = new BirthdayFile(open.FileName);
                path = open.FileName;
            }
            nameList.Items.Clear();
            notif.Clear();
            int i = 0;
            foreach (Person p in file.people)
            {
                nameList.Items.Add(p.name);
                notif.Add(i, false);
                i++;
            }
            t.Stop();
            t.Start();
        }

        private void select(object sender, EventArgs e)
        {
            if (nameList.SelectedIndex == -1) return;
            dateShow.Value = file.people[nameList.SelectedIndex].date;
            nameText.Text = file.people[nameList.SelectedIndex].name;
            calculateAge(file.people[nameList.SelectedIndex].date);
            yearlessCheck.Checked = file.people[nameList.SelectedIndex].yearless;
            yearLabel.Visible = !file.people[nameList.SelectedIndex].yearless;
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
            //bool x = notif[nameList.SelectedIndex];
            //notif.Remove(nameList.SelectedIndex);
            //notif.Add(nameList.SelectedIndex, x);
            //  the hell was the point in that?
            file.people[nameList.SelectedIndex].name = nameText.Text;
            nameList.Items[nameList.SelectedIndex] = nameText.Text;
        }

        private void hide(object sender, EventArgs e)
        {
            if (sender == hideToTray) notify("BirthdayManager is now hidden.");
            ShowInTaskbar = false;
            Visible = false;
        }

        private void toggle(object sender, EventArgs e)
        {
            if (Visible == true)
            {
                notify("BirthdayManager is now hidden.");
                hide(sender, e);
            }
            else show(sender, e);
        }

        private void show(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
            Visible = true;
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
            DateTime next = date.AddYears(DateTime.Today.Year - date.Year);
            if (next < DateTime.Today) next = next.AddYears(1);
            int days = (next - DateTime.Today).Days;
            yearLabel.Text = age + " years old";
            dayLabel.Text = days + " days until\nbirthday";
        }

        private void add(object sender, EventArgs e)
        {
            file.people.Add(new Person());
            nameList.Items.Add("New Person");
            notif.Add(nameList.Items.Count - 1, true);
        }

        private void remove(object sender, EventArgs e)
        {
            if (nameList.SelectedItem == null
                || MessageBox.Show("Are you sure you want to remove " + file.people[nameList.SelectedIndex].name + " from the list?",
                "Delete Warning",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            file.people.RemoveAt(nameList.SelectedIndex);
            nameList.Items.RemoveAt(nameList.SelectedIndex);
            notif.Remove(nameList.SelectedIndex);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.ApplicationExitCall) return;

            e.Cancel = true;
            notify("BirthdayManager is now hidden.");
            hide(nameLabel, e); //nameLabel used as dummy
        }

        private void exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) notifyContext.Show(Cursor.Position);
            else toggle(sender, e);
        }

        private void notify(string text)
        {
            notifyIcon.ShowBalloonTip(10000, "BirthdayManager", text, ToolTipIcon.None);
        }

        private void yearlessChange(object sender, EventArgs e)
        {
            if (nameList.SelectedItem == null) return;
            file.people[nameList.SelectedIndex].yearless = yearlessCheck.Checked;
            yearLabel.Visible = !yearlessCheck.Checked;
        }
    }
}