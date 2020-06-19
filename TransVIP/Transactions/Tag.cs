
namespace TransVIP.Transactions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Tag
    {
        private readonly string name;
        private string value;

        public Tag(string name, string value = "")
        {
            this.name = name;
            this.value = value;
        }

        public string Name => this.name;

        public string Value { get => this.value; set => this.value = value; }
    }
}
