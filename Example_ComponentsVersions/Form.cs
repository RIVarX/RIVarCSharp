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
        RIvar<string> nodejs = new RIvar<string>();
        RIvar<string[]> nodejsOptions = new RIvar<string[]>();

        RIvar<string> angular = new RIvar<string>();
        RIvar<string[]> angularOptions = new RIvar<string[]>();

        RIvar<string> angularCLI = new RIvar<string>();
        RIvar<string[]> angularCLIOptions = new RIvar<string[]>();

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
                .Select(line => new { angularCLI=line[0], angularVersion = line[1], nodeJSVersion = line[2] }).ToArray();


            angularOptions.Set(nodejsOptions.FilterBy(nodejs, o => o.nodeJSVersion, o => o.angularVersion));
            angularOptions.Set(angularCLIOptions.FilterBy(angularCLI, o => o.angularCLI, o => o.angularVersion));

            nodejsOptions.Set(angularOptions.FilterBy(angular, o => o.angularVersion, o => o.nodeJSVersion));
            nodejsOptions.Set(angularCLIOptions.FilterBy(angularCLI, o => o.angularCLI, o => o.nodeJSVersion));

            angularCLIOptions.Set(nodejsOptions.FilterBy(nodejs, o => o.nodeJSVersion, o => o.angularCLI));
            angularCLIOptions.Set(angularOptions.FilterBy(angular, o => o.angularVersion, o => o.angularCLI));


            //default lists
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(compatibleList.Select(o => o.nodeJSVersion).Union(new[] { "" }).Distinct().ToArray());
            comboBox2.Items.AddRange(compatibleList.Select(o => o.angularVersion).Union(new[] { "" }).Distinct().ToArray());
            comboBox3.Items.AddRange(compatibleList.Select(o => o.angularCLI).Union(new[] { "" }).Distinct().ToArray());


        }

        private void Connect()
        {
            nodejsOptions.Subscribe(currentList => updateComboboxList(currentList, comboBox1));
            angularOptions.Subscribe(currentList => updateComboboxList(currentList, comboBox2));
            angularCLIOptions.Subscribe(currentList => updateComboboxList(currentList, comboBox3));

            nodejs.Subscribe(o => { if (comboBox1.SelectedItem?.ToString() != o.Value) comboBox1.SelectedItem = o.Value; });
            angular.Subscribe(o => { if (comboBox2.SelectedItem?.ToString() != o.Value) comboBox2.SelectedItem = o.Value; });
            angularCLI.Subscribe(o => { if (comboBox3.SelectedItem?.ToString() != o.Value) comboBox3.SelectedItem = o.Value; });

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
            comboBox3.SelectedIndexChanged += ComboBox3_SelectedIndexChanged;
        }

        private static void updateComboboxList(Signal<string[]> currentList, ComboBox comboBox)
        {
            if (currentList.Value == null)
                return;

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
        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            angularCLI.OnNext(new Signal<string>((sender as ComboBox).SelectedItem.ToString()));
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            angular.OnNext(new Signal<string>((sender as ComboBox).SelectedItem.ToString()));
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nodejs.OnNext(new Signal<string>((sender as ComboBox).SelectedItem.ToString()));
        }
    }
}
