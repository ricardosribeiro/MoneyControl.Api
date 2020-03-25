using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MoneyControl.Data
{
    public static class QueryGenerator
    {
        /// <summary>
        /// O que isso faz é extrair uma lista de nomes de atributos em List<string>
        /// usando reflexão. Não extrairá os campos marcados com o atributo
        /// ignorar descrição.
        /// </summary>
        /// <param name="listOfProperties">IEnumerable<PorpertyInfo></param>
        /// <returns></returns>
        private static List<string> GenerateListOfPorperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            
            return (from prop in listOfProperties 
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || 
                    (attributes[0] as DescriptionAttribute)?.Description != "ignore" select prop.Name).ToList();
        }

        public static string GenerateInsertQuery(string tableName, IEnumerable<PropertyInfo> propertyInfoList) 
        {
            var insertQuery = new StringBuilder($"INSERT INTO {tableName} ");
            insertQuery.Append("(");

            var properties = GenerateListOfPorperties(propertyInfoList);
            properties.ForEach(prop => { insertQuery.Append($"[{prop}],"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(prop => { insertQuery.Append($"@{prop}, "); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");

            return insertQuery.ToString();
        }

        public static string GenerateUpdateQuery(string tableName, IEnumerable<PropertyInfo> propertyInfoList)
        {
            var updateQuery = new StringBuilder($"UPDATE {tableName} SET ");
            var properties =GenerateListOfPorperties(propertyInfoList);

            properties.ForEach(prop =>
            {
                if (!prop.Equals("Id"))
                {
                    updateQuery.Append($"{prop}=@{prop},");
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
            updateQuery.Append(" WHERE Id=@Id");

            return updateQuery.ToString();
        }
    }
}
