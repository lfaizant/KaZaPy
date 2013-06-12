﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18047
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebClient.ImageService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ImageInfo", Namespace="http://schemas.datacontract.org/2004/07/WebService")]
    [System.SerializableAttribute()]
    public partial class ImageInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int IdField;
        
        private int AlbumField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public int Album {
            get {
                return this.AlbumField;
            }
            set {
                if ((this.AlbumField.Equals(value) != true)) {
                    this.AlbumField = value;
                    this.RaisePropertyChanged("Album");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ImageService.IImageService")]
    public interface IImageService {
        
        // CODEGEN : La génération du contrat de message depuis l'opération AddImage n'est ni RPC, ni encapsulée dans un document.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageService/AddImage", ReplyAction="http://tempuri.org/IImageService/AddImageResponse")]
        WebClient.ImageService.AddImageResponse AddImage(WebClient.ImageService.ImageUploadRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageService/AddImage", ReplyAction="http://tempuri.org/IImageService/AddImageResponse")]
        System.Threading.Tasks.Task<WebClient.ImageService.AddImageResponse> AddImageAsync(WebClient.ImageService.ImageUploadRequest request);
        
        // CODEGEN : La génération du contrat de message depuis le nom de wrapper (ImageDownloadRequest) du message ImageDownloadRequest ne correspond pas à la valeur par défaut (GetImage)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageService/GetImage", ReplyAction="http://tempuri.org/IImageService/GetImageResponse")]
        WebClient.ImageService.ImageDownloadResponse GetImage(WebClient.ImageService.ImageDownloadRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageService/GetImage", ReplyAction="http://tempuri.org/IImageService/GetImageResponse")]
        System.Threading.Tasks.Task<WebClient.ImageService.ImageDownloadResponse> GetImageAsync(WebClient.ImageService.ImageDownloadRequest request);
        
        // CODEGEN : La génération du contrat de message depuis l'opération DeleteImage n'est ni RPC, ni encapsulée dans un document.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageService/DeleteImage", ReplyAction="http://tempuri.org/IImageService/DeleteImageResponse")]
        WebClient.ImageService.DeleteImageResponse DeleteImage(WebClient.ImageService.ImageDeleteRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageService/DeleteImage", ReplyAction="http://tempuri.org/IImageService/DeleteImageResponse")]
        System.Threading.Tasks.Task<WebClient.ImageService.DeleteImageResponse> DeleteImageAsync(WebClient.ImageService.ImageDeleteRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImageUploadRequest", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImageUploadRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public WebClient.ImageService.ImageInfo ImageInfo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream ImageData;
        
        public ImageUploadRequest() {
        }
        
        public ImageUploadRequest(WebClient.ImageService.ImageInfo ImageInfo, System.IO.Stream ImageData) {
            this.ImageInfo = ImageInfo;
            this.ImageData = ImageData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddImageResponse {
        
        public AddImageResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImageDownloadRequest", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImageDownloadRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public WebClient.ImageService.ImageInfo ImageInfo;
        
        public ImageDownloadRequest() {
        }
        
        public ImageDownloadRequest(WebClient.ImageService.ImageInfo ImageInfo) {
            this.ImageInfo = ImageInfo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImageDownloadResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImageDownloadResponse {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public WebClient.ImageService.ImageInfo ImageInfo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream ImageData;
        
        public ImageDownloadResponse() {
        }
        
        public ImageDownloadResponse(WebClient.ImageService.ImageInfo ImageInfo, System.IO.Stream ImageData) {
            this.ImageInfo = ImageInfo;
            this.ImageData = ImageData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImageDeleteRequest", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImageDeleteRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public WebClient.ImageService.ImageInfo ImageInfo;
        
        public ImageDeleteRequest() {
        }
        
        public ImageDeleteRequest(WebClient.ImageService.ImageInfo ImageInfo) {
            this.ImageInfo = ImageInfo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DeleteImageResponse {
        
        public DeleteImageResponse() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IImageServiceChannel : WebClient.ImageService.IImageService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ImageServiceClient : System.ServiceModel.ClientBase<WebClient.ImageService.IImageService>, WebClient.ImageService.IImageService {
        
        public ImageServiceClient() {
        }
        
        public ImageServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ImageServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ImageServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ImageServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebClient.ImageService.AddImageResponse WebClient.ImageService.IImageService.AddImage(WebClient.ImageService.ImageUploadRequest request) {
            return base.Channel.AddImage(request);
        }
        
        public void AddImage(WebClient.ImageService.ImageInfo ImageInfo, System.IO.Stream ImageData) {
            WebClient.ImageService.ImageUploadRequest inValue = new WebClient.ImageService.ImageUploadRequest();
            inValue.ImageInfo = ImageInfo;
            inValue.ImageData = ImageData;
            WebClient.ImageService.AddImageResponse retVal = ((WebClient.ImageService.IImageService)(this)).AddImage(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebClient.ImageService.AddImageResponse> WebClient.ImageService.IImageService.AddImageAsync(WebClient.ImageService.ImageUploadRequest request) {
            return base.Channel.AddImageAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebClient.ImageService.AddImageResponse> AddImageAsync(WebClient.ImageService.ImageInfo ImageInfo, System.IO.Stream ImageData) {
            WebClient.ImageService.ImageUploadRequest inValue = new WebClient.ImageService.ImageUploadRequest();
            inValue.ImageInfo = ImageInfo;
            inValue.ImageData = ImageData;
            return ((WebClient.ImageService.IImageService)(this)).AddImageAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebClient.ImageService.ImageDownloadResponse WebClient.ImageService.IImageService.GetImage(WebClient.ImageService.ImageDownloadRequest request) {
            return base.Channel.GetImage(request);
        }
        
        public System.IO.Stream GetImage(ref WebClient.ImageService.ImageInfo ImageInfo) {
            WebClient.ImageService.ImageDownloadRequest inValue = new WebClient.ImageService.ImageDownloadRequest();
            inValue.ImageInfo = ImageInfo;
            WebClient.ImageService.ImageDownloadResponse retVal = ((WebClient.ImageService.IImageService)(this)).GetImage(inValue);
            ImageInfo = retVal.ImageInfo;
            return retVal.ImageData;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebClient.ImageService.ImageDownloadResponse> WebClient.ImageService.IImageService.GetImageAsync(WebClient.ImageService.ImageDownloadRequest request) {
            return base.Channel.GetImageAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebClient.ImageService.ImageDownloadResponse> GetImageAsync(WebClient.ImageService.ImageInfo ImageInfo) {
            WebClient.ImageService.ImageDownloadRequest inValue = new WebClient.ImageService.ImageDownloadRequest();
            inValue.ImageInfo = ImageInfo;
            return ((WebClient.ImageService.IImageService)(this)).GetImageAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebClient.ImageService.DeleteImageResponse WebClient.ImageService.IImageService.DeleteImage(WebClient.ImageService.ImageDeleteRequest request) {
            return base.Channel.DeleteImage(request);
        }
        
        public void DeleteImage(WebClient.ImageService.ImageInfo ImageInfo) {
            WebClient.ImageService.ImageDeleteRequest inValue = new WebClient.ImageService.ImageDeleteRequest();
            inValue.ImageInfo = ImageInfo;
            WebClient.ImageService.DeleteImageResponse retVal = ((WebClient.ImageService.IImageService)(this)).DeleteImage(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebClient.ImageService.DeleteImageResponse> WebClient.ImageService.IImageService.DeleteImageAsync(WebClient.ImageService.ImageDeleteRequest request) {
            return base.Channel.DeleteImageAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebClient.ImageService.DeleteImageResponse> DeleteImageAsync(WebClient.ImageService.ImageInfo ImageInfo) {
            WebClient.ImageService.ImageDeleteRequest inValue = new WebClient.ImageService.ImageDeleteRequest();
            inValue.ImageInfo = ImageInfo;
            return ((WebClient.ImageService.IImageService)(this)).DeleteImageAsync(inValue);
        }
    }
}
