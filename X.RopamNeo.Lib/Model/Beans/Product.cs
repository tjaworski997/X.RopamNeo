// Type: X.RopamNeo.Lib.Model.Beans.Product

using System;
using System.ComponentModel;

namespace X.RopamNeo.Lib.Model.Beans
{
    public class Product : INotifyPropertyChanged
    {
        private bool enabled = true;
        private bool purchased;
        private string description;
        private string title;
        private string productIdentifier;
        private int availableQuantity;
        private string formattedPrice;
        private Decimal price;
        private DateTime checkTime;
        private DateTime subscriptionExpirationDate;
        private bool subscriptionExpired;
        private bool valid;
        private int productType;
        private int subscriptionDuration;
        private DateTime transactionDate;
        private string transactionId;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Enabled
        {
            set
            {
                if (this.enabled == value)
                    return;
                this.enabled = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Enabled)));
            }
            get => this.enabled;
        }

        public string ProductIdentifier
        {
            set
            {
                if (!(this.productIdentifier != value))
                    return;
                this.productIdentifier = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(ProductIdentifier)));
            }
            get => this.productIdentifier;
        }

        public bool Purchased
        {
            set
            {
                if (this.purchased == value)
                    return;
                this.purchased = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Purchased)));
            }
            get => this.purchased;
        }

        public string Description
        {
            set
            {
                if (!(this.description != value))
                    return;
                this.description = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Description)));
            }
            get => this.description;
        }

        public string Title
        {
            set
            {
                if (!(this.title != value))
                    return;
                this.title = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Title)));
            }
            get => this.title;
        }

        public int AvailableQuantity
        {
            set
            {
                if (this.availableQuantity == value)
                    return;
                this.availableQuantity = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(AvailableQuantity)));
            }
            get => this.availableQuantity;
        }

        public string FormattedPrice
        {
            set
            {
                if (!(this.formattedPrice != value))
                    return;
                this.formattedPrice = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(FormattedPrice)));
            }
            get => this.formattedPrice;
        }

        public Decimal Price
        {
            set
            {
                if (!(this.price != value))
                    return;
                this.price = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Price)));
            }
            get => this.price;
        }

        public DateTime SubscriptionExpirationDate
        {
            set
            {
                if (!(this.subscriptionExpirationDate != value))
                    return;
                this.subscriptionExpirationDate = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(SubscriptionExpirationDate)));
            }
            get => this.subscriptionExpirationDate;
        }

        public DateTime CheckTime
        {
            set
            {
                if (!(this.checkTime != value))
                    return;
                this.checkTime = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(CheckTime)));
            }
            get => this.checkTime;
        }

        public string SubscriptionExpirationDateStr => this.subscriptionExpirationDate.ToString("yyyy-MM-dd HH:mm:ss");

        public bool SubscriptionExpired
        {
            set
            {
                if (this.subscriptionExpired == value)
                    return;
                this.subscriptionExpired = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(SubscriptionExpired)));
            }
            get => this.subscriptionExpired;
        }

        public bool Valid
        {
            set
            {
                if (this.valid == value)
                    return;
                this.valid = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(Valid)));
            }
            get => this.valid;
        }

        public int ProductType
        {
            set
            {
                if (this.productType == value)
                    return;
                this.productType = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(ProductType)));
            }
            get => this.productType;
        }

        public int SubscriptionDuration
        {
            set
            {
                if (this.subscriptionDuration == value)
                    return;
                this.subscriptionDuration = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(SubscriptionDuration)));
            }
            get => this.subscriptionDuration;
        }

        public DateTime TransactionDate
        {
            set
            {
                if (!(this.transactionDate != value))
                    return;
                this.transactionDate = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(TransactionDate)));
            }
            get => this.transactionDate;
        }

        public string TransactionId
        {
            set
            {
                if (!(this.transactionId != value))
                    return;
                this.transactionId = value;
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged((object)this, new PropertyChangedEventArgs(nameof(TransactionId)));
            }
            get => this.transactionId;
        }

        public string TransactionDateStr => this.transactionDate.ToString("yyyy-MM-dd HH:mm:ss");

        public string Image => "Assets/b120.png";

        public enum ProductTypes
        {
            Unknown,
            Consumable,
            NonConsumable,
            AutoRenewableSubscription,
            FreeSubscription,
            NonRenewingSubscription,
        }

        public enum SubscriptionDurations
        {
            Unlimited,
            SevenDays,
            OneMonth,
            TwoMonths,
            ThreeMonths,
            SixMonths,
            OneYear,
        }
    }
}