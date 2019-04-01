using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RTW_TA
{
	public partial class Main : Form
	{
		string[] ancillaries, traits;

		public Main()
		{
			InitializeComponent();

			if (!File.Exists(Properties.Settings.Default.Path + @"\Data\export_descr_ancillaries.txt"))
			{
				MessageBox.Show("Укажите путь до директории \"Rome - Total War\"");

				if (folderBrowserDlg.ShowDialog() == DialogResult.OK
					&& File.Exists(folderBrowserDlg.SelectedPath + @"\Data\export_descr_ancillaries.txt"))
				{
					Properties.Settings.Default.Path = folderBrowserDlg.SelectedPath;
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
				var descr = File.ReadAllLines(Properties.Settings.Default.Path + @"\Data\export_descr_ancillaries.txt");
				var ancillariesDesc =
					File.ReadAllLines(Properties.Settings.Default.Path + @"\Data\text\export_ancillaries.txt");

				foreach (var s in descr)
					if (s.Contains("Effect "))
					{
						var effect = s.Split(' ')[5];

						if (!effectsBox.Items.Contains(effect))
							effectsBox.Items.Add(effect);
					}

				string temp;
				int i = 0, j = 0;

				ancillaries = new string[ancillariesDesc.Count(s => s.Contains("_effects_desc}"))];
				while (i < descr.Length)
				{
					if (descr[i].StartsWith("Ancillary "))
					{
						temp = '{' + descr[i].Substring(descr[i].LastIndexOf(' ') + 1) + "_effects_desc}";

						while (descr[i] != "")
							ancillaries[j] += descr[i++] + "\r\n";

						for (var k = 0; k < ancillariesDesc.Length; ++k)
						{
							if (!ancillariesDesc[k].Contains(temp)) continue;

							ancillaries[j] += "\r\n" + ancillariesDesc[k + 1].Replace(", ", "\r\n") + "\r\n";

							break;
						}

						++j;
					}

					++i;
				}

				descr = File.ReadAllLines(Properties.Settings.Default.Path + @"\Data\export_descr_character_traits.txt");
				var traitsDesc = File.ReadAllLines(Properties.Settings.Default.Path + @"\Data\text\export_VnVs.txt");

				foreach (var s in descr)
					if (s.Contains("Effect "))
					{
						var trait = s.Split(' ')[5];

						if (!effectsBox.Items.Contains(trait))
							effectsBox.Items.Add(trait);
					}

				i = j = 0;
				traits = new string[traitsDesc.Count(s => s.Contains("_effects_desc}"))];
				while (i < descr.Length)
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
									for (var k = 0; k < traitsDesc.Length; ++k)
										if (traitsDesc[k].Contains(temp))
										{
											traits[j] += "\r\n" + traitsDesc[k + 1].Replace(", ", "\r\n") + "\r\n";
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

		private void effects_SelectedValueChanged(object sender, EventArgs e)
		{
			if (effectsBox.SelectedIndex != -1)
			{
				ancillariesBox.Items.Clear();
				traitsBox.Items.Clear();

				foreach (var s in ancillaries)
					if (s != null && s.Contains(effectsBox.SelectedItem.ToString()))
						ancillariesBox.Items.Add(s.Split(' ')[1].Replace("\r\n", ""));

				foreach (var s in traits)
					if (s != null && s.Contains(effectsBox.SelectedItem.ToString()))
						traitsBox.Items.Add(s.Split(' ')[1].Replace("\r\n", "") + ' ' + Regex.Matches(s, " Level ").Count);
			}
		}

		private void ancillaries_SelectedValueChanged(object sender, EventArgs e)
		{
			if (ancillariesBox.SelectedIndex != -1)
			{
				descriptionBox.Text = "";
				foreach (var s in ancillaries)
					if (s != null && s.Contains("Ancillary " + ancillariesBox.SelectedItem + "\r\n"))
					{
						descriptionBox.Text = s;
						break;
					}
			}
		}

		private void traits_SelectedValueChanged(object sender, EventArgs e)
		{
			if (traitsBox.SelectedIndex != -1)
			{
				descriptionBox.Text = "";
				foreach (var s in traits)
					if (s != null && s.Contains("Trait " + traitsBox.SelectedItem.ToString()
													.Remove(traitsBox.SelectedItem.ToString().IndexOf(' '))))
					{
						descriptionBox.Text = s;
						break;
					}
			}
		}

		private void Main_HelpButtonClicked(object sender, CancelEventArgs e)
		{
			MessageBox.Show("В программе задействованы всплывающие подсказки — наведите курсор на интересующий элемент.");
		}
	}
}