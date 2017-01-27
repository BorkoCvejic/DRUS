﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RTUClientLiman.RTUClientReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RTUClientReference.IServiceWithCB", CallbackContract=typeof(RTUClientLiman.RTUClientReference.IServiceWithCBCallback))]
    public interface IServiceWithCB {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWithCB/Start", ReplyAction="http://tempuri.org/IServiceWithCB/StartResponse")]
        string Start();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWithCB/Start", ReplyAction="http://tempuri.org/IServiceWithCB/StartResponse")]
        System.Threading.Tasks.Task<string> StartAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWithCB/RecordMeasurement", ReplyAction="http://tempuri.org/IServiceWithCB/RecordMeasurementResponse")]
        void RecordMeasurement(string RTUName, int value, string type, System.DateTime time);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWithCB/RecordMeasurement", ReplyAction="http://tempuri.org/IServiceWithCB/RecordMeasurementResponse")]
        System.Threading.Tasks.Task RecordMeasurementAsync(string RTUName, int value, string type, System.DateTime time);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceWithCBCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWithCB/OnMeasurementRecorded", ReplyAction="http://tempuri.org/IServiceWithCB/OnMeasurementRecordedResponse")]
        void OnMeasurementRecorded();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceWithCBChannel : RTUClientLiman.RTUClientReference.IServiceWithCB, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceWithCBClient : System.ServiceModel.DuplexClientBase<RTUClientLiman.RTUClientReference.IServiceWithCB>, RTUClientLiman.RTUClientReference.IServiceWithCB {
        
        public ServiceWithCBClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServiceWithCBClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServiceWithCBClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceWithCBClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceWithCBClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public string Start() {
            return base.Channel.Start();
        }
        
        public System.Threading.Tasks.Task<string> StartAsync() {
            return base.Channel.StartAsync();
        }
        
        public void RecordMeasurement(string RTUName, int value, string type, System.DateTime time) {
            base.Channel.RecordMeasurement(RTUName, value, type, time);
        }
        
        public System.Threading.Tasks.Task RecordMeasurementAsync(string RTUName, int value, string type, System.DateTime time) {
            return base.Channel.RecordMeasurementAsync(RTUName, value, type, time);
        }
    }
}