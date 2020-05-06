using MyWcfService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyWcfService
{
    [ServiceContract]
    public interface IPersonelService
    {

        [OperationContract]
        void Ekle (Employee emp);

        [OperationContract]
        void Sil(Employee emp);

        [OperationContract]
        void Guncelle(Employee emp);

        [OperationContract]
        List<Employee> getPersonelList();

        [OperationContract]
        List<Employee> Ara(Employee emp);

    }
}
