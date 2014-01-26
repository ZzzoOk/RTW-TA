using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTW_TA
{
    public partial class Form1 : Form
    {
        string[] ancillaries = new string[300], ancillaries_desc = new string[600], traits = new string[300], traits_desc = new string[1500];

        public Form1()
        {
            InitializeComponent();

            if (!File.Exists(Properties.Settings.Default.Path + @"\Data\export_descr_ancillaries.txt"))
            {
                MessageBox.Show("Укажите путь до директории \"Rome - Total War\"");
                
                if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && File.Exists(folderBrowserDialog1.SelectedPath + @"\Data\export_descr_ancillaries.txt"))
                {
                    Properties.Settings.Default.Path = folderBrowserDialog1.SelectedPath;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    MessageBox.Show("Необходимые файлы не найдены — программа завершает работу.");
                    Environment.Exit(1);
                }
            }

            try
            {
                string[] descr = File.ReadAllLines(Properties.Settings.Default.Path + @"\Data\export_descr_ancillaries.txt");
                ancillaries_desc = File.ReadAllLines(Properties.Settings.Default.Path + @"\Data\text\export_ancillaries.txt");

                foreach (string s in descr)
                    if (s.Contains("Effect "))
                        if (!listBox1.Items.Contains(s.Split(' ')[5]))
                            listBox1.Items.Add(s.Split(' ')[5]);

                string temp;
                int i = 0, j = 0;

                while (i < descr.Count())
                {
                    if (descr[i].StartsWith("Ancillary "))
                    {
                        temp = '{' + descr[i].Substring(descr[i].LastIndexOf(' ') + 1) + "_effects_desc}";

                        while (descr[i] != "")
                            ancillaries[j] += descr[i++] + "\r\n";

                        for (int k = 0; k < ancillaries_desc.Count(); ++k)
                        {
                            if (ancillaries_desc[k].Contains(temp))
                            {
                                ancillaries[j] += "\r\n" + ancillaries_desc[k + 1].Replace(", ", "\r\n") + "\r\n";
                                break;
                            }
                        }
                        ++j;
                    }
                    ++i;
                }

                descr = File.ReadAllLines(Properties.Settings.Default.Path + @"\Data\export_descr_character_traits.txt");
                traits_desc = File.ReadAllLines(Properties.Settings.Default.Path + @"\Data\text\export_VnVs.txt");

                foreach (string s in descr)
                    if (s.Contains("Effect "))
                        if (!listBox1.Items.Contains(s.Split(' ')[5]))
                            listBox1.Items.Add(s.Split(' ')[5]);

                i = j = 0;
                while (i < descr.Count())
                {
                    if (descr[i].StartsWith("Trait "))
                    {
                        while (descr[i] != "" || descr[i + 1] != "")
                        {
                            traits[j] += descr[i] + "\r\n";

                            if (descr[i].Contains(" Level "))
                            {
                                temp = '{' + descr[i].Substring(descr[i].LastIndexOf(' ') + 1) + "_effects_desc}";

                                if (descr[i].Contains(" Effect ") && descr[i + 1] == "")
                                {
                                    for (int k = 0; k < traits_desc.Count(); ++k)
                                        if (traits_desc[k].Contains(temp))
                                        {
                                            traits[j] += "\r\n" + traits_desc[k + 1].Replace(", ", "\r\n") + "\r\n";
                                            break;
                                        }
                                }
                            }
                            ++i;
                        }
                        ++j;
                    }
                    ++i;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox2.Items.Clear();
                listBox3.Items.Clear();

                foreach (string s in ancillaries)
                    if (s != null && s.Contains(listBox1.SelectedItem.ToString()))
                        listBox2.Items.Add(s.Split(' ')[1].Replace("\r\n", ""));

                foreach (string s in traits)
                    if (s != null && s.Contains(listBox1.SelectedItem.ToString()))
                        listBox3.Items.Add(s.Split(' ')[1].Replace("\r\n", "") + ' ' + Regex.Matches(s, " Level ").Count.ToString());
            }
        }

        private void listBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                textBox1.Text = "";
                foreach (string s in ancillaries)
                    if (s != null && s.Contains("Ancillary " + listBox2.SelectedItem.ToString()))
                        textBox1.Text = s;
            }
        }

        private void listBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex != -1)
            {
                textBox1.Text = "";
                foreach (string s in traits)
                    if (s != null && s.Contains("Trait " + listBox3.SelectedItem.ToString().Remove(listBox3.SelectedItem.ToString().IndexOf(' '))))
                        textBox1.Text += s;
            }
        }

        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MessageBox.Show("В программе задействованы всплывающие подсказки — наведите курсор на интересующий элемент.");
        }
    }
}