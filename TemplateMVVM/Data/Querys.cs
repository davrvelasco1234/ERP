using System.Collections.Generic;
using ERP_Common;
using ERP_Entorno;
using TemplateMVVM.Model;

namespace TemplateMVVM.Data
{
    public class Querys : SqlConnect
    {
        public static IEnumerable<ErpDictionary> Select_MarcaList() => Connection.ExecQuery.Query<ErpDictionary>(Scripts.Select_MarcaList, null);  
        public static ErpDictionary Select_Marca(object param) => Connection.ExecQuery.QuerySingle<ErpDictionary>(Scripts.Select_Marca, param);    
        public static int Insert_Marca(object param) => Connection.ExecQuery.Execute(Scripts.Insert_Marca, param);
        public static int Update_Marca(object param) => Connection.ExecQuery.Execute(Scripts.Update_Marca, param);
        public static int Delete_Marca(object param) => Connection.ExecQuery.Execute(Scripts.Delete_Marca, param);


        public static IEnumerable<ErpDictionary> Select_CarroceriaList() => Connection.ExecQuery.Query<ErpDictionary>(Scripts.Select_CarroceriaList, null);
        public static ErpDictionary Select_Carroceria(object param) => Connection.ExecQuery.QuerySingle<ErpDictionary>(Scripts.Select_Carroceria, param);  
        public static int Insert_Carroceria(object param) => Connection.ExecQuery.Execute(Scripts.Insert_Carroceria, param);
        public static int Update_Carroceria(object param) => Connection.ExecQuery.Execute(Scripts.Update_Carroceria, param);
        public static int Delete_Carroceria(object param) => Connection.ExecQuery.Execute(Scripts.Delete_Carroceria, param);


        public static IEnumerable<ErpDictionary> Select_ModeloList() => Connection.ExecQuery.Query<ErpDictionary>(Scripts.Select_ModeloList, null);
        public static ErpDictionary Select_Modelo(object param) => Connection.ExecQuery.QuerySingle<ErpDictionary>(Scripts.Select_Modelo, param);
        public static int Insert_Modelo(object param) => Connection.ExecQuery.Execute(Scripts.Insert_Modelo, param);
        public static int Update_Modelo(object param) => Connection.ExecQuery.Execute(Scripts.Update_Modelo, param);
        public static int Delete_Modelo(object param) => Connection.ExecQuery.Execute(Scripts.Delete_Modelo, param);


        //public static IEnumerable<AutoIdentity> Select_AutoList() => Entorno.ExecQuery.Query<AutoIdentity>(Scripts.Select_AutoList, null);
        //public static AutoIdentity Select_Auto(object param) => Entorno.ExecQuery.QuerySingle<AutoIdentity>(Scripts.Select_Auto, param);
        public static int Insert_Auto(object param) => Connection.ExecQuery.Execute(Scripts.Insert_Auto, param);
        public static int Update_Auto(Auto param) => Connection.ExecQuery.Execute(Scripts.Update_Auto, param);
        public static int Delete_Auto(object param) => Connection.ExecQuery.Execute(Scripts.Delete_Auto, param);


        public static IEnumerable<Auto> Sp_GetAutos() => Connection.ExecQuery.Query<Auto>(Scripts.Sp_GetAutos, null);
    }
}
