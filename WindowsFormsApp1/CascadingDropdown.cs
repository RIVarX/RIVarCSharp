using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReactiveVariablesExtension;

namespace WindowsFormsApp1
{
    public partial class CascadingDropdown : Form
    {
        Subject<SignalValue<string[]>> list1 = new Subject<SignalValue<string[]>>();
        Subject<SignalValue<string[]>> list2 = new Subject<SignalValue<string[]>>();
        Subject<SignalValue<string>> value1 = new Subject<SignalValue<string>>();
        Subject<SignalValue<string>> value2 = new Subject<SignalValue<string>>();

        public CascadingDropdown()
        {
            InitializeComponent();
        }

        private void CascadingDropdown_Load(object sender, EventArgs e)
        {
            Connect();

            //https://gist.github.com/LayZeeDK/c822cc812f75bb07b7c55d07ba2719b3
            var compatibleList =
                File.ReadLines("angular-cli-node-js-typescript-rxjs-compatiblity-matrix.csv").Skip(1).Select(o => o.Split(','))
                .Select(line => new { angularVersion = line[1], nodeJSVersion = line[2] }).ToArray();

            list2.Set(value1.SelectLatestSignal(o => compatibleList.Where(entry => string.IsNullOrEmpty(o) || entry.nodeJSVersion == o).Select(_ => _.angularVersion).Union(new[] { "" }).ToArray()));
            list1.Set(value2.SelectLatestSignal(o => compatibleList.Where(entry => string.IsNullOrEmpty(o) || entry.angularVersion == o).Select(_ => _.nodeJSVersion).Union(new[] { "" }).ToArray()));

            value1.OnNext(new SignalValue<string>(""));
            value2.OnNext(new SignalValue<string>(""));
        }

        private void Connect()
        {
            list1.Subscribe(currentList => updateComboboxList(currentList, comboBox1));
            list2.Subscribe(currentList => updateComboboxList(currentList, comboBox2));

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
        }

        private static void updateComboboxList(SignalValue<string[]> currentList, ComboBox comboBox)
        {
            var itemsToRemove = comboBox.Items.OfType<string>().Where(item => !currentList.Value.Contains(item)).ToArray();

            foreach (var item in itemsToRemove)
            {
                comboBox.Items.Remove(item);
            }
            foreach (var item in currentList.Value)
            {
                if (!comboBox.Items.Contains(item))
                {
                    comboBox.Items.Add(item);
                }
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            value2.OnNext(new SignalValue<string>((sender as ComboBox).SelectedItem.ToString()));
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            value1.OnNext(new SignalValue<string>((sender as ComboBox).SelectedItem.ToString()));
        }
    }
}
