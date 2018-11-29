using HavFunService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HavFunService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "GET",
            UriTemplate = "GetData?value={value}")]
        string GetData(int value);

        [OperationContract]
        [WebInvoke(Method = "GET",
            UriTemplate = "GetNumber")]
        string GetNumber();

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "SubscribeHavFun",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string SubscribeHavFun(string data);


        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "SubscribeToBar", 
            BodyStyle = WebMessageBodyStyle.Bare, 
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json)]
        string SubscribeToBar(SubscribeToBarDTO stbDTO);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "PostComment",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string PostComment(PostCommentDTO pcDTO);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "PostEvent",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string PostEvent(PostEventDTO peDTO);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "LoginToHavFun",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string LoginToHavFun(LoginToHavFunDTO lthfDTO);

        // TODO: ajoutez vos opérations de service ici
    }

}
