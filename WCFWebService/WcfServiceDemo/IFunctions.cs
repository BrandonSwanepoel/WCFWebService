using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Data;

namespace WcfServiceDemo
{
    [ServiceContract]
    public interface IFunctions
    {
        [OperationContract]
        [WebGet(UriTemplate= "/GetUserDetails")]
        DataSet GetUserDetails();
        [OperationContract]
        [WebGet(UriTemplate = "/CountUsers")]
        DataSet CountUsers();
        [WebInvoke(Method ="GET", BodyStyle=WebMessageBodyStyle.Wrapped, RequestFormat =WebMessageFormat.Json, ResponseFormat =WebMessageFormat.Json, UriTemplate = "/Count/{parameter}")]
        double Count(string parameter);
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Even/{parameter}")]
        double Even(string parameter);
        [WebGet(UriTemplate = "/GreatestCommonDenominator/{parameter}")]
        double GreatestCommonDenominator(string parameter);
        [WebGet(UriTemplate = "/LeastCommonDenominator/{parameter}")]
        double LeastCommonDenominator(string parameter);

    }
    [DataContract]
    public class Details
    {
        int Id;
        string Name;
        string Gender;
        string DateOfBirth;

        [DataMember(Order = 1)]
        public int ParameterId
        {
            get { return Id; }
            set { Id = value; }
        }
        [DataMember(Order = 2)]
        public string ParameterName
        {
            get { return Name; }
            set { Name = value; }
        }
        [DataMember(Order = 3)]
        public string ParameterGender
        {
            get { return Gender; }
            set { Gender = value; }
        }
        [DataMember(Order = 4)]
        public string ParameterDateOfBirth
        {
            get { return DateOfBirth; }
            set { DateOfBirth = value; }
        }
    }
}
