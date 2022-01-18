using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace WebAPI.Repository
{
    public static class CustomerAttribute
    {
        public static List<CustomerAttributeModel> customerAttributeModels = new List<CustomerAttributeModel>
        {
            new CustomerAttributeModel {Id = 100, AttributeMaster = "Kệnh phân phối",AttributeValuesCode="ab",Description ="Des3",ShortName="text3",
                                        Parent="text4", EffectiveDate=DateTime.Parse("2021/12/12"), ValidUntil=DateTime.Parse("2021/12/12")},
            new CustomerAttributeModel {Id = 101, AttributeMaster = "Kênh phụ",AttributeValuesCode="rt",Description ="Des1",ShortName="sname2",
                                        Parent="aaa", EffectiveDate=DateTime.Parse("2021/12/12"), ValidUntil=DateTime.Parse("2021/12/12")},
            new CustomerAttributeModel {Id = 102, AttributeMaster = "Vị trí B",AttributeValuesCode="ui",Description ="Des54",ShortName="sname3",
                                        Parent="pareent6", EffectiveDate=DateTime.Parse("2021/12/12"), ValidUntil=DateTime.Parse("2021/12/12")},
        };
    }
}
