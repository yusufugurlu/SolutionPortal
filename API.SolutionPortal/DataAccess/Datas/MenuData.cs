using API.SolutionPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace API.SolutionPortal.DataAccess.Datas
{
    public static class MenuData
    {
        public static List<Menu> Menus = new List<Menu>() {
            new Menu(){
                Id=1,
                Name="Şirket",
                PersonRoleType=Common.Enums.PersonRoleType.Admin,
                Url="Company.html",
            },
              new Menu(){
                Id=2,
                Name="Masraf Merkezi",
                PersonRoleType=Common.Enums.PersonRoleType.Admin,
                Url="CostCenter.html",
            },
              new Menu(){
                Id=3,
                Name="Personel",
                PersonRoleType=Common.Enums.PersonRoleType.Admin,
                Url="Personel.html",
            },
               new Menu(){
                Id=4,
                Name="Masraf Türü",
                PersonRoleType=Common.Enums.PersonRoleType.Admin,
                Url="CostType.html",
            },
                 new Menu(){
                Id=5,
                Name="Vergi Kodu",
                PersonRoleType=Common.Enums.PersonRoleType.Admin,
                Url="TaxCode.html",
            },
                 new Menu(){
                Id=6,
                Name=" Ana Hesap Eşleştirme",
                PersonRoleType=Common.Enums.PersonRoleType.Admin,
                Url="Matching.html",
            }
        };
    }
}