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



            var filteredBySelectedNodejs = nodejs.Compute(value => compatibleList.Where(entry => string.IsNullOrEmpty(value) || entry.nodeJSVersion == value));
            var filteredBySelectedAngular = angular.Compute(value => compatibleList.Where(entry => string.IsNullOrEmpty(value) || entry.angularVersion == value));
            var filteredBySelectedCLIAngular = angularCLI.Compute(value => compatibleList.Where(entry => string.IsNullOrEmpty(value) || entry.angularCLI == value));


            angularOptions.Set(filteredBySelectedNodejs.Compute(o => o.Select(x => x.angularVersion).ToArray()).Compute(filteredBySelectedCLIAngular.Compute(o => o.Select(x => x.angularVersion).ToArray()), (x, y) => x.Intersect(y).Union(new[] { "" }).ToArray()));

            nodejsOptions.Set(filteredBySelectedAngular.Compute(o => o.Select(x => x.nodeJSVersion).ToArray()).Compute(filteredBySelectedCLIAngular.Compute(o => o.Select(x => x.nodeJSVersion).ToArray()), (x, y) => x.Intersect(y).Union(new[] { "" }).ToArray()));

            angularCLIOptions.Set(filteredBySelectedNodejs.Compute(o => o.Select(x => x.angularCLI).ToArray()).Compute(filteredBySelectedAngular.Compute(o => o.Select(x => x.angularCLI).ToArray()), (x, y) => x.Intersect(y).Union(new[] { "" }).ToArray()));

            /*
            angularOptions.Set(filteredBySelectedNodejs.Compute(o => o.Select(x => x.angularVersion).ToArray()));
            angularOptions.Set(angularOptions.Compute(filteredBySelectedCLIAngular.Compute(o => o.Select(x => x.angularVersion).ToArray()), (x, y) => x.Intersect(y).Union(new[] { "" }).ToArray()));

            nodejsOptions.Set(filteredBySelectedAngular.Compute(o => o.Select(x => x.nodeJSVersion).ToArray()));
            nodejsOptions.Set(nodejsOptions.Compute(filteredBySelectedCLIAngular.Compute(o => o.Select(x => x.nodeJSVersion).ToArray()), (x, y) => x.Intersect(y).Union(new[] { "" }).ToArray()));

            angularCLIOptions.Set(filteredBySelectedNodejs.Compute(o => o.Select(x => x.angularCLI).ToArray()));
            angularCLIOptions.Set(angularCLIOptions.Compute(filteredBySelectedAngular.Compute(o => o.Select(x => x.angularCLI).ToArray()), (x, y) => x.Intersect(y).Union(new[] { "" }).ToArray()));
            */
            //  angularOptions.Set(nodejs.Compute(value => compatibleList.Where(entry => string.IsNullOrEmpty(value) || entry.nodeJSVersion == value).Select(_ => _.angularVersion).Union(new[] { "" }).ToArray()));
            //   nodejsOptions.Set(angular.Compute(value => compatibleList.Where(entry => string.IsNullOrEmpty(value) || entry.angularVersion == value).Select(_ => _.nodeJSVersion).Union(new[] { "" }).ToArray()));


            ////if one items in the list - select it
            //  nodejs.Set(nodejsOptions.Where(o => o.Value.Count(_ => !string.IsNullOrEmpty(_)) == 1).Compute(o => o.Single(_ => !string.IsNullOrEmpty(_))));
            //angular.Set(angularOptions.Where(o => o.Value.Count(_ => !string.IsNullOrEmpty(_)) == 1).Compute(o => o.Single(_ => !string.IsNullOrEmpty(_))));


            nodejs.OnNext(new Signal<string>(""));
            angular.OnNext(new Signal<string>(""));
            angularCLI.OnNext(new Signal<string>(""));
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
