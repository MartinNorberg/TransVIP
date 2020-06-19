namespace TransVIP.Transactions
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class Transaction : INotifyPropertyChanged
    {
        private readonly string transactionName;
        private readonly int messageID;
        private int ack;
        private int act;
        private readonly Direction direction;
        private ObservableCollection<Tag> tags;

        public Transaction(string transactionName, int messageID, Direction direction)
        {
            if (string.IsNullOrEmpty(transactionName))
            {
                throw new ArgumentException("Transaction must have a name");
            }

            if (messageID < 0 || messageID > 65535)
            {
                throw new ArgumentException("MessageId is not valid");
            }

            this.transactionName = transactionName;
            this.messageID = messageID;
            this.direction = direction;
            this.tags = new ObservableCollection<Tag>();
        }

        public bool AddTag(Tag tag)
        {
            if (string.IsNullOrEmpty(tag.Name))
            {
                throw new ArgumentException("Tag must have a name");
            }

            if (this.tags.Any(x => x.Name == tag.Name))
            {
                throw new DuplicateNameException("Tag already exist");
            }

            this.tags.Add(tag);
            return true;
        }

        public int MessageID => this.messageID;

        public string TransactionName => this.transactionName;

        public int Ack
        {
            get => this.ack;
            set
            {
                if (Equals(value, this.ack))
                {
                    return;
                }

                this.ack = value;
                this.OnPropertyChanged();
            }
        }

        public int Act
        {
            get => this.act;
            set
            {
                if (Equals(value, this.act))
                {
                    return;
                }

                this.act = value;
                this.OnPropertyChanged();
            }
        }

        public ObservableCollection<Tag> Tags
        {
            get => this.tags;
            set
            {
                if (ReferenceEquals(value, this.tags))
                {
                    return;
                }

                this.tags = value;
                this.OnPropertyChanged();
            }
        }

        public Direction Direction => direction;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
