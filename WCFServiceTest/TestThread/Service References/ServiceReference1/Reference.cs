﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34014
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestThread.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CommodityModel", Namespace="http://schemas.datacontract.org/2004/07/TestWcfService")]
    [System.SerializableAttribute()]
    public partial class CommodityModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CommodityIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StokField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CommodityId {
            get {
                return this.CommodityIdField;
            }
            set {
                if ((this.CommodityIdField.Equals(value) != true)) {
                    this.CommodityIdField = value;
                    this.RaisePropertyChanged("CommodityId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Stok {
            get {
                return this.StokField;
            }
            set {
                if ((this.StokField.Equals(value) != true)) {
                    this.StokField = value;
                    this.RaisePropertyChanged("Stok");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderFormModel", Namespace="http://schemas.datacontract.org/2004/07/TestWcfService")]
    [System.SerializableAttribute()]
    public partial class OrderFormModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CommodityIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CustomerIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DoTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GUIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsExecuteField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CommodityId {
            get {
                return this.CommodityIdField;
            }
            set {
                if ((this.CommodityIdField.Equals(value) != true)) {
                    this.CommodityIdField = value;
                    this.RaisePropertyChanged("CommodityId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CustomerId {
            get {
                return this.CustomerIdField;
            }
            set {
                if ((this.CustomerIdField.Equals(value) != true)) {
                    this.CustomerIdField = value;
                    this.RaisePropertyChanged("CustomerId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DoTime {
            get {
                return this.DoTimeField;
            }
            set {
                if ((this.DoTimeField.Equals(value) != true)) {
                    this.DoTimeField = value;
                    this.RaisePropertyChanged("DoTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GUID {
            get {
                return this.GUIDField;
            }
            set {
                if ((object.ReferenceEquals(this.GUIDField, value) != true)) {
                    this.GUIDField = value;
                    this.RaisePropertyChanged("GUID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsExecute {
            get {
                return this.IsExecuteField;
            }
            set {
                if ((this.IsExecuteField.Equals(value) != true)) {
                    this.IsExecuteField = value;
                    this.RaisePropertyChanged("IsExecute");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/OrderFormBehavior", ReplyAction="http://tempuri.org/IService/OrderFormBehaviorResponse")]
        bool OrderFormBehavior(int customerId, int commodityId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ChangeOrderFormState", ReplyAction="http://tempuri.org/IService/ChangeOrderFormStateResponse")]
        bool ChangeOrderFormState(string guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetCommodity", ReplyAction="http://tempuri.org/IService/GetCommodityResponse")]
        TestThread.ServiceReference1.CommodityModel[] GetCommodity();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetOrderFormList", ReplyAction="http://tempuri.org/IService/GetOrderFormListResponse")]
        TestThread.ServiceReference1.OrderFormModel[] GetOrderFormList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/StokInit", ReplyAction="http://tempuri.org/IService/StokInitResponse")]
        bool StokInit();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : TestThread.ServiceReference1.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<TestThread.ServiceReference1.IService>, TestThread.ServiceReference1.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool OrderFormBehavior(int customerId, int commodityId) {
            return base.Channel.OrderFormBehavior(customerId, commodityId);
        }
        
        public bool ChangeOrderFormState(string guid) {
            return base.Channel.ChangeOrderFormState(guid);
        }
        
        public TestThread.ServiceReference1.CommodityModel[] GetCommodity() {
            return base.Channel.GetCommodity();
        }
        
        public TestThread.ServiceReference1.OrderFormModel[] GetOrderFormList() {
            return base.Channel.GetOrderFormList();
        }
        
        public bool StokInit() {
            return base.Channel.StokInit();
        }
    }
}
