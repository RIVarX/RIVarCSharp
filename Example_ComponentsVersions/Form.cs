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
using RIvarX;

namespace Example_ComponentsVersions
{
    public partial class Form : System.Windows.Forms.Form
    {
        RIvar<string[]> list1 = new RIvar<string[]>();
        RIvar<string[]> list2 = new RIvar<string[]>();
        RIvar<string> value1 = new RIvar<string>();
        RIvar<string> value2 = new RIvar<string>();

        public Form()
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

            list2.Set(value1.Compute(value => compatibleList.Where(entry => string.IsNullOrEmpty(value) || entry.nodeJSVersion == value).Select(_ => _.angularVersion).Union(new[] { "" }).ToArray()));
            list1.Set(value2.Compute(value => compatibleList.Where(entry => string.IsNullOrEmpty(value) || entry.angularVersion == value).Select(_ => _.nodeJSVersion).Union(new[] { "" }).ToArray()));

            ////if one items in the list - select it
            value1.Set(list1.Where(o => o.Value.Count(_ => !string.IsNullOrEmpty(_)) == 1).Compute(o => o.Single(_ => !string.IsNullOrEmpty(_))));
            value2.Set(list2.Where(o => o.Value.Count(_ => !string.IsNullOrEmpty(_)) == 1).Compute(o => o.Single(_ => !string.IsNullOrEmpty(_))));

            value1.OnNext(new Signal<string>(""));
            value2.OnNext(new Signal<string>(""));
        }

        private void Connect()
        {
            list1.Subscribe(currentList => updateComboboxList(currentList, comboBox1));
            list2.Subscribe(currentList => updateComboboxList(currentList, comboBox2));

            value1.Subscribe(o => { if (comboBox1.SelectedItem?.ToString() != o.Value) comboBox1.SelectedItem = o.Value; });
            value2.Subscribe(o => { if (comboBox2.SelectedItem?.ToString() != o.Value) comboBox2.SelectedItem = o.Value; });

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
        }

        private static void updateComboboxList(Signal<string[]> currentList, ComboBox comboBox)
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
            value2.OnNext(new Signal<string>((sender as ComboBox).SelectedItem.ToString()));
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            value1.OnNext(new Signal<string>((sender as ComboBox).SelectedItem.ToString()));
        }
    }
}
