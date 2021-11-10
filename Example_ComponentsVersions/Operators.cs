using RIvarX;
using System;
using System.IO;
using System.Linq;

namespace Example_ComponentsVersions
{
    struct comptabilityrow
    {
        public string angularCLI;
        public string angularVersion;
        public string nodeJSVersion;
    }

    static class Operators
    {
        public static Expression<string[]> FilterBy(this IObservable<Signal<string[]>> operand1List, IObservable<Signal<string>> operand2Selected,
           Func<comptabilityrow, string> getter1, Func<comptabilityrow, string> getter2)
        {
            //https://gist.github.com/LayZeeDK/c822cc812f75bb07b7c55d07ba2719b3
            var compatibleList =
                File.ReadLines("angular-cli-node-js-typescript-rxjs-compatiblity-matrix.csv").Skip(1).Select(o => o.Split(','))
                .Select(line => new comptabilityrow { angularCLI = line[0], angularVersion = line[1], nodeJSVersion = line[2] }).ToArray();

            return operand1List.Compute(operand2Selected, 
                
                
                (list, selected) => {
                   var r= list
.SelectMany(itemName => compatibleList.Where(o => getter1(o) == itemName))//take the entire row
.Where(o => getter1(o) == selected || string.IsNullOrEmpty(selected))//take only selected
.ToArray();

                    var a= list
.SelectMany(itemName => compatibleList.Where(o => getter1(o) == itemName))//take the entire row
.Where(o => getter1(o) == selected || string.IsNullOrEmpty(selected))//take only selected
.Select(o => getter2(o)).Distinct().ToArray();
                    return a;
                }
            );
           
        }
    }
}
